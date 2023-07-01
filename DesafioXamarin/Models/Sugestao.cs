using System;
using DesafioXamarin.Enums;

namespace DesafioXamarin.Models
{
    public class Sugestao
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Nome { get; set; }
        public Departamento Departamento { get; set; }
        public string Descricao { get; set; }
        public string Justificativa { get; set; }
    }
}