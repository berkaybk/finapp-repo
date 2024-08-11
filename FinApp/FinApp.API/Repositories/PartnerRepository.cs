using FinApp.API.Data;
using FinApp.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinApp.API.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PartnerRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Partner> CreateAsync(Partner partner)
        {
            await dbContext.Partners.AddAsync(partner);
            await dbContext.SaveChangesAsync();
            return partner;
        }

        public async Task<Partner?>
     DeleteAsync(Guid id)
        {
            var partner = await dbContext.Partners.FirstOrDefaultAsync(x => x.Id == id);

            if (partner != null)
            {
                dbContext.Partners.Remove(partner);
                await dbContext.SaveChangesAsync();
            }

            return partner;
        }

        public async Task<List<Partner>> GetAllAsync()
        {
            var partners = await dbContext.Partners.ToListAsync();
            return partners;
        }

        public async Task<Partner?> GetByIdAsync(Guid id)
        {
            return await dbContext.Partners.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Partner?> UpdateAsync(Guid id, Partner partner)
        {
            var partnerOnDb = await dbContext.Partners.FirstOrDefaultAsync(x => x.Id == id);

            if (partnerOnDb != null)
            {
                partnerOnDb.Name = partner.Name;
                partnerOnDb.Email = partner.Email;
                partnerOnDb.Phone = partner.Phone;

                await dbContext.SaveChangesAsync();
            }

            return partnerOnDb;
        }
    }
}
