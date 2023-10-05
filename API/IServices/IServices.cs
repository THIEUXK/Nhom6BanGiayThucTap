
namespace ShopOganicAPI.IServices
{
    public interface IServices<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> CreateListAsync(List<T> entities);
        Task<List<T>> SearchAsync(Func<T, bool> predicate);
        Task<T> FindByAttributeAsync(Func<T, bool> predicate);

    }
}
