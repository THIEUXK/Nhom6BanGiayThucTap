using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;

namespace MCV.Services
{
    public class RoleService : IRoleService
    {

        public DBnhom6TT _db;

        public RoleService()
        {
            _db = new DBnhom6TT();
        }

        public List<Role> GetAll()
        {
            return _db.Role.ToList();
        }

        public Role GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.id == id);
        }

        public bool Create(Role a)
        {
            try
            {
                _db.Role.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Role a)
        {
            try
            {
                _db.Role.Update(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var b = GetById(id);
                _db.Role.Remove(b);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
