using SunnyBuy.Entitities;
using Microsoft.EntityFrameworkCore;

namespace SunnyBuy.Context
{
    public class Context : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=debora.maciel;Data Source=SERVER");
        }
    }
}