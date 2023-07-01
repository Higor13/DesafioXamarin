using System;
using DesafioXamarin.Enums;

namespace DesafioXamarin.Models
{
	public class Departamento
	{
		public string Id { get; set; }
		public DepartamentosEnum NomeDepartamento { get; set; }
		public DateTime DataInclusao { get; set; }
	}
}

