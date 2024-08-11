using FinApp.API.Models.Domain;

namespace FinApp.API.Repositories
{
    public interface IAgreementRepository
    {
        Task<List<Agreement>> GetAllAsync();

        Task<Agreement?> GetByIdAsync(Guid id);

        Task<Agreement> CreateAsync(Agreement region);

        Task<Agreement?> UpdateAsync(Guid id, Agreement region);

        Task<Agreement?> DeleteAsync(Guid id);
    }
}
