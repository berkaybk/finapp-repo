using FinApp.API.Models.Domain;

namespace FinApp.API.Repositories
{
    public interface IRiskAnalysisRepository
    {
        Task<List<RiskAnalysis>> GetAllAsync();
        Task<RiskAnalysis?> GetByIdAsync(Guid id);
        Task<RiskAnalysis> CreateAsync(RiskAnalysis riskAnalysis);
        Task<RiskAnalysis?> UpdateAsync(Guid id, RiskAnalysis riskAnalysis);
        Task<RiskAnalysis?> DeleteAsync(Guid id);
    }
}
