using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class LineConfiguration : IEntityTypeConfiguration<Line>
    {
        public void Configure(EntityTypeBuilder<Line> builder)
        {
            builder.ToTable("Lines");

            builder.HasKey(x => x.Id);

            builder.HasOne(f => f.LineType)
                .WithMany(ft => ft.Lines)
                .HasForeignKey(f => f.LineTypeId);

            builder.HasOne(f => f.Body)
                .WithMany(b => b.Lines)
                .HasForeignKey(f => f.BodyId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
