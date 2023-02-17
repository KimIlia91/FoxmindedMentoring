using HogwartsUniversity.Models;

namespace HogwartsUniversity.Serviсes.ServiceInterfaces
{
    public interface IBaseService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int? id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
