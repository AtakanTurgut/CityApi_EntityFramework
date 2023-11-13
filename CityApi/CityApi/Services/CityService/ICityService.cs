using CityApi.Core;
using CityApi.Core.Dtos.City;
using CityApi.Core.Entities;

namespace CityApi.Services.CityService
{
    public interface ICityService
    {
        Task<ServiceResponse<List<CityDto>>> GetAllCityAsync();
        Task<ServiceResponse<CityDto>> GetOneCityByIdAsync(int id);

        Task<ServiceResponse<List<CityDto>>> CreateOneCityAsync(CityDtoForCreate cityDtoForCreate);
        Task<ServiceResponse<CityDto>> UpdateOneCityAsync(CityDtoForUpdate cityDtoForUpdate);
        Task<ServiceResponse<List<CityDto>>> DeleteOneCityAsync(int id);
    }
}
