

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class PointTypeOptionValueConfiguration : IEntityTypeConfiguration<PointTypeOptionValue>
    {
        public void Configure(EntityTypeBuilder<PointTypeOptionValue> builder)
        {
            builder.ToTable("PointTypeOptionValues");

            builder.HasKey(x => x.Id);

            builder.HasOne(ftov => ftov.Point)
                .WithMany(f => f.PointTypeOptionValues)
                .HasForeignKey(ftov => ftov.PointId);
        }
    }
}
