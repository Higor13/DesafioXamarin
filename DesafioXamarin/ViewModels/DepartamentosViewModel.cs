using DesafioXamarin.Models;
using DesafioXamarin.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DesafioXamarin.ViewModels
{
    public class DepartamentosViewModel : BaseViewModel
    {
        public Command AddDepartamentoCommand { get; }

        List<string> _departamentos;

        public List<string> Departamentos
        {
            get => _departamentos;
            set => SetProperty(ref _departamentos, value);
        }

        public DepartamentosViewModel()
        {
            _departamentos = new List<string>
            {
                "Administrativo",
                "Financeiro",
                "RH",
                "TI",
                "Produção"
            };

            AddDepartamentoCommand = new Command(AddDepartamentoAsync);
        }

        private async void AddDepartamentoAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddDepartamentoPage));
        }
    }
}
