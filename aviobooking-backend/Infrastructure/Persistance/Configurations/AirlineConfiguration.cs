using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Configurations
{
    public class AirlineConfiguration : IEntityTypeConfiguration<Airline>
    {
        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasConversion(id => id.Value, value => new StronglyTypedId<Airline>(value))
                   .IsRequired();

            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Address)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(a => a.ContactInfo)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(a => a.Flights)
                   .WithOne()
                   .HasForeignKey(f => f.AirlineId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Reviews)
                   .WithOne()
                   .HasForeignKey(r => r.AirlineId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
