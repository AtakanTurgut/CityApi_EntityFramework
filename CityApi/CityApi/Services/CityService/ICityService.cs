using CityApi.Core;
using CityApi.Core.Dtos.City;
using CityApi.Core.Entities;

namespace CityApi.Services.CityService
{
    public interface ICityService
    {
        Task<ServiceResponse<List<CityDto>>> TGetAllCityAsync();
        Task<ServiceResponse<CityDto>> TGetOneCityByIdAsync(int id);
        Task<ServiceResponse<List<CityDto>>> TGetAllCityByUserIdAsync();

        Task<ServiceResponse<List<CityDto>>> TCreateOneCityAsync(CityDtoForCreate cityDtoForCreate);
        Task<ServiceResponse<CityDto>> TUpdateOneCityAsync(CityDtoForUpdate cityDtoForUpdate);
        Task<ServiceResponse<List<CityDto>>> TDeleteOneCityAsync(int id);
    }
}
