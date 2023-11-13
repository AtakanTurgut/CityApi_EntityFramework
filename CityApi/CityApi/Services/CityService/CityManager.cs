using AutoMapper;
using CityApi.Core;
using CityApi.Core.Dtos.City;
using CityApi.Core.Entities;

namespace CityApi.Services.CityService
{
    public class CityManager : ICityService
    {
        private static List<City> cities = new List<City>
        {
            new City(),
            new City { Id = 1, Name = "Isparta", Region = Core.Enums.RegionOfCity.Akdeniz }
        };

        private readonly IMapper _mapper;

        public CityManager(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CityDto>>> GetAllCityAsync()
        {
            var serviceResponse = new ServiceResponse<List<CityDto>> 
            { 
                Data = cities.Select(c => _mapper.Map<CityDto>(c)).ToList()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<CityDto>> GetOneCityByIdAsync(int id)
        {
            var serviceResponse = new ServiceResponse<CityDto>();
            var city = cities.FirstOrDefault(x => x.Id == id);

            serviceResponse.Data = _mapper.Map<CityDto>(city);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CityDto>>> CreateOneCityAsync(CityDtoForCreate cityDtoForCreate)
        {
            var serviceResponse = new ServiceResponse<List<CityDto>>();
            City city = _mapper.Map<City>(cityDtoForCreate);
            city.Id = cities.Max(x => x.Id) + 1;

            cities.Add(city);

            serviceResponse.Data = cities.Select(c => _mapper.Map<CityDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<CityDto>> UpdateOneCityAsync(CityDtoForUpdate cityDtoForUpdate)
        {
            ServiceResponse<CityDto> serviceResponse = new ServiceResponse<CityDto>();

            try
            {
                City city = cities.FirstOrDefault(c => c.Id == cityDtoForUpdate.Id);

                city.Name = cityDtoForUpdate.Name;
                city.Population = cityDtoForUpdate.Population;
                city.Region = cityDtoForUpdate.Region;

                serviceResponse.Data = _mapper.Map<CityDto>(city);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CityDto>>> DeleteOneCityAsync(int id)
        {
            ServiceResponse<List<CityDto>> serviceResponse = new ServiceResponse<List<CityDto>>();

            try
            {
                City city = cities.First(c => c.Id == id);

                cities.Remove(city);
                serviceResponse.Data = cities.Select(c => _mapper.Map<CityDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

    }
}
