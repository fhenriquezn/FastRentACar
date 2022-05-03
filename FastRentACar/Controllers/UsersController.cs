using AutoMapper;
using FastRentACar.BusinessLogic.Services.Contracts;
using FastRentACar.DataAccess.Contracts;
using FastRentACar.Domain.Dto.Request;
using FastRentACar.Domain.Dto.Response;
using FastRentACar.Domain.Models;
using FastRentACar.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastRentACar.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseController<UpdateUserRequest>
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICryptoService cryptoService;

        public UsersController(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, ICryptoService cryptoService)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.cryptoService = cryptoService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            AuthenticateResponse response = userRepository.Authenticate(model, GetIpAddress());

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            SetTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            string refreshToken = Request.Cookies["refreshToken"];
            AuthenticateResponse response = userRepository.RefreshToken(refreshToken, GetIpAddress());

            if (response == null)
                return Unauthorized(new { message = "Invalid token" });

            SetTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        [HttpPost("revoke-token")]
        public IActionResult RevokeToken([FromBody] RevokeTokenRequest model)
        {
            // accept token from request body or cookie
            string token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            bool response = userRepository.RevokeToken(token, GetIpAddress());

            if (!response)
                return NotFound(new { message = "Token not found" });

            return Ok(new { message = "Token revoked" });
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] StoreUserRequest newUser)
        {
            newUser.Password = cryptoService.Encrypt(newUser.Password);
            User user = mapper.Map<User>(newUser);
            User created = userRepository.Add(user);
            await unitOfWork.CommitAsync();
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequest patchEntity)
        {
            User user = userRepository.GetAll().Where(w=> w.Id == id).AsNoTracking().FirstOrDefault();
            if (user == null) return NotFound();

            User mappUser = mapper.Map<User>(patchEntity);
            mappUser.Id = user.Id;

            IEnumerable<string> properties = PatchProperties(patchEntity);

            User updated = userRepository.Patch(mappUser, properties);

            await unitOfWork.CommitAsync();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            User user = userRepository.GetAll().Where(w => w.Id == id).AsNoTracking().FirstOrDefault();
            if (user == null) return NotFound();

            userRepository.Delete(user);

            await unitOfWork.CommitAsync();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable users = userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User user = userRepository.GetById(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet("{id}/refresh-tokens")]
        public IActionResult GetRefreshTokens(int id)
        {
            User user = userRepository.GetById(id);
            if (user == null) return NotFound();

            return Ok(user.RefreshTokens);
        }

        // helper methods
        private void SetTokenCookie(string token)
        {
            CookieOptions cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string GetIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
