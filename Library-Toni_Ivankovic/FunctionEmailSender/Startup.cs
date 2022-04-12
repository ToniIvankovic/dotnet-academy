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

[assembly: FunctionsStartup(typeof(Library.ToniIvankovic.Functions.Startup))]
namespace Library.ToniIvankovic.Functions
{
    public class Startup : FunctionsStartup
    {
        private static IConfiguration config = default!;
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;

            var sp = builder.Services.BuildServiceProvider();
            config = sp.GetRequiredService<IConfiguration>();

            //Console.WriteLine("v");
            //config.AsEnumerable().ToList().ForEach(i => Console.WriteLine(i));
            //Console.WriteLine(config.GetConnectionString("Key"));
            //Console.WriteLine(System.Environment.GetEnvironmentVariable("Key"));
            //Console.WriteLine(config.GetSection("EmailSettings").Key);
            //Console.WriteLine(config.GetConnectionString("LibraryDB"));

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("LibraryDB")));
            services.AddScoped<ILibraryNotificationService, LibraryNotificationService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.Configure<EmailSettings>(new {
            //    Key = config.GetConnectionString("Key"),
            //    From = config.GetConnectionString("From")
            //});
        }
    }
}
