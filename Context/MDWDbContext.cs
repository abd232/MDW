using Microsoft.EntityFrameworkCore;
using Models;
namespace MDW.Context
{
    public class MDWDbContext : DbContext
    {
        public MDWDbContext(DbContextOptions<MDWDbContext> options)
            : base(options) 
        {
            
        }

        public DbSet<User> users { get; set; }

        public DbSet<Drug> drugs { get; set; }

        public DbSet<MoneyDonation> moneyDonations { get; set; }

        public DbSet<DrugDonation> drugsDonations { get; set; }

        public DbSet<MoneyRequest> moneyRequests { get; set; } 

        public DbSet<DrugRequest> drugsRequests { get; set;}

    }
}
