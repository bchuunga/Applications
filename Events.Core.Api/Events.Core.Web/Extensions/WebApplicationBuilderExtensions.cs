using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Events.Core.Web.Helpers;

namespace Events.Core.Web.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddAppAuthentication(this WebApplicationBuilder builder)
        {
            var jwtOptions = new JwtOptions();
            builder.Configuration.GetSection("Jwt").Bind(jwtOptions);
            builder.Services.AddSingleton(jwtOptions);

            var key = Encoding.ASCII.GetBytes(jwtOptions.JwtKey);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.JwtAudience,
                    ValidAudience = jwtOptions.JwtAudience,
                    ValidateAudience = true
                };
            });

            return builder;
        }
    }
}
