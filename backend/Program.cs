using System.ComponentModel;
using System.Net;
using backend.DBContext;
using backend.Interfaces;
using backend.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = "_myAllowOrigins";

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();

//swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Version = "v1",
            Title = "ProjectManagementApi",
            Description = "",
            TermsOfService = new Uri("https://try.com"),
            Contact = new OpenApiContact { Name = "", Url = new Uri("https://try.com") },
            License = new OpenApiLicense
            {
                Name = "Example Licence",
                Url = new Uri("https://try.com"),
            },
        }
    );

    options.AddSecurityDefinition(
        "google_oauth",
        new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.OAuth2,
            Flows = new OpenApiOAuthFlows
            {
                AuthorizationCode = new OpenApiOAuthFlow
                {
                    AuthorizationUrl = new Uri("https://accounts.google.com/o/oauth2/v2/auth"),
                    TokenUrl = new Uri("https://oauth2.googleapis.com/token"),
                    Scopes = new Dictionary<string, string>
                    {
                        { "openid", "OpenId" },
                        { "email", "User Email" },
                        { "profile", "User Profile" },
                    },
                },
            },
        }
    );

    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "google_oauth",
                    },
                },
                new[] { "openid", "email", "profile" }
            },
        }
    );
});

//for the database

builder.Services.AddDbContext<ProjectManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

//for communicating with other origins
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: allowedOrigins,
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    );
});

//for mediatr
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

//for Oauth
builder
    .Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddGoogle(googleOptions =>
    {
        Console.WriteLine(builder.Configuration["Authentication:Google:ClientId"]);
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
    });

//for DI
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectTasksRepository, ProjectTaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger(options =>
    {
        //options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        //options.RoutePrefix = string.Empty;

        options.OAuthClientId(builder.Configuration["Authentication:Google:ClientId"]);
        options.OAuthClientSecret(builder.Configuration["Authentication:Google:ClientSecret"]);
        options.OAuthUsePkce();
        options.OAuth2RedirectUrl("https://localhost:7204/swagger/oauth2-redirect.html");
    });
}
app.UseHttpsRedirection();
app.UseCors(allowedOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
