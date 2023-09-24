using MCV.Models;

namespace MCV.Services.IService
{
    public interface IShoeService
    {
        public Task<IEnumerable<Shoe>> GetAll();

        public Task<Shoe> GetProductById(Guid id);
        public Task<Shoe> AddPro(Shoe shoe);
        public Task<Shoe> UpdatePro(Shoe shoe);
        public Task DeletePro(Guid id);
    }
}
