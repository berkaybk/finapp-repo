using FinApp.API.Data;
using FinApp.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinApp.API.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SubjectRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Subject> CreateAsync(Subject subject)
        {
            await dbContext.Subjects.AddAsync(subject);
            await dbContext.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject?>
     DeleteAsync(Guid id)
        {
            var subject = await dbContext.Subjects.FirstOrDefaultAsync(x => x.Id == id);

            if (subject != null)
            {
                dbContext.Subjects.Remove(subject);
                await dbContext.SaveChangesAsync();
            }

            return subject;
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            var subjects = await dbContext.Subjects.ToListAsync();
            return subjects;
        }

        public async Task<Subject?> GetByIdAsync(Guid id)
        {
            return await dbContext.Subjects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Subject?> UpdateAsync(Guid id, Subject subject)
        {
            var subjectOnDb = await dbContext.Subjects.FirstOrDefaultAsync(x => x.Id == id);

            if (subjectOnDb != null)
            {
                subjectOnDb.AgreementId = subject.AgreementId;
                subjectOnDb.Name = subject.Name;
                subjectOnDb.Description = subject.Description;
                subjectOnDb.Cost = subject.Cost;

                await dbContext.SaveChangesAsync();
            }

            return subjectOnDb;
        }
    }
}
