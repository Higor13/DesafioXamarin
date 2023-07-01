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
        Task<bool> DeleteSugestaoAsync(int id);
        Task<Sugestao> GetSugestaoAsync(int id);
        Task<IEnumerable<Sugestao>> GetSugestoesAsync(bool forceRefresh = false);

        Task<bool> AddDepartamentoAsync(Departamento item);
        Task<bool> UpdateDepartamentoAsync(Departamento item);
        Task<bool> DeleteDepartamentoAsync(int id);
        Task<Departamento> GetDepartamentoAsync(int id);
        Task<IEnumerable<Departamento>> GetDepartamentosAsync(bool forceRefresh = false);
    }
}
