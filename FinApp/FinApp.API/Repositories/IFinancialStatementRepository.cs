using FinApp.API.Models.Domain;

namespace FinApp.API.Repositories
{
    public interface IFinancialStatementRepository
    {
        Task<List<FinancialStatement>> GetAllAsync();
        Task<FinancialStatement?> GetByIdAsync(Guid id);
        Task<FinancialStatement> CreateAsync(FinancialStatement financialStatement);
        Task<FinancialStatement?> UpdateAsync(Guid id, FinancialStatement financialStatement);
        Task<FinancialStatement?> DeleteAsync(Guid id);
    }
}
