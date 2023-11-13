using CityApi.Core;
using CityApi.Core.Dtos.City;
using CityApi.Core.Entities;
using CityApi.Services.CityService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityApi.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CityDto>>>> GetAllCityAsync() 
        {
            var cities = await _cityService.GetAllCityAsync();

            return Ok(cities);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<CityDto>>> GetOneCityByIdAsync(int id)
        {
            var city = await _cityService.GetOneCityByIdAsync(id);

            return Ok(city);    
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CityDto>>>> CreateOneCityAsync(CityDtoForCreate cityDtoForCreate)
        {
            var city = await _cityService.CreateOneCityAsync(cityDtoForCreate);

            return Ok(city);
        }

        // PUT
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<CityDto>>> UpdateOneCityAsync(CityDtoForUpdate cityDtoForUpdate)
        {
            var response = await _cityService.UpdateOneCityAsync(cityDtoForUpdate);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<List<CityDto>>>> DeleteOneCityAsync(int id)
        {
            var response = await _cityService.DeleteOneCityAsync(id);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

    }
}
