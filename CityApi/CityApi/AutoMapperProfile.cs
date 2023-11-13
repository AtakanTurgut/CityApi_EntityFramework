using AutoMapper;
using CityApi.Core.Dtos.City;
using CityApi.Core.Entities;

namespace CityApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<CityDtoForCreate, City>();
        }
    }
}
