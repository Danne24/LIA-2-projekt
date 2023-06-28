using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Zhipster.Internal.Api.Data.Data;
using Zhipster.Internal.Api.Location.Features.Swagger;
using Zhipster.Internal.Api.Location.Features.UserService;
using Zhipster.Internal.Api.Location.Features.UserService.Models;
using Zhipster.Internal.Api.Location.Services;
using Zhipster.Internal.Api.Location.Services.Bring.BringZipCodeService;
using Zhipster.Internal.Api.Location.Services.BudbeeDropPointService;
using Zhipster.Internal.Api.Location.Services.DHL.DHLFreightSweden.DHLFreightSwedenDropPointService;
using Zhipster.Internal.Api.Location.Services.DHL.DHLFreightSweden.DHLFreightSwedenZipCodeService;
using Zhipster.Internal.Api.Location.Services.DHLParcelConnect.DHLParcelConnectDropPointService;
using Zhipster.Internal.Api.Location.Services.DSVRoadSwedenZipCodeService;
using Zhipster.Internal.Api.Location.Services.ForwarderZipCodeSourceService;
using Zhipster.Internal.Api.Location.Services.GLSDropPointService;
using Zhipster.Internal.Api.Location.Services.PostiDropPointService;
using Zhipster.Internal.Api.Location.Services.PostNordDropPointService;
using Zhipster.Internal.Api.Location.Services.Schenker.SchenkerFinland.SchenkerFinlandDropPointService;
using Zhipster.Internal.Api.Location.Services.Schenker.SchenkerSweden.SchenkerBoxDropPointService;
using Zhipster.Internal.Api.Location.Services.Schenker.SchenkerSweden.SchenkerOmbudDropPointService;
using Zhipster.Internal.Api.Location.Services.SourceService;

namespace Zhipster.Internal.Api.Location
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRouting();
			services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.PropertyNamingPolicy = null;
				options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
				options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
			});

			services.ConfigureSwaggerFeature();
			services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

			#region Register Database

			services.AddDbContext<ZhipsterLocationDbContext>(option =>
			{
				option.UseSqlServer(Configuration.GetConnectionString(nameof(ZhipsterLocationDbContext)));
			});

			#endregion

			#region Register Services

			services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
			services.AddTransient<IZhipsterUserService, ZhipsterUserService>();
			services.AddTransient<IZipCodeService, ZipCodeService>();
			services.AddTransient<IForwarderZipCodeService, ForwarderZipCodeService>();
			services.AddTransient<IDropPointService, DropPointService>();
			services.AddTransient<IBringDropPointService, BringDropPointService>();
			services.AddTransient<IDHLFreightSwedenDropPointService, DHLFreightSwedenDropPointService>();
			services.AddTransient<IDHLParcelConnectDropPointService, DHLParcelConnectDropPointService>();
			services.AddTransient<IPostNordDropPointService, PostNordDropPointService>();
			services.AddTransient<ISchenkerSwedenOmbudDropPointService, SchenkerSwedenOmbudDropPointService>();
			services.AddTransient<ISchenkerSwedenBoxDropPointService, SchenkerSwedenBoxDropPointService>();
			services.AddTransient<ISchenkerFinlandDropPointService, SchenkerFinlandDropPointService>();
			services.AddTransient<IBudbeeDropPointService, BudbeeDropPointService>();
			services.AddTransient<IPostiDropPointService, PostiDropPointService>();
			services.AddTransient<IGLSDropPointService, GLSDropPointService>();
			services.AddTransient<IBringZipCodeService, BringZipCodeService>();
			services.AddTransient<IDHLFreightSwedenZipCodeService, DHLFreightSwedenZipCodeService>();
			services.AddTransient<ICreateSourceService, CreateSourceService>();
			services.AddTransient<IDSVRoadSwedenZipCodeService, DSVRoadSwedenZipCodeService>();

			#endregion
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.DefaultModelsExpandDepth(-1);
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");

				c.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
				{
					["activated"] = false
				};
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}