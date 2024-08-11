using FinApp.API.Models.Domain;

namespace FinApp.API.Repositories.Interfaces
{
    public interface IPartnerRepository
    {
        Task<List<Partner>> GetAllAsync();
        Task<Partner?> GetByIdAsync(Guid id);
        Task<Partner> CreateAsync(Partner partner);
        Task<Partner?> UpdateAsync(Guid id, Partner partner);
        Task<Partner?> DeleteAsync(Guid id);
    }
}
