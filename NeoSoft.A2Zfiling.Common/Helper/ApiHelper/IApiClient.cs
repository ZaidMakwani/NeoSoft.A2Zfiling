using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Common.Helper.ApiHelper
{
    public interface IApiClient<T>
    {
        Task<Response<IEnumerable<T>>> GetAllAsync(string apiUrl);
        Task<PagedResponse<IEnumerable<T>>> GetPagedAsync(string apiUrl);
        Task<Response<T>> GetByIdAsync(string apiUrl);
        Task<Response<T>> PostAsync<TEntity>(string apiUrl, TEntity entity);
        // for Account
        Task<T> PostAuthAsync<TEntity>(string apiUrl, TEntity entity);
        Task<Response<T>> PutAsync<TEntity>(string apiUrl, TEntity entity);
        Task<string> DeleteAsync(string apiUrl);
    }
}
