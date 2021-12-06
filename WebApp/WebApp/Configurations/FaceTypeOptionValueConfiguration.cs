 

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class FaceTypeOptionValueConfiguration : IEntityTypeConfiguration<FaceTypeOptionValue>
    {
        public void Configure(EntityTypeBuilder<FaceTypeOptionValue> builder)
        {
            builder.ToTable("FaceTypeOptionValues");

            builder.HasKey(x => x.Id); 

            builder.HasOne(ftov => ftov.Face)
                .WithMany(f => f.FaceTypeOptionValues)
                .HasForeignKey(ftov => ftov.FaceId);
        }
    }
}
