using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SSMS.API;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

    options.Filters.Add(new AuthorizeFilter(policy));
});

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    //option.SwaggerDoc("v1", new OpenApiInfo { Title = "SSMS", Version = "v1" });
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SSMS API",
        Version = "v1",
        Description = "This is the Swagger documentation for the SSMS API. It provides details about the available endpoints, request/response formats, and more.",
        //Contact = new OpenApiContact
        //{
        //    Name = "Your Name or Team Name",
        //    Email = "your-email@example.com",
        //    Url = new Uri("https://your-website.com")
        //},
        //License = new OpenApiLicense
        //{
        //    Name = "Use under MIT",
        //    Url = new Uri("https://opensource.org/licenses/MIT")
        //},
        //TermsOfService = new Uri("https://your-website.com/terms")
    });

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT Access Token"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});

builder.Services.AddSSMSDI(builder.Configuration);

//// Enable CORS
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowOrigin",
       builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"]!)),
        ClockSkew = TimeSpan.Zero
    };

    options.Events = new JwtBearerEvents
    {
        // Optional: Read token from custom location
        OnMessageReceived = context =>
        {
            return Task.CompletedTask;
        },

        // Token is valid
        OnTokenValidated = context =>
        {
            return Task.CompletedTask;
        },

        // Invalid / Expired Token
        OnAuthenticationFailed = context =>
        {
            if (context.Exception is SecurityTokenExpiredException)
            {
                context.HttpContext.Items["TokenExpired"] = true;
            }

            return Task.CompletedTask;
        },

        // 401 Unauthorized
        OnChallenge = async context =>
        {
            context.HandleResponse();

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";

            string message;

            if (context.HttpContext.Items.ContainsKey("TokenExpired"))
            {
                message = "Token has expired. Please login again.";
            }
            else if (context.AuthenticateFailure != null)
            {
                message = "Invalid JWT token.";
            }
            else
            {
                message = "JWT token is missing.";
            }

            await context.Response.WriteAsJsonAsync(new
            {
                StatusCode = 401,
                Success = false,
                Message = message
            });
        },

        // 403 Forbidden
        OnForbidden = async context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(new
            {
                StatusCode = 403,
                Success = false,
                Message = "You are not authorized to access this resource."
            });
        }
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

//// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowOrigin");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
