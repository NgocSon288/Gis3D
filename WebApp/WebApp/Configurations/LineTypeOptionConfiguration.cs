using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class LineTypeOptionConfiguration : IEntityTypeConfiguration<LineTypeOption>
    {
        public void Configure(EntityTypeBuilder<LineTypeOption> builder)
        {
            builder.ToTable("LineTypeOptions");

            builder.HasKey(x => x.Id);

            builder.HasOne(fto => fto.LineType)
                .WithMany(ft => ft.LineTypeOptions)
                .HasForeignKey(fto => fto.LineTypeId);

            builder.HasOne(fto => fto.Option)
                .WithMany(o => o.LineTypeOptions)
                .HasForeignKey(fto => fto.OptionId);
        }
    }
}
