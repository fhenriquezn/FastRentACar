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
    public class OrdersController : BaseController<UpdateOrderRequest>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository detailRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrdersController(IOrderRepository orderRepository, IOrderDetailRepository detailRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.detailRepository = detailRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable Orders = orderRepository.GetAll();
            return Ok(Orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Order Order = await orderRepository.FindAsync(id);
            if (Order == null) return NotFound();

            Order completeOrder = await orderRepository.Include(p => p.Id == id, p => p.OrderDetails).FirstAsync();

            return Ok(completeOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Store([FromBody] StoreOrderRequest newOrder)
        {
            Order Order = mapper.Map<Order>(newOrder);
            Order created = orderRepository.Add(Order);
            await unitOfWork.CommitAsync();
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderRequest patchEntity)
        {
            Order Order = orderRepository.GetAll().Where(w => w.Id == id).AsNoTracking().FirstOrDefault();
            if (Order == null) return NotFound();

            Order mappOrder = mapper.Map<Order>(patchEntity);
            mappOrder.Id = Order.Id;

            IEnumerable<string> properties = PatchProperties(patchEntity);

            Order updated = orderRepository.Patch(mappOrder, properties);

            await unitOfWork.CommitAsync();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            Order Order = orderRepository.GetAll().Where(w => w.Id == id).AsNoTracking().FirstOrDefault();
            if (Order == null) return NotFound();

            orderRepository.Delete(Order);

            await unitOfWork.CommitAsync();

            return Ok();
        }

        [HttpPost("{id}/item")]
        public async Task<IActionResult> AddOrderDetail(int id, [FromBody] StoreOrderDetailRequest newItem)
        {
            Order Order = orderRepository.GetAll().Where(w => w.Id == id).AsNoTracking().FirstOrDefault();
            if (Order == null) return NotFound();

            OrderDetail mappDetail = mapper.Map<OrderDetail>(newItem);
            mappDetail.OrderId = Order.Id;

            OrderDetail created = detailRepository.Add(mappDetail);

            await unitOfWork.CommitAsync();

            return Ok(created);
        }

        [HttpDelete("{id}/item/{itemId}")]
        public async Task<IActionResult> Destroy(int id, int itemId)
        {
            Order Order = orderRepository.GetAll().Where(w => w.Id == id).AsNoTracking().FirstOrDefault();
            if (Order == null) return NotFound();

            OrderDetail detail = detailRepository.GetAll().Where(w => w.Id == id).AsNoTracking().FirstOrDefault();
            if (detail == null) return NotFound();

            detailRepository.Delete(detail);

            await unitOfWork.CommitAsync();

            return Ok();
        }
    }
}
