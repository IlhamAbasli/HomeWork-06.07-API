using AutoMapper;
using Domain.Entities;
using Service.DTOs.Cities;
using Service.DTOs.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country,CountryDto>();    
            CreateMap<CountryCreateDto,Country>();
            CreateMap<CountryEditDto,Country>();
            CreateMap<CountryEditDto,Country>().ReverseMap();
            CreateMap<Country, CountryByCitiesDto>().ForMember(dest =>dest.Cities, opt => opt.MapFrom(src => src.Cities.Select(m => m.Name)));

            CreateMap<City, CityDto>().ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<CityCreateDto, City>();
        }
    }
}
