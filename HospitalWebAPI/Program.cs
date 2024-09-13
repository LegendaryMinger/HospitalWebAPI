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

var builder = WebApplication.CreateBuilder(args);

var connectionSting = builder.Configuration.GetConnectionString("HospitalDatabase");

builder.Services.AddDbContext<HospitalContext>(options =>
	options.UseMySql(connectionSting, new MySqlServerVersion(new Version(8, 0, 11))));

builder.Services.AddMvc(option => option.EnableEndpointRouting = true);

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

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
	c.SwaggerDoc("appointments", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "appointments",
		Title = "Hospital Web API (Appointments)",
		Description = "API ��� ���������� ����������� � ������� �� �����"
	});
	c.SwaggerDoc("appointmentDiseases", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "appointmentDiseases",
		Title = "Hospital Web API (AppointmentDiseases)",
		Description = "API ��� ���������� ����������� �� ��������, ������� ��������� ����� ����� Appointment � Disease"
	});
	c.SwaggerDoc("comments", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "comments",
		Title = "Hospital Web API (Comments)",
		Description = "API ��� ���������� ����������� � ������������"
	});
	c.SwaggerDoc("departments", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "departments",
		Title = "Hospital Web API (Departments)",
		Description = "API ��� ���������� ����������� �� ����������"
	});
	c.SwaggerDoc("diseases", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "diseases",
		Title = "Hospital Web API (Diseases)",
		Description = "API ��� ���������� ����������� � ��������"
	});
	c.SwaggerDoc("employees", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "employees",
		Title = "Hospital Web API (Employees)",
		Description = "API ��� ���������� ����������� � �����������"
	});
	c.SwaggerDoc("equipment", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "equipment",
		Title = "Hospital Web API (Equipment)",
		Description = "API ��� ���������� ����������� �� ������������"
	});
	c.SwaggerDoc("genders", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "genders",
		Title = "Hospital Web API (Genders)",
		Description = "API ��� ���������� ����������� � �����"
	});
	c.SwaggerDoc("histories", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "histories",
		Title = "Hospital Web API (Histories)",
		Description = "API ��� ���������� ����������� �� �������� �������"
	});
	c.SwaggerDoc("instructions", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "instructions",
		Title = "Hospital Web API (Instructions)",
		Description = "API ��� ���������� ����������� � ����������� �����������"
	});
	c.SwaggerDoc("patients", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "patients",
		Title = "Hospital Web API (Patients)",
		Description = "API ��� ���������� ����������� � ���������"
	});
	c.SwaggerDoc("payments", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "payments",
		Title = "Hospital Web API (Payments)",
		Description = "API ��� ���������� ����������� � ��������"
	});
	c.SwaggerDoc("services", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "services",
		Title = "Hospital Web API (Services)",
		Description = "API ��� ���������� ����������� �� �������"
	});
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Type = SecuritySchemeType.Http,
		Scheme = "bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Name = "Authorization",
		Description = "������� 'Bearer' [������] � ����� ��� ����� � ��� ����."
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
