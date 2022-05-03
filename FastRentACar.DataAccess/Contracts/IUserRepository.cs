using FastRentACar.Domain.Dto.Request;
using FastRentACar.Domain.Dto.Response;
using FastRentACar.Domain.Models;

namespace FastRentACar.DataAccess.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);

        AuthenticateResponse RefreshToken(string token, string ipAddress);

        bool RevokeToken(string token, string ipAddress);

        User GetById(int id);
    }
}
