using Interview.Infrastructure;
using Interview.Infrastructure.Models;
using Interview.Repository.Implements;
using Interview.Repository.Interfaces;
using Interview.Services.Implements;
using Interview.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Interview API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
});
//DB Context
builder.Services.AddDbContext<MyDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//Config Appsetting
ApplicationSettingFactory.InitializeApplicationSettingsFactory(new ApplicationSetting(builder.Configuration));

//Config Dependancy Injection
builder.Services.AddRouting(options => options.LowercaseUrls = true)
                .AddScoped<IApiRepository, ApiRepository>()
                 .AddScoped<IApiServices, ApiServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();