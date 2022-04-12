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
    public class RentingInstanceConfiguration : IEntityTypeConfiguration<RentingInstance>
    {
        public void Configure(EntityTypeBuilder<RentingInstance> builder)
        {
            builder
                .HasKey(r => new { r.Person, r.RentingDateTime, r.Book });

            builder
                .Property(r => r.RentingDateTime)
                .IsRequired()
                .HasColumnName("Date rented");

        }
    }
}
