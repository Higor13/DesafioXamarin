using SQLite;

namespace DesafioXamarin.Models
{
    [Table("Departamento")]
    public class Departamento
	{
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
		public string NomeDepartamento { get; set; }
	}
}

