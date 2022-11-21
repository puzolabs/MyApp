using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.Services;

namespace MyApp.Tests
{
    [TestClass]
    public class ProjectServiceTests
    {
        [TestInitialize]
        public void init()
        {
            var services = new ServiceCollection();

            // IOption configuration injection
            services.AddOptions();

            services.AddLogging(logging => logging.AddConsole());

            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.test.json")
                //.AddEnvironmentVariables()
                .Build();

            //services.Configure<DbSettings>(config.GetSection($"{DbSettings.SettingsKeyName}"));
            //services.AddSingleton<IDatabase, Database>();
            //services.AddSingleton<IAltarRepository, AltarRepository>();
            //services.AddSingleton<IReservationRepository, ReservationRepository>();

            //ServiceProvider serviceProvider = services.BuildServiceProvider();

            //AltarRepository = serviceProvider.GetRequiredService<IAltarRepository>();
            //ReservationRepository = serviceProvider.GetRequiredService<IReservationRepository>();

            ////migrate db
            //var migrator = serviceProvider.GetRequiredService<IHostedService>();
            //await migrator.StartAsync(new CancellationToken());

        }

        [TestMethod]
        public void Test()
        {
            //IProjectService projectService = new ProjectService();
        }
    }
}
