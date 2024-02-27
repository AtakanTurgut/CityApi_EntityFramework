using CityApi.Core;
using CityApi.Core.Entities;
using CityApi.Data.Abstract;

namespace CityApi.Data.Concrete
{
	public class AuthRepository : IAuthRepository
	{
		private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<string>> Login(string username, string password)
		{
			throw new NotImplementedException();
		}

		public async Task<ServiceResponse<int>> Register(User user, string password)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UserExists(string username)
		{
			throw new NotImplementedException();
		}
	}
}
