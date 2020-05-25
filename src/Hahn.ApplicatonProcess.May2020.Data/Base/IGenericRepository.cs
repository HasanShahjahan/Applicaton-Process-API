using Hahn.ApplicatonProcess.May2020.Entities;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Data.Base
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        Task<T> GetItemByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> RemoveAsync(T entity);
    }
}
