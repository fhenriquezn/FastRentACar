using AutoMapper;
using FastRentACar.Domain.Models;
using FastRentACar.Dto;

namespace FastRentACar.Profiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, StoreOrderDetailRequest>().ReverseMap();
            //CreateMap<Order, UpdateOrderRequest>().ReverseMap();
        }
    }
}
