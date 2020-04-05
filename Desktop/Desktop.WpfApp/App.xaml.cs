
using Desktop.Application;
using Desktop.Presentation.Common.Interfaces;
using Desktop.Presentation.ViewModels;
using Desktop.WpfApp.Views;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Windows;

namespace Desktop.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private IHost Host { get; }
        private ILogger Logger { get; }
        private IServiceScope Scope { get; }

        public App()
        {
            Host = CreateHostBuilder( Environment.GetCommandLineArgs() )
                .Build();
            Scope = Host.Services.CreateScope();
            Logger = Scope.ServiceProvider.GetRequiredService<ILogger<App>>();
        }

        public static IHostBuilder CreateHostBuilder( string[] args )
        {
            return Microsoft.Extensions.Hosting.Host
                .CreateDefaultBuilder( args )
                .ConfigureAppConfiguration( ( context, config ) =>
                 {
                     if ( context.HostingEnvironment.IsDevelopment() )
                     {
                         config.AddUserSecrets( typeof( App ).Assembly, optional: true );
                     }
                 } )
                .ConfigureServices( ( context, services ) =>
                {
                    services
                        .AddApplication()
                        .AddInfrastructure()
                        .AddPresentation();
                } );
        }

        protected override async void OnStartup( StartupEventArgs e )
        {
            base.OnStartup( e );

            await Host.StartAsync();

            var navService = Scope.ServiceProvider.GetRequiredService<INavigationService>();
            var viewModel = Scope.ServiceProvider.GetRequiredService<MainViewModel>();
            var view = new MainWindow
            {
                DataContext = viewModel
            };
            Logger.LogDebug( "{method}: Show View", nameof( OnStartup ) );
            view.Show();
            await viewModel.InitializeAsync( null );
            await navService.InitializeAsync();
        }

        protected override async void OnExit( ExitEventArgs e )
        {
            base.OnExit( e );
            Scope.Dispose();
            await Host.StopAsync();
            Host.Dispose();
        }
    }
}
