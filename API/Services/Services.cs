using MCV.Models.DBnhom6;
using Microsoft.EntityFrameworkCore;
using ShopOganicAPI.IServices;
namespace ShopOganicAPI.Services
{
    public class Services<T> : IServices<T> where T : class
    {
        private readonly DBnhom6TT dbContext;
        private readonly DbSet<T> dbSet;

        public Services()
        {
            dbContext = new DBnhom6TT();
            dbSet = dbContext.Set<T>();
        }

        public async Task<bool> CreateAsync(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                dbSet.Remove(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                dbSet.Update(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<T>> SearchAsync(Func<T, bool> predicate)
        {
            return await Task.Run(() => dbSet.Where(predicate).ToList());
        }
        public async Task<T> FindByAttributeAsync(Func<T, bool> predicate)
        {
            return await Task.Run(() => dbSet.FirstOrDefault(predicate));
        }

        public async Task<bool> CreateListAsync(List<T> entities)
        {
            try
            {
                await dbSet.AddRangeAsync(entities);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
