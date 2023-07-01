using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioXamarin.Enums;
using DesafioXamarin.Interfaces;
using DesafioXamarin.Models;

namespace DesafioXamarin.Services
{
    public class DepartamentoStoreService : IDepartamentoStore<Departamento>
    {
        readonly List<Departamento> departamentosList;

        public DepartamentoStoreService()
        {
            departamentosList = new List<Departamento>()
            {
                new Departamento { Id = Guid.NewGuid().ToString(), NomeDepartamento = "Administrativo" },
                new Departamento { Id = Guid.NewGuid().ToString(), NomeDepartamento = "Comercial" },
                new Departamento { Id = Guid.NewGuid().ToString(), NomeDepartamento = "Financeiro" },
                new Departamento { Id = Guid.NewGuid().ToString(), NomeDepartamento = "RH" },
                new Departamento { Id = Guid.NewGuid().ToString(), NomeDepartamento = "TI" },
                new Departamento { Id = Guid.NewGuid().ToString(), NomeDepartamento = "Producao" }
            };
        }

        public async Task<bool> AddDepartamentoAsync(Departamento item)
        {
            departamentosList.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteDepartamentoAsync(string id)
        {
            var oldItem = departamentosList.Where((Departamento arg) => arg.Id == id).FirstOrDefault();
            departamentosList.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Departamento> GetDepartamentoAsync(string id)
        {
            return await Task.FromResult(departamentosList.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentosAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(departamentosList);
        }

        public async Task<bool> UpdateDepartamentoAsync(Departamento item)
        {
            var oldItem = departamentosList.Where((Departamento arg) => arg.Id == item.Id).FirstOrDefault();
            departamentosList.Remove(oldItem);
            departamentosList.Add(item);

            return await Task.FromResult(true);
        }
    }
}

