using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Repositories;
using Library.ToniIvankovic.Contracts.Services;
using Library.ToniIvankovic.Data.Db.Repositories;
using Library.ToniIvankovic.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

[assembly: FunctionsStartup(typeof(Library.ToniIvankovic.Functions.Startup))]
namespace Library.ToniIvankovic.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;

            IConfiguration config = builder.GetContext().Configuration;
            builder.Services.AddOptions<EmailSettings>().Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.GetSection("EmailSettings").Bind(settings);
            });
            //services.Configure<EmailSettings>(config.GetSection("EmailSettings"));  // Ne radi ni ovak

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("LibraryDB")));
            services.AddScoped<ILibraryNotificationService, LibraryNotificationService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
