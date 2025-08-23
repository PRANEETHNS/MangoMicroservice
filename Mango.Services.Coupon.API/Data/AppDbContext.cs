using Mango.Services.Coupon.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.Coupon.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Models.Coupon> Coupons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //This line is needed if identity is needed

            modelBuilder.Entity<Models.Coupon>().HasData(new Models.Coupon { 
                CouponId = 1,
                CouponCode = "100FF",
                DiscountAmount = 10,
                MinAmount = 20            
            });

            modelBuilder.Entity<Models.Coupon>().HasData(new Models.Coupon
            {
                CouponId = 2,
                CouponCode = "100GG",
                DiscountAmount = 20,
                MinAmount = 60
            });

            modelBuilder.Entity<Models.Coupon>().HasData(new Models.Coupon
            {
                CouponId = 3,
                CouponCode = "10TG",
                DiscountAmount = 70,
                MinAmount = 100
            });
        }
    }
}
