using DebtMaster.Models.Domain;
using DebtMaster.Models.DTOs;

namespace DebtMaster.Repositories
{
    public interface IDebtRepository
    {
        Task<Debt> CreateAsync(Debt debt);
        Task<List<Debt>> GetAllAsync();

        Task<List<Debt>> GetDebtsByUserIdAsync(Guid UserId);
        Task<UserDebtAmountDto> GetTotalAmountByUserIdAsync(Guid UserId);
    }
}
