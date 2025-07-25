﻿using AutoMapper;
using Mango.Services.ShoppingCartAPI.Models.DTO;
using Mango.Services.ShoppingCartAPI.Models;

namespace Mango.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration
                (config =>
                {
                    config.CreateMap<CartHeader, CartHeaderDto>();
                    config.CreateMap<CartHeaderDto, CartHeader>();
                    config.CreateMap<CartDetails, CartDetailsDto>();
                    config.CreateMap<CartDetailsDto, CartDetails>();
                }
                );
            return mappingConfig;
        }
    }
}
