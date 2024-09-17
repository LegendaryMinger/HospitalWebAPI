using HospitalWebAPI.Contexts;
using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Middlewares.Exceptions;
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
			var inputValues = new[] {login, password };
			if (inputValues.Any(string.IsNullOrEmpty))
				throw new ArgumentNullException();

			var authUser = await _context.User.SingleOrDefaultAsync(user => user.Login == login, cancellationToken);
			if (authUser == null)
				throw new AuthorizationException();

			var passwordHasher = new PasswordHasher<User>();
			var authResult = passwordHasher.VerifyHashedPassword(authUser, authUser.Password, password);

			if (authResult != PasswordVerificationResult.Success)
				throw new AuthorizationException();

			var authToken = _tokenService.GetToken(login);
			return authToken;
		}
		public async Task<User> RegistrationAsync(string login, string password, string confirmPassword, CancellationToken cancellationToken)
		{
			var inputValues = new[] { login, password, confirmPassword };
			if (inputValues.Any(string.IsNullOrEmpty))
				throw new ArgumentNullException();

			if (password != confirmPassword)
				throw new PasswordConfirmationException();

			var regUser = await _context.User.SingleOrDefaultAsync(u => u.Login == login, cancellationToken);
			if (regUser != null)
				throw new UserArleadyExistsException();

			var passwordHasher = new PasswordHasher<User>();
			var hashedPassword = passwordHasher.HashPassword(null, password);
			var newUser = new User { Login = login, Password = hashedPassword };

			await _context.AddAsync(newUser);
			await _context.SaveChangesAsync(cancellationToken);
			return newUser;
		}
	}
}
