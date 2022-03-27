using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Data.Db.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.ToniIvankovic.Api
{
    public static class IoC
    {
        public static void ConfigureDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("LibraryDB"), opt => opt.MigrationsAssembly("Library.ToniIvankovic.Data.Db"));
            });
            services
                .AddIdentity<Person, IdentityRole<int>>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireDigit = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}
