using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class BodyConfiguration : IEntityTypeConfiguration<Body>
    {
        public void Configure(EntityTypeBuilder<Body> builder)
        {
            builder.ToTable("Bodies");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Description).IsRequired(); 
        }
    }
}
