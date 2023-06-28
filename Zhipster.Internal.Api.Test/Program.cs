using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Zhipster.Internal.Api.Data.Data;
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
using Zhipster.Internal.Api.Test.Models.Bring;

namespace Zhipster.Internal.Api.Test
{
	public class Program
	{
		private readonly IDHLFreightSwedenZipCodeService _dhlZipCodeService;
		private readonly IBringZipCodeService _bringZipCodeService;
		private readonly IDSVRoadSwedenZipCodeService _dsvRoadSwedenZipCodeService;
		private readonly ICreateSourceService _createSourceService;
		private readonly IForwarderZipCodeService _forwarderZipCodeService;
		private readonly IDropPointService _dropPointService;
		private readonly IBringDropPointService _bringDropPointService;
		private readonly IDHLFreightSwedenDropPointService _dhlFreightSwedendropPointService;
		private readonly IDHLParcelConnectDropPointService _dhlParcelConnectDropPointService;
		private readonly IPostNordDropPointService _postNordDropPointService;
		private readonly ISchenkerSwedenOmbudDropPointService _schenkerOmbudDropPointService;
		private readonly ISchenkerSwedenBoxDropPointService _schenkerBoxDropPointService;
		private readonly ISchenkerFinlandDropPointService _schenkerFinlandDropPointService;
		private readonly IBudbeeDropPointService _budbeeDropPointService;
		private readonly IPostiDropPointService _postiDropPointService;
		private readonly IGLSDropPointService _glsDropPointService;
		private readonly ZhipsterLocationDbContext _zhipsterLocationDbContext;

		public Program(ZhipsterLocationDbContext zhipsterLocationDbContext, IBringZipCodeService bringZipCodeService, IDHLFreightSwedenZipCodeService dhlZipCodeService, ICreateSourceService createSourceService, IDSVRoadSwedenZipCodeService dsvRoadSwedenZipCodeService, IForwarderZipCodeService forwarderZipCodeService, IDropPointService dropPointService, IBringDropPointService bringDropPointService, IDHLFreightSwedenDropPointService dhlFreightSwedendropPointService, IDHLParcelConnectDropPointService dhlParcelConnectDropPointService, IPostNordDropPointService postNordDropPointService, ISchenkerSwedenOmbudDropPointService schenkerOmbudDropPointService, ISchenkerSwedenBoxDropPointService schenkerBoxDropPointService, ISchenkerFinlandDropPointService schenkerFinlandDropPointService, IBudbeeDropPointService budbeeDropPointService, IPostiDropPointService postiDropPointService, IGLSDropPointService glsDropPointService)
		{
			_zhipsterLocationDbContext = zhipsterLocationDbContext;
			_bringZipCodeService = bringZipCodeService;
			_dhlZipCodeService = dhlZipCodeService;
			_createSourceService = createSourceService;
			_forwarderZipCodeService = forwarderZipCodeService;
			_dsvRoadSwedenZipCodeService = dsvRoadSwedenZipCodeService;
			_dropPointService = dropPointService;
			_bringDropPointService = bringDropPointService;
			_dhlFreightSwedendropPointService = dhlFreightSwedendropPointService;
			_dhlParcelConnectDropPointService = dhlParcelConnectDropPointService;
			_postNordDropPointService = postNordDropPointService;
			_schenkerOmbudDropPointService = schenkerOmbudDropPointService;
			_schenkerBoxDropPointService = schenkerBoxDropPointService;
			_schenkerFinlandDropPointService = schenkerFinlandDropPointService;
			_budbeeDropPointService = budbeeDropPointService;
			_postiDropPointService = postiDropPointService;
			_glsDropPointService = glsDropPointService;
		}

		public async Task RunTestCodeAsync()
		{
			#region Test Code

			//	await _dsvRoadSwedenZipCodeService.InstallZipCodes();

			await _forwarderZipCodeService.InstallForwarderZipCodeSources();

			#endregion
		}

		public static async Task Main(string[] args)
		{
			var services = ConfigureServices();
			var serviceProvider = services.BuildServiceProvider();
			await serviceProvider.GetService<Program>().RunTestCodeAsync();
		}

		private static IServiceCollection ConfigureServices()
		{
			var services = new ServiceCollection();
			var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false).Build();
			services.AddSingleton(config);
			services.AddDbContext<ZhipsterLocationDbContext>(options =>
			{
				options.UseSqlServer(config.GetConnectionString(nameof(ZhipsterLocationDbContext)));
			});

