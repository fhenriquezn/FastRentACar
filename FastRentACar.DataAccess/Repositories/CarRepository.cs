using FastRentACar.DataAccess.Contracts;
using FastRentACar.DataAccess.Core;
using FastRentACar.Domain.Models;

namespace FastRentACar.DataAccess.Repositories
{
    public class CarRepository : BaseRepository<Car, ApplicationDbContext>, ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
