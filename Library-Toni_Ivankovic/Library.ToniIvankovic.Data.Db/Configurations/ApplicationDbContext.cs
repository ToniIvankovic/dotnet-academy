using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Library.ToniIvankovic.Data.Db.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<Person, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // tablica u bazi
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
