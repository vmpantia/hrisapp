using System.Text;
using HRIS.Shared.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace HRIS.Api;

public static class ServiceCollectionExtension
{
    public static void AddSwaggerGenWithAuth(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));

            var securitySchema = new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Enter your JWT Token in this field",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT"
            };

            opt.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchema);

            var securityRequirement = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    []
                }
            };

            opt.AddSecurityRequirement(securityRequirement);
        });
    }

    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSetting = JwtSetting.FromConfiguration(configuration);
        services.AddSingleton(jwtSetting);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Secret)),
                    ValidIssuer = jwtSetting.Issuer,
                    ValidAudience = jwtSetting.Audience,
                    ClockSkew = TimeSpan.Zero
                };
            });
    }
}