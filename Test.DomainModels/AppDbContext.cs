using Microsoft.EntityFrameworkCore;
using Test.DomainModels.Group;
using Test.DomainModels.Provider;

namespace Test.DomainModels
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ProviderTypes> ProviderTypes { get; set; }
        public virtual DbSet<GroupTypes> GroupTypes { get; set; }
        public virtual DbSet<Providers> Providers { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=TestDb;Trusted_Connection=True;Integrated Security = false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasColumnType("Nvarchar(200)")
                    .IsRequired();

                entity.HasOne(d => d.GroupTypes)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.GroupTypeId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<GroupTypes>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasColumnType("Nvarchar(200)")
                    .IsRequired(); 
            });

            modelBuilder.Entity<Providers>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasColumnType("Nvarchar(200)")
                    .IsRequired();

                entity.HasOne(d => d.ProviderTypes)
                    .WithMany(p => p.Providers)
                    .HasForeignKey(d => d.ProviderTypeId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Groups)
                    .WithMany(p => p.Providers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<ProviderTypes>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasColumnType("Nvarchar(200)")
                    .IsRequired();
            });
        }
    }
}
