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
        Sugestao GetSugestao(int id);
        List<Sugestao> GetSugestoes(bool forceRefresh = false);

        Task<bool> AddDepartamentoAsync(Departamento item);
        Task<bool> UpdateDepartamentoAsync(Departamento item);
        Task<bool> DeleteDepartamentoAsync(int id);
        Task<Departamento> GetDepartamentoAsync(int id);
        List<Departamento> GetDepartamentos(bool forceRefresh = false);
    }
}
