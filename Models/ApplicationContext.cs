using Microsoft.EntityFrameworkCore;

namespace PhoneShop.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options){}
    }
}
