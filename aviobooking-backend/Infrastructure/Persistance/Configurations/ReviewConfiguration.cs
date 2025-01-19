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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                   .HasConversion(id => id.Value, value => new StronglyTypedId<Review>(value))
                   .IsRequired();

            builder.Property(r => r.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.Content)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(r => r.ImageUrl)
                   .HasMaxLength(500);

            builder.Property(r => r.Status)
                   .IsRequired();

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(r => r.ReviewerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Airline>()
                   .WithMany(a => a.Reviews)
                   .HasForeignKey(r => r.AirlineId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
