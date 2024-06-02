using DebtMaster.Data;
using DebtMaster.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DebtMaster.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DebtDbContext dbContext;

        public UserRepository(DebtDbContext dbContext)
        {
             this.dbContext = dbContext;
        }
        public async Task<User> CreateAsync(User user)
        {
           dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<List<User>> GetAllAsync()
        {
             return await dbContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.UserID == id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
            return user;
        }
    }
}
