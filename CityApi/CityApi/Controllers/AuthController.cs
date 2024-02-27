using CityApi.Core;
using CityApi.Core.Dtos.User;
using CityApi.Core.Entities;
using CityApi.Data.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthRepository _authRepository;

		public AuthController(IAuthRepository authRepository)
		{
			_authRepository = authRepository;
		}

		[HttpPost("register")]
		public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto userRegisterDto)
		{
			var response = await _authRepository.Register(
				new User { Username = userRegisterDto.Username }, userRegisterDto.Password
			);

			if (!response.Success)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}

		[HttpPost("login")]
		public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto userLoginDto)
		{
			var response = await _authRepository.Login(userLoginDto.Username, userLoginDto.Password);

			if (!response.Success)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}

	}
}