			services.AddTransient<IBringZipCodeService, BringZipCodeService>();
			services.AddTransient<IDHLFreightSwedenZipCodeService, DHLFreightSwedenZipCodeService>();
			services.AddTransient<IDSVRoadSwedenZipCodeService, DSVRoadSwedenZipCodeService>();
			services.AddTransient<ICreateSourceService, CreateSourceService>();
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
			services.AddTransient<Program>();

			return services;
		}

		private static async Task TestBringSweden()
		{
			try
			{
				var endpoint = "https://api.bring.com/address/api/SE/postal-codes";
				var client = new HttpClient
				{
					BaseAddress = new Uri(endpoint),
					Timeout = TimeSpan.FromSeconds(60),
				};
				var serializerSettings = new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					DefaultValueHandling = DefaultValueHandling.Include,
				};
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("X-Mybring-API-Uid", "developer@zhipster.se");
				client.DefaultRequestHeaders.Add("X-Mybring-API-Key", "6ac118e3-70be-4db1-a2c5-8237aff378e2");
				client.DefaultRequestHeaders.Add("X-Bring-Client-URL", "http://exant.se/");
				var apiHttpResult = await client.GetAsync(endpoint);
				if (apiHttpResult.IsSuccessStatusCode)
				{
					var json = await apiHttpResult.Content.ReadAsStringAsync();
					var postalCodes = JsonConvert.DeserializeObject<BringPostalCodesResponseJSON>(json);
				}
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}
		}

		private static async Task TestBringNorway()
		{
			try
			{
				var endpoint = "https://api.bring.com/address/api/NO/postal-codes";
				var client = new HttpClient
				{
					BaseAddress = new Uri(endpoint),
					Timeout = TimeSpan.FromSeconds(60),
				};
				var serializerSettings = new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					DefaultValueHandling = DefaultValueHandling.Include,
				};
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("X-Mybring-API-Uid", "developer@zhipster.se");
				client.DefaultRequestHeaders.Add("X-Mybring-API-Key", "6ac118e3-70be-4db1-a2c5-8237aff378e2");
				client.DefaultRequestHeaders.Add("X-Bring-Client-URL", "http://exant.se/");
				var apiHttpResult = await client.GetAsync(endpoint);
				if (apiHttpResult.IsSuccessStatusCode)
				{
					var json = await apiHttpResult.Content.ReadAsStringAsync();
					var postalCodes = JsonConvert.DeserializeObject<BringPostalCodesResponseJSON>(json);
				}
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}
		}

		private static async Task TestBringDenmark()
		{
			try
			{
				var endpoint = "https://api.bring.com/address/api/DK/postal-codes";
				var client = new HttpClient
				{
					BaseAddress = new Uri(endpoint),
					Timeout = TimeSpan.FromSeconds(60),
				};
				var serializerSettings = new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					DefaultValueHandling = DefaultValueHandling.Include,
				};
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("X-Mybring-API-Uid", "developer@zhipster.se");
				client.DefaultRequestHeaders.Add("X-Mybring-API-Key", "6ac118e3-70be-4db1-a2c5-8237aff378e2");
				client.DefaultRequestHeaders.Add("X-Bring-Client-URL", "http://exant.se/");
				var apiHttpResult = await client.GetAsync(endpoint);
				if (apiHttpResult.IsSuccessStatusCode)
				{
					var json = await apiHttpResult.Content.ReadAsStringAsync();
					var postalCodes = JsonConvert.DeserializeObject<BringPostalCodesResponseJSON>(json);
				}
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}
		}

		private static async Task TestBringFinland()
		{
			try
			{
				var endpoint = "https://api.bring.com/address/api/FI/postal-codes";
				var client = new HttpClient
				{
					BaseAddress = new Uri(endpoint),
					Timeout = TimeSpan.FromSeconds(60),
				};
				var serializerSettings = new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					DefaultValueHandling = DefaultValueHandling.Include,
				};
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("X-Mybring-API-Uid", "developer@zhipster.se");
				client.DefaultRequestHeaders.Add("X-Mybring-API-Key", "6ac118e3-70be-4db1-a2c5-8237aff378e2");
				client.DefaultRequestHeaders.Add("X-Bring-Client-URL", "http://exant.se/");
				var apiHttpResult = await client.GetAsync(endpoint);
				if (apiHttpResult.IsSuccessStatusCode)
				{
					var json = await apiHttpResult.Content.ReadAsStringAsync();
					var postalCodes = JsonConvert.DeserializeObject<BringPostalCodesResponseJSON>(json);
				}
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}
		}
	}
}