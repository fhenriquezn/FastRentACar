using FastRentACar.DataAccess.Contracts;
using FastRentACar.DataAccess.Core;
using FastRentACar.Domain.Models;

namespace FastRentACar.DataAccess.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetail, ApplicationDbContext>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
