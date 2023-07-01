using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioXamarin.Models;

namespace DesafioXamarin.Interfaces
{
    public interface IDatabase
    {
        Task<bool> AddSugestaoAsync(Sugestao item);
        Task<bool> UpdateSugestaoAsync(Sugestao item);
        Task<bool> DeleteSugestaoAsync(string id);
        Task<Sugestao> GetSugestaoAsync(string id);
        Task<IEnumerable<Sugestao>> GetSugestoesAsync(bool forceRefresh = false);

        Task<bool> AddDepartamentoAsync(Departamento item);
        Task<bool> UpdateDepartamentoAsync(Departamento item);
        Task<bool> DeleteDepartamentoAsync(string id);
        Task<Departamento> GetDepartamentoAsync(string id);
        Task<IEnumerable<Departamento>> GetDepartamentosAsync(bool forceRefresh = false);
    }
}
