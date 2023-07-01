using System;
using DesafioXamarin.Models;
using SQLite;

namespace DesafioXamarin.Database
{
	public class DatabaseContext
	{
        private SQLiteConnection _database;

        public DatabaseContext(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Departamento>();
            _database.CreateTable<Sugestao>();
        }

        public SQLiteConnection GetConnection()
        {
            return _database;
        }
    }
}

