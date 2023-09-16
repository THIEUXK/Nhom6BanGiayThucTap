using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;

namespace MCV.Services
{
    public class ImageService:IImageService
    {
        public DBnhom6TT _db;

        public ImageService()
        {
            _db = new DBnhom6TT();
        }
        public List<Image> GetAll()
        {
            return _db.Image.ToList();
        }

        public Image GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.id == id);
        }

        public bool Create(Image a)
        {
            try
            {
                _db.Image.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Image a)
        {
            try
            {
                _db.Image.Update(a);
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
                _db.Image.Remove(b);
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
