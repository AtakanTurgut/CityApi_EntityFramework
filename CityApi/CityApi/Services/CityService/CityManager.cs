using AutoMapper;
using CityApi.Core;
using CityApi.Core.Dtos.City;
using CityApi.Core.Entities;
using CityApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CityApi.Services.CityService
{
    public class CityManager : ICityService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CityManager(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
		{
			_mapper = mapper;
			_context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

		public async Task<ServiceResponse<List<CityDto>>> TGetAllCityAsync()
        {
            var response = new ServiceResponse<List<CityDto>>();
            var dbCities = await _context.Cities.ToListAsync();
            response.Data = dbCities.Select(c => _mapper.Map<CityDto>(c)).ToList();

            return response;
        }

        public async Task<ServiceResponse<List<CityDto>>> TGetAllCityByUserIdAsync()
        {
            var response = new ServiceResponse<List<CityDto>>();
            var dbCities = await _context.Cities
                .Where(x => x.User.Id == GetUserId())
                .ToListAsync();
            response.Data = dbCities.Select(c => _mapper.Map<CityDto>(c)).ToList();

            return response;
        }

        public async Task<ServiceResponse<CityDto>> TGetOneCityByIdAsync(int id)
        {
            var response = new ServiceResponse<CityDto>();
            var dbCity = await _context.Cities.FirstOrDefaultAsync(x => x.Id == id);

			response.Data = _mapper.Map<CityDto>(dbCity);

            return response;
        }

        public async Task<ServiceResponse<List<CityDto>>> TCreateOneCityAsync(CityDtoForCreate cityDtoForCreate)
        {
            var response = new ServiceResponse<List<CityDto>>();
            City city = _mapper.Map<City>(cityDtoForCreate);

            city.User = await _context.Users.FirstOrDefaultAsync(x => x.Id == GetUserId());

            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

			response.Data = await _context.Cities
                .Where(x => x.User.Id == GetUserId())
                .Select(c => _mapper.Map<CityDto>(c))
                .ToListAsync();

            return response;
        }

        public async Task<ServiceResponse<CityDto>> TUpdateOneCityAsync(CityDtoForUpdate cityDtoForUpdate)
        {
            ServiceResponse<CityDto> response = new ServiceResponse<CityDto>();

            try
            {
                City city = await _context.Cities.FirstOrDefaultAsync(c => c.Id == cityDtoForUpdate.Id);

                city.Name = cityDtoForUpdate.Name;
                city.Population = cityDtoForUpdate.Population;
                city.Region = cityDtoForUpdate.Region;

                await _context.SaveChangesAsync();

				response.Data = _mapper.Map<CityDto>(city);
            }
            catch (Exception ex)
            {
				response.Success = false;
				response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<CityDto>>> TDeleteOneCityAsync(int id)
        {
            ServiceResponse<List<CityDto>> response = new ServiceResponse<List<CityDto>>();

            try
            {
                City city = await _context.Cities.FirstAsync(c => c.Id == id);

                _context.Cities.Remove(city);

                await _context.SaveChangesAsync();

				response.Data = await _context.Cities.Select(c => _mapper.Map<CityDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
				response.Success = false;
				response.Message = ex.Message;
            }

            return response;
        }
    }
}
