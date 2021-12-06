using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class FaceConfiguration : IEntityTypeConfiguration<Face>
    {
        public void Configure(EntityTypeBuilder<Face> builder)
        {
            builder.ToTable("Faces");

            builder.HasKey(x => x.Id);

            builder.HasOne(f => f.FaceType)
                .WithMany(ft => ft.Faces)
                .HasForeignKey(f => f.FaceTypeId);

            builder.HasOne(f => f.Body)
                .WithMany(b => b.Faces)
                .HasForeignKey(f => f.BodyId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
