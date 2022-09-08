using System.Windows;

namespace LinksStorage
{
    public partial class App : Application
    {
        //public static IHost? AppHost { get; private set; }

        //public App()
        //{

        //    AppHost = Host.CreateDefaultBuilder()
        //        .ConfigureServices((hostContext, services) =>
        //        {
        //            services.AddDbContext<DataContext>();
        //            services.AddTransient<MainViewModel>();
        //            services.AddScoped<MainWindow>();
        //            services.AddScoped<IUsersRepository, UsersRepository>();
        //            services.AddScoped<ILinksRepository, LinksRepository>();
        //            services.AddScoped<ILinksService, LinksService>();
        //            services.AddScoped<IUsersService, UsersService>();
        //        }).Build();
        //}

        protected override void OnStartup(StartupEventArgs e)
        {
            ViewModelLocator.Init();
            //await AppHost!.StartAsync();

            //var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            //startupForm.Show();

            base.OnStartup(e);
        }

        //protected override async void OnExit(ExitEventArgs e)
        //{
        //    await AppHost!.StopAsync();

        //    base.OnExit(e);
        //}
    }
}
