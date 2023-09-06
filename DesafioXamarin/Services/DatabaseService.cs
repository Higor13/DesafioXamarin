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
            try
            {
                _connection.Insert(item);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }

        public Sugestao GetSugestao(int id)
        {
            try
            {
                return _connection.Query<Sugestao>($"SELECT * FROM Sugestao WHERE Id = {id}").FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<Sugestao> GetSugestoes(bool forceRefresh = false)
        {
            try
            {
                return _connection.Query<Sugestao>("SELECT * FROM Sugestao").ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> AddDepartamentoAsync(Departamento item)
        {
            try
            {
                _connection.Query<Sugestao>($"INSERT INTO Departamento (NomeDepartamento) VALUES ('{item.NomeDepartamento}')");
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> DeleteDepartamentoAsync(int id)
        {
            try
            {
                _connection.Delete<Departamento>(id);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public Departamento GetDepartamento(int id)
        {
            try
            {
                return _connection.Get<Departamento>(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<Departamento> GetDepartamentos(bool forceRefresh = false)
        {
            try
            {
                return _connection.Table<Departamento>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> UpdateDepartamentoAsync(Departamento item)
        {
            try
            {
                _connection.Update(item);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<Sugestao> GetSugestoesPorDepartamento(string departamento)
        {
            try
            {
                return _connection.Query<Sugestao>($"SELECT * FROM Sugestao WHERE Departamento = '{departamento}'").ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}