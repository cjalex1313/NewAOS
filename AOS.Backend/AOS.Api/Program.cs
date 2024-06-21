using AABC.IdentityServer.Client;
using AOS.Api.Config;
using AOS.Api.Middleware;
using Microsoft.OpenApi.Models;
using AOS.BusinessLogic;
using Microsoft.AspNetCore.Identity;
using AOS.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      new string[] { }
    }
  });
});
builder.Services.AddCors(setupAction =>
{
    setupAction.AddDefaultPolicy(policy => policy.AllowAnyMethod()
                                                .AllowAnyHeader()
                                                .AllowCredentials()
                                                .SetIsOriginAllowed(x => true));
});

var applicationSettings = builder.Configuration.GetSection("ApplicationSettings").Get<ApplicationSettings>();
if (applicationSettings == null)
{
    throw new Exception("Unable to serialize appsettings");
}
builder.Services.AddSingleton(applicationSettings);
builder.Services.AddSingleton(applicationSettings.IdentityServer);
builder.Services.AddScoped<IIdentityServerClient, IdentityServerClient>();
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.Authority = applicationSettings.IdentityServer.BaseUrl;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateAudience = false
    };
});
builder.Services.AddBusinessLogic(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.UseMiddleware<UserIdMiddleware>();

app.MapControllers();

using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var petDbContext = scope.ServiceProvider.GetService<AOSDbContext>();
    if (petDbContext == null)
    {
        throw new Exception("Cannot initialize dbContext");
    }
    petDbContext.Database.Migrate();
}

app.Run();
