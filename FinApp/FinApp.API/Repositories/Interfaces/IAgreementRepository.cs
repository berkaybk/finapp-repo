using FinApp.API.Models.Domain;

namespace FinApp.API.Repositories.Interfaces {
    public interface IAgreementRepository
    {
        Task<List<Agreement>> GetAllAsync();

        Task<Agreement?> GetByIdAsync(Guid id);

        Task<Agreement> CreateAsync(Agreement agreement);

        Task<Agreement?> UpdateAsync(Guid id, Agreement agreement);

        Task<Agreement?> DeleteAsync(Guid id);
    }
}
