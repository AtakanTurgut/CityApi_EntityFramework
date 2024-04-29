using CityApi.Core;
using CityApi.Core.Dtos.City;
using CityApi.Core.Entities;
using CityApi.Services.CityService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityApi.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CityDto>>>> GetAllCityAsync() 
        {
            var cities = await _cityService.TGetAllCityAsync();

            return Ok(cities);
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<CityDto>>> GetOneCityByIdAsync(int id)
        {
            var city = await _cityService.TGetOneCityByIdAsync(id);

            return Ok(city);    
        }

        [HttpGet("user")]
        public async Task<ActionResult<ServiceResponse<List<CityDto>>>> GetAllCityByUserIdAsync()
        {
            var cities = await _cityService.TGetAllCityByUserIdAsync();

            return Ok(cities);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CityDto>>>> CreateOneCityAsync(CityDtoForCreate cityDtoForCreate)
        {
            var city = await _cityService.TCreateOneCityAsync(cityDtoForCreate);

            return Ok(city);
        }

        // PUT
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<CityDto>>> UpdateOneCityAsync(CityDtoForUpdate cityDtoForUpdate)
        {
            var response = await _cityService.TUpdateOneCityAsync(cityDtoForUpdate);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<List<CityDto>>>> DeleteOneCityAsync(int id)
        {
            var response = await _cityService.TDeleteOneCityAsync(id);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

    }
}
