using CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CouponAPI;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Coupons Data
        modelBuilder.Entity<Coupon>().HasData(new Coupon
        {
            Id = 1,
            Code = "20OFF",
            DiscountAmount = 20,
            MinAmount = 5
        });
    }


    public DbSet<Coupon> Coupons { get; set; }
}

