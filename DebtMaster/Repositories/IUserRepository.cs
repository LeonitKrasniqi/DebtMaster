using DebtMaster.Models.Domain;

namespace DebtMaster.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(Guid id);

    }
}
