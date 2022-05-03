using AutoMapper;
using FastRentACar.Domain.Models;
using FastRentACar.Dto;

namespace FastRentACar.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, StoreCarRequest>().ReverseMap();
            CreateMap<Car, UpdateCarRequest>().ReverseMap();
        }
    }
}
