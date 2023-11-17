using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.IRepositories;
using MCV.Models.DBnhom6;
using Microsoft.EntityFrameworkCore;

namespace AppData.Repositories
{
    public class AllRepository<T> : IAllRepository<T> where T : class
    {
        private readonly DBnhom6TT context;
        private readonly DbSet<T> dbset;
        public AllRepository()
        {

        }
        public AllRepository(DBnhom6TT context, DbSet<T> dbset)
        {
            this.context = context;
            this.dbset = dbset;
        }
        public bool Add(T item)
        {
            try
            {
                dbset.Add(item);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(T item)
        {
            try
            {
                dbset.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<T> GetAll()
        {
            return dbset.ToList();
        }
        public bool Update(T item)
        {
            try
            {
                dbset.Update(item);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
