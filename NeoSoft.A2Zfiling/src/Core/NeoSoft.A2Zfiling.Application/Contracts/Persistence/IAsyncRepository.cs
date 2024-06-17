using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync(string include1 = "", string include2 = "", string include3 = "");
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    }
}
