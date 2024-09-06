var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "v1",
		Title = "Hospital Web API (Data Retrieval)",
		Description = "API ��� ���������� ������ � ����������� ����������, ������� ������ �� ����������, ������������, � �����������, ���������, �� �����������, �������� �������, �������, � ��������, ������� �� �����, ��������"
	});
	c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "v2",
		Title = "Hospital Web API (User System)",
		Description = "API ��� ���������� ��������������"
	});
	var xmlDocFilePath = Path.Combine(AppContext.BaseDirectory, "HospitalWebAPI.xml");
	c.IncludeXmlComments(xmlDocFilePath);
});

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseStatusCodePages();

app.UseMvcWithDefaultRoute();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Data Retrieval (Get Requests)");
	c.SwaggerEndpoint("/swagger/v2/swagger.json", "Users System (Post Requests) ");
});

app.Run();
