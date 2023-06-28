using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Zhipster.Internal.Api.Location.Features.Swagger
{
	public static class SwaggerConfigurator
	{
		public static void ConfigureSwaggerFeature(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Zhipster Internal Location API", Version = "v1" });

            c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
            {
               Name = "Authorization",
               Type = SecuritySchemeType.Http,
               Scheme = "basic",
               In = ParameterLocation.Header,
               Description = "Basic Authorization header using the Bearer scheme."
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
         });
		}
	}
}
