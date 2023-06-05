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
    public class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property").HasKey(it => it.IdProperty);
            builder.Property(it => it.IdProperty)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(it => it.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(it => it.Address)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(it => it.Price)
                .IsRequired();
            builder.Property(it => it.CodeInternal)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(it => it.Year)
                .IsRequired()
                .HasColumnType("smallint")
                .HasMaxLength(4);
            builder.HasOne(it => it.Owner)
                .WithMany(x =>x.Properties)
                .HasForeignKey(x=> x.IdOwner);
        }
    }
}
