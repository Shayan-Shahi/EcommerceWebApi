﻿using AutoMapper;
using Ecommerce.Entities;
using Ecommerce.Entities.Identity;
using Ecommerce.ViewModels.Account;
using Ecommerce.ViewModels.Cart;
using Ecommerce.ViewModels.Products;
using Ecommerce.ViewModels.Users;

namespace Ecommerce.Web.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<RegisterViewModel, User>();
        this.CreateMap<User, ShowUserViewModel>();
        this.CreateMap<Cart, ShowCartPreviewForClientViewModel>();
        this.CreateMap<Product, EditProductViewModel>()
            .ForMember(dest => dest.ProductImages,
                options =>
                    options.MapFrom(src => src.ProductImages.Select(i => i.Title).ToList()))
            .ForMember(dest => dest.CategoryId,
                options =>
                    options.MapFrom(src => src.Category.ParentId ?? 0))
            .ForMember(dest => dest.CategoryChildrenId,
                options =>
                    options.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.Properties,
                options =>
                    options.MapFrom(src => src.ProductProperties.Select(p => p.Title + " ||| " + p.Value).ToList()))
            .ForMember(dest => dest.Tags,
                options =>
                    options.MapFrom(src => src.ProductProductTags.Select(pt => pt.ProductTag.Title).ToList()));
    }
}
