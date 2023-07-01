using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioXamarin.Interfaces
{
    public interface ISugestaoStore<T>
    {
        Task<bool> AddSugestaoAsync(T item);
        Task<bool> UpdateSugestaoAsync(T item);
        Task<bool> DeleteSugestaoAsync(string id);
        Task<T> GetSugestaoAsync(string id);
        Task<IEnumerable<T>> GetSugestoesAsync(bool forceRefresh = false);
    }
}
