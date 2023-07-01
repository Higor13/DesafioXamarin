using DesafioXamarin.Enums;
using DesafioXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DesafioXamarin.ViewModels
{
    public class AddSugestaoViewModel : BaseViewModel
    {
        private ObservableCollection<string> _departamentos;
        public ObservableCollection<string> Departamentos
        {
            get => _departamentos;
            set => SetProperty(ref _departamentos, value);
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        private string _titulo;
        public string Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        private string _sugestao;
        public string Sugestao
        {
            get => _sugestao;
            set => SetProperty(ref _sugestao, value);
        }

        private string _departamento;
        public string Departamento
        {
            get => _departamento;
            set => SetProperty(ref _departamento, value);
        }

        private string _justificativa;
        public string Justificativa
        {
            get => _justificativa;
            set => SetProperty(ref _justificativa, value);
        }

        public Command SalvarCommand { get; }
        public Command CancelarCommand { get; }

        public AddSugestaoViewModel()
        {
            Departamentos = new ObservableCollection<string>();
            CarregarDepartamentos();

            SalvarCommand = new Command(SalvarAsync, ValidateSave);
            CancelarCommand = new Command(CancelarAsync);

            this.PropertyChanged +=
                (_, __) => SalvarCommand.ChangeCanExecute();
        }

        void CarregarDepartamentos()
        {
            try
            {
                Departamentos.Clear();

                List<Departamento> result = Database.GetDepartamentos(true);
                List<string> parcialList = new List<string>();

                foreach (Departamento departamento in result)
                {
                    parcialList.Add(departamento.NomeDepartamento);
                }
                parcialList.Add("Todos");
                Departamentos = new ObservableCollection<string>(parcialList);
            }
            catch (Exception ex)
            {

            }
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_nome)
                && !String.IsNullOrWhiteSpace(_sugestao)
                && !String.IsNullOrWhiteSpace(_justificativa);
        }

        private async void CancelarAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void SalvarAsync()
        {
            Sugestao novoItem = new Sugestao()
            {
                Titulo = Titulo,
                Nome = Nome,
                Departamento = Departamento,
                Descricao = Sugestao,
                Justificativa = Justificativa
            };

            await Database.AddSugestaoAsync(novoItem);

            await Shell.Current.GoToAsync("..");
        }
    }
}
