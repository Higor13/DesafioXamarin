using DesafioXamarin.Enums;
using DesafioXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DesafioXamarin.ViewModels
{
    public class AddSugestaoViewModel : BaseViewModel
    {
        private string _nome;
        private string _titulo;
        private string _departamento;
        private string _sugestao;
        private string _justificativa;

        public Command SalvarCommand { get; }
        public Command CancelarCommand { get; }

        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        public string Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        public string Sugestao
        {
            get => _sugestao;
            set => SetProperty(ref _sugestao, value);
        }

        public string Departamento
        {
            get => _departamento;
            set => SetProperty(ref _departamento, value);
        }

        public string Justificativa
        {
            get => _justificativa;
            set => SetProperty(ref _justificativa, value);
        }

        public AddSugestaoViewModel()
        {
            SalvarCommand = new Command(SalvarAsync, ValidateSave);
            CancelarCommand = new Command(CancelarAsync);

            this.PropertyChanged +=
                (_, __) => SalvarCommand.ChangeCanExecute();
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
            Sugestao newItem = new Sugestao()
            {
                Id = Guid.NewGuid().ToString(),
                Titulo = Titulo,
                Nome = Nome,
                Departamento = DepartamentosEnum.Administrativo,
                Descricao = Sugestao,
                Justificativa = Justificativa
            };

            await DataStore.AddSugestaoAsync(newItem);

            await Shell.Current.GoToAsync("..");
        }
    }
}
