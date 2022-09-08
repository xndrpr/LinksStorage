using LinksStorage.DAL.Repositories;
using LinksStorage.DAL;
using LinksStorage.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using LinksStorage.Views;
using LinksStorage.ViewModels;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace LinksStorage
{
    public class ViewModelLocator
    {
        private static ServiceProvider _provider;

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddDbContext<DataContext>();
            services.AddTransient<MainViewModel>();
            services.AddScoped<MainWindow>();
            services.AddScoped<ILinksRepository, LinksRepository>();
            services.AddScoped<ILinksService, LinksService>();

            _provider = services.BuildServiceProvider();

            foreach (var item in services)
            {
                _provider.GetRequiredService(item.ServiceType);
            }
        }

        public MainViewModel MainViewModel => _provider.GetRequiredService<MainViewModel>();
    }
}
