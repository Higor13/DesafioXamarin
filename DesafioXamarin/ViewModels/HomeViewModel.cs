using DesafioXamarin.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DesafioXamarin.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            Title = "Home";

            CarregarDadosIniciais();
        }

        void CarregarDadosIniciais()
        {
            if (!Preferences.Get("carregarDadosIniciais", false))
            {
                Task.Run(async () => await Database.AddSugestaoAsync(new Sugestao { Titulo = "Titulo 1", Nome = "Higor", Departamento = "TI", Descricao = "Descrição da sugestão 1", Justificativa = "Justificativa 1" }));
                Task.Run(async () => await Database.AddSugestaoAsync(new Sugestao { Titulo = "Titulo 2", Nome = "João", Departamento = "Financeiro", Descricao = "Descrição da sugestão 2", Justificativa = "Justificativa 2" }));
                Task.Run(async () => await Database.AddSugestaoAsync(new Sugestao { Titulo = "Titulo 3", Nome = "José", Departamento = "Administrativo", Descricao = "Descrição da sugestão 3", Justificativa = "Justificativa 3" }));
                Task.Run(async () => await Database.AddSugestaoAsync(new Sugestao { Titulo = "Titulo 4", Nome = "Maria", Departamento = "Comercial", Descricao = "Descrição da sugestão 4", Justificativa = "Justificativa 4" }));
                Task.Run(async () => await Database.AddSugestaoAsync(new Sugestao { Titulo = "Titulo 5", Nome = "Tiago", Departamento = "RH", Descricao = "Descrição da sugestão 5", Justificativa = "Justificativa 5" }));
                Task.Run(async () => await Database.AddSugestaoAsync(new Sugestao { Titulo = "Titulo 6", Nome = "Pedro", Departamento = "Comercial", Descricao = "Descrição da sugestão 6", Justificativa = "Justificativa 6" }));

                Task.Run(async () => await Database.AddDepartamentoAsync(new Departamento { NomeDepartamento = "Administrativo" }));
                Task.Run(async () => await Database.AddDepartamentoAsync(new Departamento { NomeDepartamento = "Comercial" }));
                Task.Run(async () => await Database.AddDepartamentoAsync(new Departamento { NomeDepartamento = "Financeiro" }));
                Task.Run(async () => await Database.AddDepartamentoAsync(new Departamento { NomeDepartamento = "RH" }));
                Task.Run(async () => await Database.AddDepartamentoAsync(new Departamento { NomeDepartamento = "TI" }));
                Task.Run(async () => await Database.AddDepartamentoAsync(new Departamento { NomeDepartamento = "Producao" }));

                Preferences.Set("carregarDadosIniciais", true);
            }
        }
    }
}