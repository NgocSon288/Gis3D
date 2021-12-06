 

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class LineTypeOptionValueConfiguration : IEntityTypeConfiguration<LineTypeOptionValue>
    {
        public void Configure(EntityTypeBuilder<LineTypeOptionValue> builder)
        {
            builder.ToTable("LineTypeOptionValues");

            builder.HasKey(x => x.Id); 

            builder.HasOne(ftov => ftov.Line)
                .WithMany(f => f.LineTypeOptionValues)
                .HasForeignKey(ftov => ftov.LineId);
        }
    }
}
