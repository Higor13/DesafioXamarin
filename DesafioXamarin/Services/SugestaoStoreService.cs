using DesafioXamarin.Enums;
using DesafioXamarin.Interfaces;
using DesafioXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioXamarin.Services
{
    public class SugestaoStoreService : ISugestaoStore<Sugestao>
    {
        readonly List<Sugestao> sugestoesList;

        public SugestaoStoreService()
        {
            sugestoesList = new List<Sugestao>()
            {
                new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 1", Nome = "João", Departamento = new Departamento { NomeDepartamento = "TI"}, Descricao ="Descrição da sugestão 1", Justificativa = "Justificativa 1" },
                new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 2", Nome = "João", Departamento = new Departamento { NomeDepartamento = "TI"}, Descricao ="Descrição da sugestão 2", Justificativa = "Justificativa 2" },
                new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 3", Nome = "João", Departamento = new Departamento { NomeDepartamento = "TI"}, Descricao ="Descrição da sugestão 3", Justificativa = "Justificativa 3" },
                new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 4", Nome = "João", Departamento = new Departamento { NomeDepartamento = "TI"}, Descricao ="Descrição da sugestão 4", Justificativa = "Justificativa 4" },
                new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 5", Nome = "João", Departamento = new Departamento { NomeDepartamento = "TI"}, Descricao ="Descrição da sugestão 5", Justificativa = "Justificativa 5" },
                new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 6", Nome = "João", Departamento = new Departamento { NomeDepartamento = "TI"}, Descricao ="Descrição da sugestão 6", Justificativa = "Justificativa 6" }
            };
        }

        public async Task<bool> AddSugestaoAsync(Sugestao item)
        {
            sugestoesList.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateSugestaoAsync(Sugestao item)
        {
            var oldItem = sugestoesList.Where((Sugestao arg) => arg.Id == item.Id).FirstOrDefault();
            sugestoesList.Remove(oldItem);
            sugestoesList.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteSugestaoAsync(string id)
        {
            var oldItem = sugestoesList.Where((Sugestao arg) => arg.Id == id).FirstOrDefault();
            sugestoesList.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Sugestao> GetSugestaoAsync(string id)
        {
            return await Task.FromResult(sugestoesList.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Sugestao>> GetSugestoesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(sugestoesList);
        }
    }
}