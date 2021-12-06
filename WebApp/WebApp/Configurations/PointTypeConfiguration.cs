using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class PointTypeConfiguration : IEntityTypeConfiguration<PointType>
    {
        public void Configure(EntityTypeBuilder<PointType> builder)
        {
            builder.ToTable("PointTypes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired(true);

            builder.Property(x => x.Description).IsRequired(true);
        }
    }
}
