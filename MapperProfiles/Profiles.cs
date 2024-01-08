﻿using AutoMapper;
using SimpleCRUD_MVC.Business.Models.Input;
using SimpleCRUD_MVC.Business.Models.Output;
using SimpleCRUD_MVC.Data.Models;

namespace SimpleCRUD_MVC.MapperProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<ProductInput, Product>();
            CreateMap<Product, ProductOutput>();

            CreateMap<ClientInput, Client>();
            CreateMap<Client, ClientOutput>();

            CreateMap<OrderInput, Order>();
            CreateMap<Order, OrderOutput>()
                .ForMember( x => x.ClientLastName, cfg => cfg.MapFrom(src => src.Client.LastName))
                .ForMember( x => x.ClientFirstName, cfg => cfg.MapFrom(src => src.Client.FirstName));

            CreateMap<OrderItemInput, OrderItem>();
            CreateMap<OrderItem, OrderItemOutput>()
                .ForMember(x => x.ProductName, cfg => cfg.MapFrom(src => src.Product.Name));
        }
    }
}