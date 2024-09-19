using Events.Core.Web.Constatnts.ApiClient;
using Events.Core.Web.Extensions;
using Events.Core.Web.Helpers;
using Events.Core.Web.Services;
using Events.Core.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var corsPolicy = "_corsPolicy";

var serviceUrlOptions = new ServiceUrlOptions();
builder.Configuration.GetSection("ServiceUrl").Bind(serviceUrlOptions);
builder.Services.AddSingleton(serviceUrlOptions);

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, policyBuilder =>
    {
        policyBuilder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:4200");
    });
});

builder.Services.AddScoped<ILectureService, LectureService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IMeetupService, MeetupService>();

builder.Services.AddHttpClient(EventsCoreWebHttpClients.EventsCoreApiClient, x => x.BaseAddress
    = new Uri(serviceUrlOptions.EventsApi));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id=JwtBearerDefaults.AuthenticationScheme
                }
            }, new string[]{}
        }
    });
});
builder.AddAppAuthentication();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors(corsPolicy);

app.MapControllers();

app.Run();
