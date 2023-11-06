using MCV.Models.DBnhom6;
using Microsoft.EntityFrameworkCore;
using ShopOganicAPI.IServices;

namespace AppAPI.Services
{
    public class AllServices<T> : IAllServices<T> where T : class

    {
        private readonly DBnhom6TT context;
        private readonly DbSet<T> dbSet;

        public AllServices()
        {
        }

        public AllServices(DBnhom6TT context, DbSet<T> dbSet)
        {
            this.context = context;
            this.dbSet = dbSet;
        }

        public bool Add(T item)
        {
            try
            {
                dbSet.Add(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(T item)
        {
            try
            {
                dbSet.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public List<T> GetById(Guid id)
        {
            return dbSet.ToList();
        }

        public List<T> SearchAsync(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(T item)
        {
            try
            {
                dbSet.Update(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}