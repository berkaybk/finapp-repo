using FinApp.API.Data;
using FinApp.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinApp.API.Repositories
{
    public class FinancialStatementRepository : IFinancialStatementRepository
    {
        private readonly ApplicationDbContext dbContext;

        public FinancialStatementRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<FinancialStatement> CreateAsync(FinancialStatement financialStatement)
        {
            await dbContext.FinancialStatements.AddAsync(financialStatement);
            await dbContext.SaveChangesAsync();
            return financialStatement;
        }

        public async Task<FinancialStatement?> DeleteAsync(Guid id)
        {
            var financialStatement = await dbContext.FinancialStatements.FirstOrDefaultAsync(x => x.Id == id);

            if (financialStatement != null)
            {
                dbContext.FinancialStatements.Remove(financialStatement);
                await dbContext.SaveChangesAsync();
            }

            return financialStatement;
        }

        public async Task<List<FinancialStatement>> GetAllAsync()
        {
            var financialStatements = await dbContext.FinancialStatements.ToListAsync();
            return financialStatements;
        }

        public async Task<FinancialStatement?> GetByIdAsync(Guid id)
        {
            return await dbContext.FinancialStatements.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FinancialStatement?> UpdateAsync(Guid id, FinancialStatement financialStatement)
        {
            var financialStatementOnDb = await dbContext.FinancialStatements.FirstOrDefaultAsync(x => x.Id == id);

            if (financialStatementOnDb != null)
            {
                financialStatementOnDb.AgreementId = financialStatement.AgreementId;
                financialStatementOnDb.Revenue = financialStatement.Revenue;
                financialStatementOnDb.Expenses = financialStatement.Expenses;
                financialStatementOnDb.NetIncome = financialStatement.NetIncome;

                await dbContext.SaveChangesAsync();
            }

            return financialStatementOnDb;
        }
    }
}
