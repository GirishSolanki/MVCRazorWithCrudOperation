namespace ACMESOFT.IService
{
    public interface IServices<T> where T : class
    {
        public T Insert(T entity);

        public List<T> List(T entity);

        public T GetById(T entity);

        public bool Delete(T entity);
    }
}
