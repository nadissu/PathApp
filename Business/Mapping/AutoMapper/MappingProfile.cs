using AutoMapper;
using Business.Domain.DTOs;
using Business.Domain.Requests;
using Business.Domain.Responses;
using Entities.Concrete;
using Entities.DTOs.Responses;

namespace Business.Mapping.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, AddProductRequest>().ReverseMap();

            CreateMap<Product, GetAllProductResponse>().ReverseMap();

            CreateMap<Order, AddOrderRequest>().ReverseMap();

            CreateMap<OrderProduct, AddOrderRequest>().ReverseMap();

            CreateMap<OrderProductDto, AddOrderProductRequest>().ReverseMap();

            CreateMap<OrderProduct, AddOrderProductRequest>().ReverseMap();

            CreateMap<UserDetailsDto, UserDetailsDto>().ReverseMap();

            CreateMap<OrderDetailsDto, OrderDetailsDto>().ReverseMap();
        }
    }
}

