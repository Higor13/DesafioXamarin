using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioXamarin.Interfaces
{
    public interface IDepartamentoStore<T>
    {
        Task<bool> AddDepartamentoAsync(T item);
        Task<bool> UpdateDepartamentoAsync(T item);
        Task<bool> DeleteDepartamentoAsync(string id);
        Task<T> GetDepartamentoAsync(string id);
        Task<IEnumerable<T>> GetDepartamentosAsync(bool forceRefresh = false);
    }
}

