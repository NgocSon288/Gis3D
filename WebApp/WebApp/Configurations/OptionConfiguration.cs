using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Configurations
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("Options");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired(true);

            builder.Property(x => x.IsNumber)
                .HasDefaultValue(false);
        }
    }
}
