using DebtMaster.Models.Domain;

namespace DebtMaster.Repositories
{
    public interface IDebtRepository
    {
        Task<Debt> CreateAsync(Debt debt);
        Task<List<Debt>> GetAllAsync();
    }
}
