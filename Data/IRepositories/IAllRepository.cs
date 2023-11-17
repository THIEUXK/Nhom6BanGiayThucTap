using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepositories
{
    public interface IAllRepository<T>
    {
        public List<T> GetAll();
        public bool Add(T item);
        public bool Update(T item);
        public bool Delete(T item);
    }
}
