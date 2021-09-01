using Microsoft.EntityFrameworkCore;

namespace PhoneShop.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options){}
    }
}
