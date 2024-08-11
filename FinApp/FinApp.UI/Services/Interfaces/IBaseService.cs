namespace FinApp.UI.Services.Interfaces {
    public interface IBaseService<T> {
        Task<List<T>> GetAllAsync();

        Task<T?> GetByIdAsync(Guid id);

        Task<T?> CreateAsync(T data);

        Task<T?> UpdateAsync(T data);

        Task<T?> DeleteAsync(Guid id);
    }
}
