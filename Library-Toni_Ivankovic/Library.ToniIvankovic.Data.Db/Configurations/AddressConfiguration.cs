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
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasAlternateKey(a => new { a.Street, a.City, a.Country });

            builder
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasOne(a => a.Person)
                .WithOne(p => p.Address)
                .HasForeignKey<Person>(p => p.Id);
        }
    }
}
