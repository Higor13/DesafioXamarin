using System;
using System.Threading.Tasks;
using DesafioXamarin.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace DesafioXamarin.ViewModels
{
    [QueryProperty(nameof(Departamento), nameof(Departamento))]
    public class EditarDepartamentoViewModel : BaseViewModel
	{
        Departamento _departamentoParameter;

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

        public Command SalvarCommand { get; }
        public Command CancelarCommand { get; }

        public EditarDepartamentoViewModel()
        {
            SalvarCommand = new Command(async () => await SalvarAsync(), ValidateSave);
            CancelarCommand = new Command(async () => await CancelarAsync());

            this.PropertyChanged +=
                (_, __) => SalvarCommand.ChangeCanExecute();
        }

        void DeserializeDepartamento(string value)
        {
            _departamentoParameter = JsonConvert.DeserializeObject<Departamento>(value);
            NomeDepartamento = _departamentoParameter.NomeDepartamento;
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_nomeDepartamento);
        }

        private async Task CancelarAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async Task SalvarAsync()
        {
            try
            {
                Departamento novoDepartamento = new Departamento()
                {
                    Id = _departamentoParameter.Id,
                    NomeDepartamento = NomeDepartamento
                };

                await Database.UpdateDepartamentoAsync(novoDepartamento);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

