using HospitalWebAPI.Contexts;
using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebAPI.Services
{
	public class UserService : IUserService
	{
		private readonly HospitalContext _context;
		private readonly ITokenService _tokenService;
		public UserService(HospitalContext context, ITokenService tokenService)
		{
			_context = context;
			_tokenService = tokenService;
		}
		public async Task<string> LoginAsync(string login, string password)
		{
			var authUser = await _context.User.SingleOrDefaultAsync(user => user.Login == login);
			if (authUser == null)
			{
				throw new Exception("Invalid login or password");
			}
			var passwordHasher = new PasswordHasher<User>();
			var authResult = passwordHasher.VerifyHashedPassword(authUser, authUser.Password, password);
			if (authResult != PasswordVerificationResult.Success)
			{
				throw new Exception("Invalid login or password");
			}
			var authToken = _tokenService.GenerateToken(login);
			return authToken;
		}
		public async Task<User> RegistrationAsync(string login, string password, string confirmPassword)
		{
			if (password != confirmPassword)
			{
				throw new Exception("Password not equals");
			}
			var regUser = await _context.User.SingleOrDefaultAsync(u => u.Login == login);
			if (regUser != null)
			{
				throw new Exception("User exists");
			}
			var passwordHasher = new PasswordHasher<User>();
			var hashedPassword = passwordHasher.HashPassword(null, password);
			var newUser = new User { Login = login, Password = hashedPassword };
			await _context.AddAsync(newUser);
			await _context.SaveChangesAsync();
			return newUser;
		}
	}
}
