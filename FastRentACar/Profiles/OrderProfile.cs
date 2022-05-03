using AutoMapper;
using FastRentACar.Domain.Models;
using FastRentACar.Dto;

namespace FastRentACar.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, StoreOrderRequest>().ReverseMap();
            CreateMap<Order, UpdateOrderRequest>().ReverseMap();
        }
    }
}
