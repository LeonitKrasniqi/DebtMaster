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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Debt>()
                 .HasOne(d => d.User)
                 .WithMany(u => u.Debts)
                 .HasForeignKey(d => d.UserId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Debt>()
               .Property(d => d.Amount)
               .HasColumnType("decimal(18,2)");

        }
    }
}
