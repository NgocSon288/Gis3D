using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class FaceTypeOptionConfiguration : IEntityTypeConfiguration<FaceTypeOption>
    {
        public void Configure(EntityTypeBuilder<FaceTypeOption> builder)
        {
            builder.ToTable("FaceTypeOptions");

            builder.HasKey(x => x.Id);

            builder.HasOne(fto => fto.FaceType)
                .WithMany(ft => ft.FaceTypeOptions)
                .HasForeignKey(fto => fto.FaceTypeId);

            builder.HasOne(fto => fto.Option)
                .WithMany(o => o.FaceTypeOptions)
                .HasForeignKey(fto => fto.OptionId);
        }
    }
}
