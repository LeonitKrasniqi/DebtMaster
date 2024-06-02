using DebtMaster.Data;
using DebtMaster.Models.Domain;
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

        public Task<Debt> DeleteAsync(Guid debtorId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Debt>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Debt> GetByIdAsync(Guid debtorId)
        {
            throw new NotImplementedException();
        }
    }
}
