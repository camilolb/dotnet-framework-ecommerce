
namespace Pruebatecnica.Infrastructura.Data
{
    using Microsoft.EntityFrameworkCore;
    using Pruebatecnica.Infraestructura.Data.Configuration;
    using PruebaTecnica.Core.Entities;
    using System.Reflection;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Security> Security { get; set; }
        public virtual DbSet<Build> Build { get; set; }
        public virtual DbSet<Departament> Departament { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SecurityConfiguration());

            modelBuilder.ApplyConfiguration(new BuildConfiguration());
            modelBuilder.ApplyConfiguration(new DepartamentConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());



            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            OnModelCreatingPartial(modelBuilder);
        }
        
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}