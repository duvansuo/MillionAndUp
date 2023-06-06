using Microsoft.EntityFrameworkCore;
using MillionAndUp.Domain;
using MillionAndUp.Infraestructure.Data.Config;

namespace MillionAndUp.Infraestructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyTrace> PropertyTraces { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OwnerConfig());
            builder.ApplyConfiguration(new PropertyConfig());
            builder.ApplyConfiguration(new PropertyImageConfig());
            builder.ApplyConfiguration(new PropertyTraceConfig());
        }

    }
}
