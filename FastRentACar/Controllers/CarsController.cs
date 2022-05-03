using AutoMapper;
using FastRentACar.DataAccess.Contracts;
using FastRentACar.Domain.Models;
using FastRentACar.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastRentACar.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : BaseController<UpdateCarRequest>
    {
        private readonly ICarRepository carRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CarsController(ICarRepository carRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.carRepository = carRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable cars = carRepository.GetAll();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Car car = await carRepository.FindAsync(id);
            if (car == null) return NotFound();

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Store([FromBody] StoreCarRequest newCar)
        {
            Car car = mapper.Map<Car>(newCar);
            Car created = carRepository.Add(car);
            await unitOfWork.CommitAsync();
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCarRequest patchEntity)
        {
            Car car = carRepository.GetAll().Where(w => w.Id == id).AsNoTracking().FirstOrDefault();
            if (car == null) return NotFound();

            Car mappCar = mapper.Map<Car>(patchEntity);
            mappCar.Id = car.Id;

            IEnumerable<string> properties = PatchProperties(patchEntity);

            Car updated = carRepository.Patch(mappCar, properties);

            await unitOfWork.CommitAsync();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            Car car = carRepository.GetAll().Where(w => w.Id == id).AsNoTracking().FirstOrDefault();
            if (car == null) return NotFound();

            carRepository.Delete(car);

            await unitOfWork.CommitAsync();

            return Ok();
        }
    }
}
