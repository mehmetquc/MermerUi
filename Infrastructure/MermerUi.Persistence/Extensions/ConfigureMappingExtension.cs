using AutoMapper;
using MermerUi.Application.DTOs;
using MermerUi.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Extensions
{
    public static class ConfigureMappingExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

            CreateMap<Anasayfa, AnasayfaDTO>().ReverseMap();
            CreateMap<Ayricaliklarimiz, AyricaliklarimizDTO>().ReverseMap();
            CreateMap<DetaylıUrun, DetaylıUrunDTO>().ReverseMap();
            CreateMap<Hakkimizda, HakkimizdaDTO>().ReverseMap();
            CreateMap<Header, HeaderDTO>().ReverseMap();
            CreateMap<Referans, ReferansDTO>().ReverseMap();
            CreateMap<Urunlerimiz, UrunlerimizDTO>().ReverseMap();

            CreateMap<User, UserDTO>()
                .ForMember(c => c.FullName, y => y.MapFrom(y => y.FirstName + " " + y.LastName));
            CreateMap<UserDTO, User>();

            CreateMap<YıldızUrun, YıldızUrunDTO>().ReverseMap();
            CreateMap<Yorum, YorumDTO>().ReverseMap();



        }
    }
}   

