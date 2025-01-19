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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                   .HasConversion(id => id.Value, value => new StronglyTypedId<Reservation>(value))
                   .IsRequired();

            builder.Property(r => r.PassengerCount)
                   .IsRequired();

            builder.Property(r => r.TotalPrice)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(r => r.Status)
                   .IsRequired();

            builder.HasOne<User>()
                   .WithMany(u => u.Reservations)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Flight>()
                   .WithMany()
                   .HasForeignKey(r => r.FlightId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
