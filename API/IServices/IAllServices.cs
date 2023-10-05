namespace API.IServices
{
    public interface IAllServices<T> where T : class
    {
        public List<T> GetAll();
        public bool Add(T item);
        public bool Delete(T item);
        public bool Update(T item);
        public List<T> GetById(Guid id);
        public List<T> SearchAsync(Func<T, bool> predicate);
    }
}
