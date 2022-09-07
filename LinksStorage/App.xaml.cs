using LinksStorage.DAL;
using LinksStorage.DAL.Entities;
using LinksStorage.DAL.Repositories;
using LinksStorage.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace LinksStorage
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<DataContext>();
                    services.AddScoped<MainWindow>();
                    services.AddScoped<IUsersRepository, UsersRepository>();
                    services.AddScoped<ILinksRepository, LinksRepository>();
                    services.AddScoped<ILinksService, LinksService>();
                    services.AddScoped<IUsersService, UsersService>();
                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();

            base.OnExit(e);
        }
    }
}
