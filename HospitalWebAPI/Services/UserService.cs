using HospitalWebAPI.Contexts;
using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security;

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
		public async Task<string> LoginAsync(string login, string password, CancellationToken cancellationToken)
		{
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
				throw new ArgumentNullException();

			try
			{
				var authUser = await _context.User.SingleOrDefaultAsync(user => user.Login == login);
				if (authUser == null)
					throw new UnauthorizedAccessException();

				var passwordHasher = new PasswordHasher<User>();
				var authResult = passwordHasher.VerifyHashedPassword(authUser, authUser.Password, password);

				if (authResult != PasswordVerificationResult.Success)
					throw new UnauthorizedAccessException();

				var authToken = _tokenService.GenerateToken(login);
				return authToken;
			}
			catch (UnauthorizedAccessException ex)
			{
				throw new UnauthorizedAccessException();
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}
		public async Task<User> RegistrationAsync(string login, string password, string confirmPassword, CancellationToken cancellationToken)
		{
			try
			{
				if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
					throw new ArgumentNullException();

				if (password != confirmPassword)
					throw new BadHttpRequestException("Bad request");

				var regUser = await _context.User.SingleOrDefaultAsync(u => u.Login == login);
				if (regUser != null)
					throw new SecurityException();

				var passwordHasher = new PasswordHasher<User>();
				var hashedPassword = passwordHasher.HashPassword(null, password);
				var newUser = new User { Login = login, Password = hashedPassword };

				await _context.AddAsync(newUser);
				await _context.SaveChangesAsync();
				return newUser;
			}
			catch (BadHttpRequestException ex)
			{
				throw new BadHttpRequestException("Bad request");
			}
			catch (SecurityException ex)
			{
				throw new SecurityException();
			}
			catch (ArgumentNullException ex)
			{
				throw new ArgumentNullException();
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}
	}
}
