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
    internal class OwnerConfig : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner").HasKey(it => it.IdOwner);
            builder.Property(it => it.IdOwner)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(it => it.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(it => it.Address)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(it => it.Photo)
                .IsRequired();
            builder.Property(it => it.Birhday)
                .IsRequired().HasColumnType("Date");

        }
    }
}
