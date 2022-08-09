using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Shopping.Models
{
    public class Shipping:IdentityDbContext<AppUser>
    {
        public Shipping()
        {

        }
        public Shipping(DbContextOptions options):base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Order>()
        //    .HasOne(p => p.user)
        //    .WithOne(p=>p.Id);
        //}
        public DbSet<Order> Order { get; set; }
        public DbSet<Government> governments { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Powers> powers { get; set; }
        public DbSet<ShippingPrice> ShippingPrices { get; set; }
        public DbSet<ShippingTypes> ShippingTypes { get; set; }
        public DbSet<Product> products { get; set; }






        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Shipping;Integrated Security=True");
        }

    }
}
