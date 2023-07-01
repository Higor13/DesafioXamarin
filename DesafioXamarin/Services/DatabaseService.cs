using DesafioXamarin.Enums;
using DesafioXamarin.Interfaces;
using DesafioXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioXamarin.Services
{
    public class DatabaseService : IDatabase
    {
        readonly List<Sugestao> sugestoesList;
        readonly List<Departamento> departamentosList;
        SQLiteConnection _connection;

        public DatabaseService()
        {
            _connection = App.Database.GetConnection();

            //sugestoesList = new List<Sugestao>()
            //{
            //    new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 1", Nome = "João", Departamento = new Departamento { NomeDepartamento = "TI"}, Descricao ="Descrição da sugestão 1", Justificativa = "Justificativa 1" },
            //    new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 2", Nome = "João", Departamento = new Departamento { NomeDepartamento = "TI"}, Descricao ="Descrição da sugestão 2", Justificativa = "Justificativa 2" },
            //    new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 3", Nome = "João", Departamento = new Departamento { NomeDepartamento = "TI"}, Descricao ="Descrição da sugestão 3", Justificativa = "Justificativa 3" },
            //    new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 4", Nome = "João", Departamento = new Departamento { NomeDepartamento = "TI"}, Descricao ="Descrição da sugestão 4", Justificativa = "Justificativa 4" },
            //    new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 5", Nome = "João", Departamento = new Departamento { NomeDepartamento = "TI"}, Descricao ="Descrição da sugestão 5", Justificativa = "Justificativa 5" },
            //    new Sugestao { Id = Guid.NewGuid().ToString(), Titulo = "Titulo 6", Nome = "João", Departamento = new Departamento { NomeDepartamento = "TI"}, Descricao ="Descrição da sugestão 6", Justificativa = "Justificativa 6" }
            //};

            //departamentosList = new List<Departamento>()
            //{
            //    new Departamento { Id = Guid.NewGuid().ToString(), NomeDepartamento = "Administrativo" },
            //    new Departamento { Id = Guid.NewGuid().ToString(), NomeDepartamento = "Comercial" },
            //    new Departamento { Id = Guid.NewGuid().ToString(), NomeDepartamento = "Financeiro" },
            //    new Departamento { Id = Guid.NewGuid().ToString(), NomeDepartamento = "RH" },
            //    new Departamento { Id = Guid.NewGuid().ToString(), NomeDepartamento = "TI" },
            //    new Departamento { Id = Guid.NewGuid().ToString(), NomeDepartamento = "Producao" }
            //};
        }

        public async Task<bool> AddSugestaoAsync(Sugestao item)
        {
            //sugestoesList.Add(item);

            _connection.Insert(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateSugestaoAsync(Sugestao item)
        {
            var oldItem = sugestoesList.Where((Sugestao arg) => arg.Id == item.Id).FirstOrDefault();
            sugestoesList.Remove(oldItem);
            sugestoesList.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteSugestaoAsync(int id)
        {
            var oldItem = sugestoesList.Where((Sugestao arg) => arg.Id == id).FirstOrDefault();
            sugestoesList.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Sugestao> GetSugestaoAsync(int id)
        {
            return await Task.FromResult(sugestoesList.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Sugestao>> GetSugestoesAsync(bool forceRefresh = false)
        {
            //return await Task.FromResult(sugestoesList);
            return _connection.Table<Sugestao>().ToList();
        }

        public async Task<bool> AddDepartamentoAsync(Departamento item)
        {
            departamentosList.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteDepartamentoAsync(int id)
        {
            var oldItem = departamentosList.Where((Departamento arg) => arg.Id == id).FirstOrDefault();
            departamentosList.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Departamento> GetDepartamentoAsync(int id)
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