using DebtMaster.Data;
using DebtMaster.Models.Domain;
using DebtMaster.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DebtMaster.Repositories
{
    public class DebtRepository : IDebtRepository
    {
        private readonly DebtDbContext dbContext;

        public DebtRepository(DebtDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Debt> CreateAsync(Debt debt)
        {

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.UserID == debt.UserId);
            if (user == null)
            {
             
                throw new ArgumentException("User with the provided ID does not exist.");
            }
            await dbContext.Debts.AddAsync(debt);   
            await dbContext.SaveChangesAsync();
            return debt;
        }


        public async Task<List<Debt>> GetAllAsync()
        {
            return await dbContext.Debts.ToListAsync();
        }

        public async Task<List<Debt>> GetDebtsByUserIdAsync(Guid UserId)
        {
            var userExists = await dbContext.Users.AnyAsync(u => u.UserID == UserId);

            if (!userExists)
            {
                throw new KeyNotFoundException("User not found");
            }

            return await dbContext.Debts
                            .Where(d => d.UserId == UserId)
                            .ToListAsync();
        }

        public async Task<UserDebtAmountDto> GetTotalAmountByUserIdAsync(Guid UserId)
        {
            var user = await dbContext.Users
            .Include(u => u.Debts)
            .FirstOrDefaultAsync(u => u.UserID == UserId);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            var totalAmount = user.Debts.Sum(d => d.Amount);

            return new UserDebtAmountDto
            {
                UserId = user.UserID,
                Name = user.Name,
                TotalAmount = totalAmount
            };
        }
    }
}
