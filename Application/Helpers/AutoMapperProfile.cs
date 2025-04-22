using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User mappings
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));
            CreateMap<CreateUserDto, User>();

            // Customer mappings
            CreateMap<Customer, CustomerDto>();
            CreateMap<Order, OrderSummaryDto>()
                .ForMember(dest => dest.ItemCount, opt => opt.MapFrom(src => src.OrderDetails.Count))
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.ToString()));

            // FoodItem mappings
            CreateMap<FoodItem, FoodItemDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            // Menu mappings
            CreateMap<Menu, MenuDto>();
            CreateMap<MenuFoodItem, MenuFoodItemDto>()
                .ForMember(dest => dest.FoodItemName, opt => opt.MapFrom(src => src.FoodItem.Name))
                .ForMember(dest => dest.FoodItemPrice, opt => opt.MapFrom(src => src.FoodItem.Price));

            // Order mappings
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.ToString()));

            CreateMap<OrderDetail, OrderDetailDto>()
                .ForMember(dest => dest.MenuName, opt => opt.MapFrom(src => src.Menu.Name));

            CreateMap<CreateOrderDto, Order>();
            CreateMap<CreateOrderDetailDto, OrderDetail>();

            // FoodCategory mappings
            CreateMap<FoodCategory, FoodCategoryDto>();
        }
    }
}
