using RestaurantManagement.Application.Interfaces;
using RestaurantManagement.Application.Mappings;
using RestaurantManagement.Application.Services;
using RestaurantManagement.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using RestaurantManagement.Infrastructure.DatabaseConnection;
using RestaurantManagement.Infrastructure.Interfaces;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// Add AutoMapper and configure mapping profiles
services.AddAutoMapper(typeof(MappingProfile));
services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IBillService, BillService>();
services.AddScoped<IBillRepository, BillRepository>();
services.AddScoped<ICustomerService, CustomerService>();
services.AddScoped<ICustomerRepository, CustomerRepository>();
services.AddScoped<IInventoryCostService, InventoryCostService>();
services.AddScoped<IInventoryCostRepository, InventoryCostRepository>();
services.AddScoped<IInventoryService, InventoryService>();
services.AddScoped<IInventoryRepository, InventoryRepository>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IOrderTypeService, OrderTypeService>();
services.AddScoped<IOrderTypeRepository, OrderTypeRepository>();


services.AddScoped<ITableMasterService, TableMasterService>();
services.AddScoped<ITableMasterRepository, TableMasterRepository>();
services.AddScoped<ITableDetailsService, TableDetailsService>();
services.AddScoped<ITableDetailsRepository, TableDetailsRepository>();
services.AddScoped<IDataBaseConnection, DataBaseConnection>();
// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

services.AddLocalization();
services.AddMvc();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestaurantManagement.API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "RestaurantManagement.API Authorization",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestaurantManagement.Service.API v1"));

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.UseCors("MyAllowSpecificOrigins");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

