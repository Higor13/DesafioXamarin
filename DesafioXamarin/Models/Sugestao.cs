using System;
using DesafioXamarin.Enums;
using SQLite;

namespace DesafioXamarin.Models
{
    [Table("Sugestao")]
    public class Sugestao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Nome { get; set; }
        public string Departamento { get; set; }
        public string Descricao { get; set; }
        public string Justificativa { get; set; }
    }
}