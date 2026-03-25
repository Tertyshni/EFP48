namespace EFP48.DapperCore.Entity
{
        public interface IRepository<T>
        {
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> GetByIdAsync(int id);
            Task<int> CreateAsync(T entity);
            Task<int> UpdateAsync(T entity);
            Task<int> DeleteAsync(int id);
        }
}
