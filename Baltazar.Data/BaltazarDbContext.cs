using System;
using Baltazar.Data;
using Baltazar.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Baltazar.Data
{
    public class BaltazarDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public BaltazarDbContext(DbContextOptions<BaltazarDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasMany(user => user.Orders)
                    .WithOne(order => order.User)
                    .HasForeignKey(order => order.UserId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 2)");
                entity
                .HasOne(o => o.User) // An order has one associated user
                .WithMany() // A user can have multiple orders
                .HasForeignKey(o => o.UserId);  // Foreign key property
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price)
                .HasColumnType("decimal(18,2)");
            });
        }
    }
}

public class BaltzarDbContextFactory : IDesignTimeDbContextFactory<BaltazarDbContext>
{

    public BaltazarDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Baltazar"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<BaltazarDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new BaltazarDbContext(optionsBuilder.Options);
    }
}

