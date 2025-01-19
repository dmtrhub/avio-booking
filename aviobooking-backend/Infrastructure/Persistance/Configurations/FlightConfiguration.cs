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
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                   .HasConversion(id => id.Value, value => new StronglyTypedId<Flight>(value))
                   .IsRequired();

            builder.Property(f => f.DepartureLocation)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(f => f.ArrivalLocation)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(f => f.DepartureTime)
                   .IsRequired();

            builder.Property(f => f.ArrivalTime)
                   .IsRequired();

            builder.Property(f => f.AvailableSeats)
                   .IsRequired();

            builder.Property(f => f.ReservedSeats)
                   .IsRequired();

            builder.Property(f => f.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(f => f.Status)
                   .IsRequired();

            builder.HasOne<Airline>()
                   .WithMany(a => a.Flights)
                   .HasForeignKey(f => f.AirlineId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
