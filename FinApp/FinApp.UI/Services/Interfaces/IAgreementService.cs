using FinApp.UI.Models.DTO;

namespace FinApp.UI.Services.Interfaces
{
    public interface IAgreementService
    {
        Task<List<AgreementDto>> GetAllAsync();

        Task<AgreementDto?> GetByIdAsync(Guid id);

        Task<AgreementDto?> CreateAsync(AgreementDto agreement);

        Task<AgreementDto?> UpdateAsync(AgreementDto agreement);

        Task<AgreementDto?> DeleteAsync(Guid id);

        Task<List<RiskLevelDto>> GetRiskLevels();
    }
}
