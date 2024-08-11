using FinApp.UI.Models.DTO;

namespace FinApp.UI.Services.Interfaces
{
    public interface IPartnerService
    {

        Task<List<PartnerDto>> GetAllAsync();

        Task<PartnerDto?> GetByIdAsync(Guid id);

        Task<PartnerDto?> CreateAsync(PartnerDto partner);

        Task<PartnerDto?> UpdateAsync(PartnerDto partner);

        Task<PartnerDto?> DeleteAsync(Guid id);
    }
}
