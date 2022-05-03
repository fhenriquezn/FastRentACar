using FastRentACar.DataAccess.Contracts;
using FastRentACar.DataAccess.Core;
using FastRentACar.Domain.Models;

namespace FastRentACar.DataAccess.Repositories
{
    public class OrderRepository : BaseRepository<Order, ApplicationDbContext>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
