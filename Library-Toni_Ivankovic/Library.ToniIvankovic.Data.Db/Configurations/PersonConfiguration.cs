using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.ToniIvankovic.Data.Db.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // konfiguracija persona
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            // konfiguracija odnosa
            builder
                .HasOne(p => p.Address)
                .WithMany();
        }
    }
}
