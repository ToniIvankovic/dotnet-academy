using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Repositories;
using Library.ToniIvankovic.Contracts.Services;
using Library.ToniIvankovic.Data.Db.Repositories;
using Library.ToniIvankovic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FunctionEmailSender
{
    public class Program
    {
        private static IConfiguration config = default!;

        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration((builder) =>
                {
                    config = builder
                        .AddJsonFile("local.settings.json", true)
                        .Build();
                })
                .ConfigureServices((services) =>
                {
                    services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("PersonDB")));
                    services.AddScoped<ILibraryNotificationService, LibraryNotificationService>();
                    services.AddScoped<IEmailService, EmailService>();
                    services.AddScoped<IUnitOfWork, UnitOfWork>();
                })
                .Build();
            host.Run();
        }
    }
}
