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

var builder = WebApplication.CreateBuilder(args);

var connectionSting = builder.Configuration.GetConnectionString("HospitalDatabase");

builder.Services.AddDbContext<HospitalContext>(options =>
	options.UseMySql(connectionSting, new MySqlServerVersion(new Version(8, 0, 11))));

builder.Services.AddMvc(option => option.EnableEndpointRouting = true);

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IGenericService<Appointment>, GenericService<Appointment>>();
builder.Services.AddScoped<IGenericService<AppointmentDisease>, GenericService<AppointmentDisease>>();
builder.Services.AddScoped<IGenericService<Comment>, GenericService<Comment>>();
builder.Services.AddScoped<IGenericService<Department>, GenericService<Department>>();
builder.Services.AddScoped<IGenericService<Disease>, GenericService<Disease>>();
builder.Services.AddScoped<IGenericService<Employee>, GenericService<Employee>>();
builder.Services.AddScoped<IGenericService<Equipment>, GenericService<Equipment>>();
builder.Services.AddScoped<IGenericService<Gender>, GenericService<Gender>>();
builder.Services.AddScoped<IGenericService<History>, GenericService<History>>();
builder.Services.AddScoped<IGenericService<Instruction>, GenericService<Instruction>>();
builder.Services.AddScoped<IGenericService<Patient>, GenericService<Patient>>();
builder.Services.AddScoped<IGenericService<Payment>, GenericService<Payment>>();
builder.Services.AddScoped<IGenericService<Service>, GenericService<Service>>();

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

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("appointments", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "appointments",
		Title = "Hospital Web API (Appointments)",
		Description = "API для управления информацией о записях на прием"
	});
	c.SwaggerDoc("appointmentDiseases", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "appointmentDiseases",
		Title = "Hospital Web API (AppointmentDiseases)",
		Description = "API для управления информацией из сущности, которая связывает между собой Appointment и Disease"
	});
	c.SwaggerDoc("comments", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "comments",
		Title = "Hospital Web API (Comments)",
		Description = "API для управления информацией о комментариях"
	});
	c.SwaggerDoc("departments", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "departments",
		Title = "Hospital Web API (Departments)",
		Description = "API для управления информацией об отделениях"
	});
	c.SwaggerDoc("diseases", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "diseases",
		Title = "Hospital Web API (Diseases)",
		Description = "API для управления информацией о болезнях"
	});
	c.SwaggerDoc("employees", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "employees",
		Title = "Hospital Web API (Employees)",
		Description = "API для управления информацией о сотрудниках"
	});
	c.SwaggerDoc("equipment", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "equipment",
		Title = "Hospital Web API (Equipment)",
		Description = "API для управления информацией об оборудовании"
	});
	c.SwaggerDoc("genders", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "genders",
		Title = "Hospital Web API (Genders)",
		Description = "API для управления информацией о полах"
	});
	c.SwaggerDoc("histories", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "histories",
		Title = "Hospital Web API (Histories)",
		Description = "API для управления информацией об историях болезни"
	});
	c.SwaggerDoc("instructions", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "instructions",
		Title = "Hospital Web API (Instructions)",
		Description = "API для управления информацией о медицинских инструкциях"
	});
	c.SwaggerDoc("patients", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "patients",
		Title = "Hospital Web API (Patients)",
		Description = "API для управления информацией о пациентах"
	});
	c.SwaggerDoc("payments", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "payments",
		Title = "Hospital Web API (Payments)",
		Description = "API для управления информацией о платежах"
	});
	c.SwaggerDoc("services", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "services",
		Title = "Hospital Web API (Services)",
		Description = "API для управления информацией об услугах"
	});
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Type = SecuritySchemeType.Http,
		Scheme = "bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Name = "Authorization",
		Description = "Введите 'Bearer' [пробел] и затем ваш токен в это поле."
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

app.UseDeveloperExceptionPage();

app.UseStatusCodePages();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/appointments/swagger.json", "Appointments (CRUD Requests)");
	c.SwaggerEndpoint("/swagger/appointmentDiseases/swagger.json", "AppointmentDiseases (CRUD Requests)");
	c.SwaggerEndpoint("/swagger/comments/swagger.json", "Comments (CRUD Requests)");
	c.SwaggerEndpoint("/swagger/departments/swagger.json", "Departments (CRUD Requests)");
	c.SwaggerEndpoint("/swagger/diseases/swagger.json", "Diseases (CRUD Requests)");
	c.SwaggerEndpoint("/swagger/employees/swagger.json", "Employees (CRUD Requests)");
	c.SwaggerEndpoint("/swagger/equipment/swagger.json", "Equipment (CRUD Requests)");
	c.SwaggerEndpoint("/swagger/genders/swagger.json", "Genders (CRUD Requests)");
	c.SwaggerEndpoint("/swagger/histories/swagger.json", "Histories (CRUD Requests)");
	c.SwaggerEndpoint("/swagger/instructions/swagger.json", "Instructions (CRUD Requests)");
	c.SwaggerEndpoint("/swagger/patients/swagger.json", "Patients (CRUD Requests)");
	c.SwaggerEndpoint("/swagger/payments/swagger.json", "Payments (CRUD Requests)");
	c.SwaggerEndpoint("/swagger/services/swagger.json", "Services (CRUD Requests)");
	c.RoutePrefix = String.Empty;
});

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
