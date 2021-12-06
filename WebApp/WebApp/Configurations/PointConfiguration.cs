using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class PointConfiguration : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder.ToTable("Points");

            builder.HasKey(x => x.Id);

            builder.HasOne(f => f.PointType)
                .WithMany(ft => ft.Points)
                .HasForeignKey(f => f.PointTypeId);

            builder.HasOne(f => f.Body)
                .WithMany(b => b.Points)
                .HasForeignKey(f => f.BodyId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
