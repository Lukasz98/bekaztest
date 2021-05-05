using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WymianaKsiazek.Api.Database;
using WymianaKsiazek.Api.Database.Entities;
using WymianaKsiazek.Api.Models;

namespace WymianaKsiazek.Api.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OfferEntity, OfferMP>();
                cfg.CreateMap<BookEntity, BookMP>();
                cfg.CreateMap<CategoryEntity, CategoryMP>();
                cfg.CreateMap<AddressEntity, AddressMP>();
                cfg.CreateMap<UserEntity, UserMP>();
                cfg.CreateMap<OfferEntity, UserOffersMP>();
            })
            .CreateMapper();
    }
}
