using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class PointTypeOptionConfiguration : IEntityTypeConfiguration<PointTypeOption>
    {
        public void Configure(EntityTypeBuilder<PointTypeOption> builder)
        {
            builder.ToTable("PointTypeOptions");

            builder.HasKey(x => x.Id);

            builder.HasOne(fto => fto.PointType)
                .WithMany(ft => ft.PointTypeOptions)
                .HasForeignKey(fto => fto.PointTypeId);

            builder.HasOne(fto => fto.Option)
                .WithMany(o => o.PointTypeOptions)
                .HasForeignKey(fto => fto.OptionId);
        }
    }
}
