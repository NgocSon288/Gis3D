using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class NodeConfiguration : IEntityTypeConfiguration<Node>
    {
        public void Configure(EntityTypeBuilder<Node> builder)
        {
            builder.ToTable("Nodes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.X).IsRequired(true);

            builder.Property(x => x.Y).IsRequired(true);

            builder.Property(x => x.Z).IsRequired(true);

            builder.HasOne(n => n.Face)
                .WithMany(f => f.Nodes)
                .HasForeignKey(f => f.FaceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.Line)
                .WithMany(l => l.Nodes)
                .HasForeignKey(f => f.LineId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.Point)
                .WithOne(p => p.Node)
                .HasForeignKey<Node>(n => n.PointId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
