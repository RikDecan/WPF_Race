using Racing.WPF.App.Languages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Windows;
using Races.Db;

namespace Generic.Host.WPF.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost? _host;
        private RacesDb? _repository;
        private IConfiguration? _configuration;

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, Translations.ExceptionMsg, MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }     

        public App()
        {
            var hostBuilder = new HostBuilder()

                // Setup van configuratie:

                .ConfigureAppConfiguration((context, configurationBuilder) =>
                {
                    configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                    configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    // Niet optioneel: config bestand moet er staan!
                    // reload on change: zonder de app te herstarten is een aangepast configuratiebestand opgeladen
                    configurationBuilder.AddEnvironmentVariables(); // bijvoorbeeld SET X=Y
                })

                .ConfigureServices((context, services) =>
                {
                    // DI registratie windows:
                    // -----------------------
                    services.AddSingleton<MainWindow>(); // ik maak de "dienst" MainWindow bekend als singleton
                    services.AddSingleton<DriversWindow>();
                    services.AddSingleton<DriverWindow>();
                    services.AddSingleton<CarsWindow>();
                    services.AddSingleton<LogInWindow>();

                    // DI Db registratie:
                    // ------------------
                    var cs = context.Configuration.GetConnectionString("RacesDbConnectionString");
                    if (!string.IsNullOrEmpty(cs))
                    {
                        _repository = new RacesDb(cs);
                        services.AddSingleton<RacesDb>(_repository);
                    }
                });

            hostBuilder.ConfigureLogging(logging =>
            {
                logging.AddDebug(); // logt naar Visual Studio Debug window, dus enkel zichtbaar als ontwikkelaar
                logging.SetMinimumLevel(LogLevel.Trace); // we zijn geïnteresseerd in ALLE debug info, ook van Microsoft!
            });

            _host = hostBuilder.Build();
        }

        // Lifecycle host koppelen aan deze van mijn WPF applicatie - deze code gewoon copieren

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            // Eerst lifecycle koppelen
            // Await is semester 3 ...
            await _host.StartAsync();

            var logger = _host.Services.GetRequiredService<ILogger<App>>();
            logger.LogInformation("Host lifecycle coupled, launching main window...");

            _configuration = _host.Services.GetRequiredService<IConfiguration>();
            var langSpec = _configuration["Language"]!;
            // We zetten de taal van de applicatie: ISO standaard
            logger.LogInformation($"Setting application language to {langSpec}");
            Translations.Culture = new System.Globalization.CultureInfo(langSpec); // nl-BE en-US fr-BE 

            // Daarna startvenster als dienst aanvragen en tonen:
            var mainWindow = _host.Services.GetService<MainWindow>(); // hier gebeurt de eerste keer een "new"            
            mainWindow?.Show();
        }
        
        private async void OnExit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5)); // we gunnen de host 5 seconden alvorens geforceerd te stoppen
            }
        }
    }
}
