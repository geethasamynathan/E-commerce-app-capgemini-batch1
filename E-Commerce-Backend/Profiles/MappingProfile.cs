using AutoMapper;
using E_Commerce_Backend.DTO;
using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();

            CreateMap<UserProduct, UserProductDTO>().ReverseMap();
        }
    }
}
