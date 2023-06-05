using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MillionAndUp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Infraestructure.Data.Config
{
    public class PropertyImageConfig : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToTable("PropertyImage").HasKey(it => it.IdPropertyImage);
            builder.Property(it => it.IdPropertyImage)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(it => it.File)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(it => it.Enabled)
                .IsRequired();
            builder.HasOne(it => it.Property)
                .WithMany(x => x.PropertyImages)
                .HasForeignKey(x => x.IdProperty);
        }
    }
}
