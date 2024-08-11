using FinApp.API.Data;
using FinApp.API.Models.Domain;
using FinApp.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinApp.API.Repositories
{
    public class RiskAnalysisRepository : IRiskAnalysisRepository
    {
        private readonly ApplicationDbContext dbContext;

        public RiskAnalysisRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<RiskAnalysis> CreateAsync(RiskAnalysis riskAnalysis)
        {
            await dbContext.RiskAnalyses.AddAsync(riskAnalysis);
            await dbContext.SaveChangesAsync();
            return riskAnalysis;
        }

        public async Task<RiskAnalysis?> DeleteAsync(Guid id)
        {
            var riskAnalysis = await dbContext.RiskAnalyses.FirstOrDefaultAsync(x => x.Id == id);

            if (riskAnalysis != null)
            {
                dbContext.RiskAnalyses.Remove(riskAnalysis);
                await dbContext.SaveChangesAsync();
            }

            return riskAnalysis;
        }

        public async Task<List<RiskAnalysis>> GetAllAsync()
        {
            var riskAnalyses = await dbContext.RiskAnalyses.ToListAsync();
            return riskAnalyses;
        }

        public async Task<RiskAnalysis?> GetByIdAsync(Guid id)
        {
            return await dbContext.RiskAnalyses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<RiskAnalysis?> UpdateAsync(Guid id, RiskAnalysis riskAnalysis)
        {
            var riskAnalysisOnDb = await dbContext.RiskAnalyses.FirstOrDefaultAsync(x => x.Id == id);

            if (riskAnalysisOnDb != null)
            {
                riskAnalysisOnDb.AgreementId = riskAnalysis.AgreementId;
                riskAnalysisOnDb.RiskScore = riskAnalysis.RiskScore;
                riskAnalysisOnDb.Comments = riskAnalysis.Comments;

                await dbContext.SaveChangesAsync();
            }

            return riskAnalysisOnDb;
        }
    }
}
