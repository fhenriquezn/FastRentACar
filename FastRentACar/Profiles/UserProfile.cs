using AutoMapper;
using FastRentACar.Domain.Models;
using FastRentACar.Dto;

namespace FastRentACar.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, StoreUserRequest>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();
        }
    }
}
