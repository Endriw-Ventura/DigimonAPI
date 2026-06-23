using DigimonAPI.Application.Interfaces;
using DigimonAPI.Application.Services;
using DigimonAPI.Infrastructure.Integrations.DigimonIntegration;
using DigimonAPI.Infrastructure.Repositories.DigimonRepository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHttpClient<IDigimonIntegration, DigimonIntegration>((client) =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("ExternalApis:DigimonApi:baseUrl").Value!);
});
builder.Services.AddScoped<IDigimonService, DigimonService>();
builder.Services.AddScoped<IDigimonRepository, DigimonRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5173")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
var app = builder.Build();


//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
