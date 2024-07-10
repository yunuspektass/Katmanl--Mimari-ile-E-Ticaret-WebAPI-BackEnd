using Microsoft.EntityFrameworkCore;
using Project.DAL.EntityConfigurations;
using Project.DAL.Extensions;
using Project.ENTITIES.Models;


namespace Project.DAL.Context;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<AppUser>().HasQueryFilter(p => !p.IsDeleted);
        // base.OnModelCreating(modelBuilder);
        modelBuilder.AddGlobalFilter();
        
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
    }

    


    public DbSet<Product> Products { get; set; }
    
    public DbSet<Category> Categories { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    public DbSet<Shipper> Shippers { get; set; }
    
    public DbSet<AppUser> AppUsers { get; set; }
    
    public DbSet<AppUserProfile> UserProfiles { get; set; }

    
}