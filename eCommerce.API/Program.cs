using eCommerce.API.Middlewares;
using eCommerce.API.ValidationFilter;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(ValidationFilter)); // generic filter

//Add services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controllers to the service collection
builder.Services.AddConnections();

builder.Services.AddControllers().AddJsonOptions
    (options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

builder.Services.AddAutoMapper(cfg => { }, typeof(ApplicationUserMappingProfile).Assembly);

//Add API exolorer services
builder.Services.AddEndpointsApiExplorer();

//Add swagger generatoion services to create  swagger specification
builder.Services.AddSwaggerGen();

//Add cors services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

//Build the web application
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//Rouing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger(); //Adds endpoint that can serve the generated swagger as a JSON endpoint (swagger.Json)
app.UseSwaggerUI(); //Adds a swagger UI (interactive page  to explore and test API endpoints

app.UseCors();

//Controller routes
app.MapControllers();

app.Run();
