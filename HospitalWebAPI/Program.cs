using HospitalWebAPI.Classes;
using HospitalWebAPI.Services;
using HospitalWebAPI.Contexts;
using HospitalWebAPI.Controllers;
using HospitalWebAPI.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using HospitalWebAPI.Models;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using HospitalWebAPI.Middlewares;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

var connectionSting = builder.Configuration.GetConnectionString("HospitalDatabase");

builder.Services.AddDbContext<HospitalContext>(options =>
	options.UseMySql(connectionSting, new MySqlServerVersion(new Version(8, 0, 11))));

builder.Services.AddMvc(option => option.EnableEndpointRouting = true);

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IGlobalService, GlobalService>();

builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

builder.Services.AddAutoMapper(typeof(Program));

var mapperConfig = new MapperConfiguration(options =>
{
	options.AddProfile<MappingProfile>();
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	var jwtConfig = builder.Configuration.GetSection("Jwt").Get<JwtConfig>();
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = jwtConfig.Issuer,
		ValidAudience = jwtConfig.Audience,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key))
	};
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
	var swaggerDocs = builder.Configuration.GetSection("Swagger:Docs").Get<List<DocsConfig>>();
	foreach (var doc in swaggerDocs)
	{
		c.SwaggerDoc(doc.Name, new OpenApiInfo
		{
			Version = doc.Version,
			Title = doc.Title,
			Description = doc.Description
		});
	}

	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Type = SecuritySchemeType.Http,
		Scheme = "bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Name = "Authorization",
		Description = "¬ведите 'Bearer' [пробел] и затем ваш токен в это поле."
	});

	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			new List<string>()
		}
	});

	var xmlDocFilePath = Path.Combine(AppContext.BaseDirectory, "HospitalWebAPI.xml");
	c.IncludeXmlComments(xmlDocFilePath);
});

var app = builder.Build();

var swaggerEndpoints = builder.Configuration.GetSection("Swagger:Endpoints").Get<List<EndpointsConfig>>();

if (swaggerEndpoints != null)
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		foreach (var endpoint in swaggerEndpoints)
			c.SwaggerEndpoint(endpoint.Url, endpoint.Description);
		c.RoutePrefix = String.Empty;
	});
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
