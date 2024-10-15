using AutoMapper;
using E_Commerce_Backend.DTO;
using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
