using DesafioXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioXamarin.Services
{
    public class MockDataStore : IDataStore<Sugestao>
    {
        readonly List<Sugestao> items;

        public MockDataStore()
        {
            items = new List<Sugestao>()
            {
                new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 1", Nome = "João", Departamento = "TI", Descricao ="This is an item description.", Justificativa = "Justificativa 1" },
                new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 2", Nome = "João", Departamento = "TI", Descricao ="This is an item description.", Justificativa = "Justificativa 2" },
                new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 3", Nome = "João", Departamento = "TI", Descricao ="This is an item description.", Justificativa = "Justificativa 3" },
                new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 4", Nome = "João", Departamento = "TI", Descricao ="This is an item description.", Justificativa = "Justificativa 4" },
                new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 5", Nome = "João", Departamento = "TI", Descricao ="This is an item description.", Justificativa = "Justificativa 5" },
                new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 6", Nome = "João", Departamento = "TI", Descricao ="This is an item description.", Justificativa = "Justificativa 6" }
            };
        }

        public async Task<bool> AddItemAsync(Sugestao item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Sugestao item)
        {
            var oldItem = items.Where((Sugestao arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Sugestao arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Sugestao> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Sugestao>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}