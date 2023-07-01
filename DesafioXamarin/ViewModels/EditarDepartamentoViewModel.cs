using System;
using DesafioXamarin.Models;
using Xamarin.Forms;

namespace DesafioXamarin.ViewModels
{
    [QueryProperty(nameof(Departamento), nameof(Departamento))]
    public class EditarDepartamentoViewModel : BaseViewModel
	{
        private string _nomeDepartamento;
        public string NomeDepartamento
        {
            get => _nomeDepartamento;
            set => SetProperty(ref _nomeDepartamento, value);
        }

        private string _departamento;
        public string Departamento
        {
            get
            {
                return _departamento;
            }
            set => SetProperty(ref _departamento, value);
        }

        public Command SalvarCommand { get; }
        public Command CancelarCommand { get; }

        public EditarDepartamentoViewModel()
        {
            SalvarCommand = new Command(SalvarAsync, ValidateSave);
            CancelarCommand = new Command(CancelarAsync);

            this.PropertyChanged +=
                (_, __) => SalvarCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_nomeDepartamento);
        }

        private async void CancelarAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void SalvarAsync()
        {
            try
            {
                Departamento newDepartamento = new Departamento()
                {
                    Id = Guid.NewGuid().ToString(),
                    NomeDepartamento = NomeDepartamento,
                    DataInclusao = DateTime.Now,
                };

                await DepartamentoDataStore.AddDepartamentoAsync(newDepartamento);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {

            }
        }
    }
}

