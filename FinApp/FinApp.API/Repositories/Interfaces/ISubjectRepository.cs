using FinApp.API.Models.Domain;

namespace FinApp.API.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllAsync();
        Task<Subject?> GetByIdAsync(Guid id);
        Task<Subject> CreateAsync(Subject subject);
        Task<Subject?> UpdateAsync(Guid id, Subject subject);
        Task<Subject?> DeleteAsync(Guid id);
    }
}
