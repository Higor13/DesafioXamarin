﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioXamarin.Models;

namespace DesafioXamarin.Interfaces
{
    public interface IDatabase
    {
        Task<bool> AddSugestaoAsync(Sugestao item);
        Sugestao GetSugestao(int id);
        List<Sugestao> GetSugestoes(bool forceRefresh = false);
        List<Sugestao> GetSugestoesPorDepartamento(string departamento);

        Task<bool> AddDepartamentoAsync(Departamento item);
        Task<bool> UpdateDepartamentoAsync(Departamento item);
        Task<bool> DeleteDepartamentoAsync(int id);
        Departamento GetDepartamento(int id);
        List<Departamento> GetDepartamentos(bool forceRefresh = false);
    }
}
