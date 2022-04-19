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
                .HasKey(r => new { r.RentingDateTime, r.PersonId, r.BookId });

            builder
                .Property(r => r.RentingDateTime)
                .IsRequired()
                .HasColumnName("Date_rented");

            builder
                .HasOne(r => r.Person)
                .WithMany(p => p.RentedBooks)
                .HasForeignKey(r => r.PersonId);

            builder
                .HasOne(r => r.Book)
                .WithMany(b => b.CurrentlyRentedBy)
                .HasForeignKey(r => r.BookId);
        }
    }
}
