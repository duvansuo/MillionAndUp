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
    public class PropertyTraceConfig : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> builder)
        {
            builder.ToTable("PropertyTrace").HasKey(it => it.IdPropertyTrace);
            builder.Property(it => it.IdPropertyTrace)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(it => it.DateSale)
                .IsRequired();
            builder.Property(it => it.Name)
                .IsRequired().
                HasMaxLength(50);
            builder.Property(it => it.Value)
                .IsRequired();
            builder.Property(it => it.Tax)
                .IsRequired();
            builder.HasOne(it => it.Property)
                .WithMany(x => x.PropertyTraces)
                .HasForeignKey(x => x.IdProperty);
        }
    }
}
