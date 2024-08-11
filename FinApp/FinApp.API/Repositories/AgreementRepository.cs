
using FinApp.API.Data;
using FinApp.API.Models.Domain;
using FinApp.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinApp.API.Repositories
{
    public class AgreementRepository : IAgreementRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AgreementRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Agreement> CreateAsync(Agreement agreement)
        {
            await dbContext.Agreements.AddAsync(agreement);
            await dbContext.SaveChangesAsync();
            return agreement;
        }

        public async Task<Agreement?> DeleteAsync(Guid id)
        {
            var agreement = await dbContext.Agreements.FirstOrDefaultAsync(x => x.Id == id);

            if (agreement != null)
            {
                dbContext.Agreements.Remove(agreement);
                await dbContext.SaveChangesAsync();
            }

            return agreement;
        }

        public async Task<List<Agreement>> GetAllAsync()
        {
            var agreements = await dbContext.Agreements.ToListAsync();
            return agreements;
        }

        public async Task<Agreement?> GetByIdAsync(Guid id)
        {
            return await dbContext.Agreements.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Agreement?> UpdateAsync(Guid id, Agreement agreement)
        {
            var agreementOnDb = await dbContext.Agreements.FirstOrDefaultAsync(x => x.Id == id);

            if (agreementOnDb != null)
            {
                agreementOnDb.Name = agreement.Name;
                agreementOnDb.Keywords = agreement.Keywords;
                agreementOnDb.RiskLevelId = agreement.RiskLevelId;
                agreementOnDb.Amount = agreement.Amount;
                agreementOnDb.StartDate = agreement.StartDate;
                agreementOnDb.EndDate = agreement.EndDate;

                await dbContext.SaveChangesAsync();
            }

            return agreementOnDb;
        }
    }
}
