using DesafioXamarin.Models;
using DesafioXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DesafioXamarin.ViewModels
{
    public class AddDepartamentoViewModel : BaseViewModel
    {
        private string _departamento;
        public string Departamento
        {
            get => _departamento;
            set => SetProperty(ref _departamento, value);
        }

        public Command SalvarCommand { get; }
        public Command CancelarCommand { get; }

        public AddDepartamentoViewModel()
        {
            SalvarCommand = new Command(SalvarAsync, ValidateSave);
            CancelarCommand = new Command(CancelarAsync);

            this.PropertyChanged +=
                (_, __) => SalvarCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_departamento);
        }

        private async void CancelarAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void SalvarAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
