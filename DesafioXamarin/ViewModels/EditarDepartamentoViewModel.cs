using System;
using DesafioXamarin.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace DesafioXamarin.ViewModels
{
    [QueryProperty(nameof(Departamento), nameof(Departamento))]
    public class EditarDepartamentoViewModel : BaseViewModel
	{
        Departamento departamentoParameter;

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
            set
            {
                _departamento = value;
                DeserializeDepartamento(value);
            }
        }

        void DeserializeDepartamento(string value)
        {
            departamentoParameter = JsonConvert.DeserializeObject<Departamento>(value);
            NomeDepartamento = departamentoParameter.NomeDepartamento;
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
                    Id = departamentoParameter.Id,
                    NomeDepartamento = NomeDepartamento,
                    DataInclusao = DateTime.Now,
                };

                await DepartamentoDataStore.UpdateDepartamentoAsync(newDepartamento);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {

            }
        }
    }
}

