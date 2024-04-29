using DebtMaster.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DebtMaster.Data
{
    public class DebtDbContext : DbContext
    {
        public DebtDbContext(DbContextOptions<DebtDbContext> debtDbContext) : base(debtDbContext)
        {
            
        }

        public DbSet<Debt> Debts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
        }
    }
}
