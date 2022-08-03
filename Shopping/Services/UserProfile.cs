using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shopping.DTO;
using Shopping.Models;
using System.Security.Claims;

namespace Shopping.Services
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<Government, GovernmentDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<Powers,PowerDTO>().ReverseMap();
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<IdentityRole, RoleDTO>().ReverseMap();
            CreateMap<ClaimsPrincipal, AppUser>().ReverseMap();





        }
    }
}
