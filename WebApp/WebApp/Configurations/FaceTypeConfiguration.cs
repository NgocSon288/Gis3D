using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class FaceTypeConfiguration : IEntityTypeConfiguration<FaceType>
    {
        public void Configure(EntityTypeBuilder<FaceType> builder)
        {
            builder.ToTable("FaceTypes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired(true);

            builder.Property(x => x.Description).IsRequired(true); 
        }
    }
}
