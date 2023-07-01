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
        }

        public async Task<bool> AddSugestaoAsync(Sugestao item)
        {
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

        public Sugestao GetSugestao(int id)
        {
            return _connection.Get<Sugestao>(id);
        }

        public List<Sugestao> GetSugestoes(bool forceRefresh = false)
        {
            return _connection.Table<Sugestao>().ToList();
        }

        public async Task<bool> AddDepartamentoAsync(Departamento item)
        {
            _connection.Insert(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteDepartamentoAsync(int id)
        {
            _connection.Delete<Departamento>(id);

            return await Task.FromResult(true);
        }

        public Departamento GetDepartamento(int id)
        {
            return _connection.Get<Departamento>(id);
        }

        public List<Departamento> GetDepartamentos(bool forceRefresh = false)
        {
            return _connection.Table<Departamento>().ToList();
        }

        public async Task<bool> UpdateDepartamentoAsync(Departamento item)
        {
            _connection.Update(item);

            return await Task.FromResult(true);
        }
    }
}