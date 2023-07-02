using DesafioXamarin.Models;
using DesafioXamarin.Views;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DesafioXamarin.ViewModels
{
    public class DepartamentosViewModel : BaseViewModel
    {
        public ObservableCollection<Departamento> Departamentos { get; }

        private string _semDepartamentosMsg;
        public string SemDepartamentosMsg
        {
            get => _semDepartamentosMsg;
            set => SetProperty(ref _semDepartamentosMsg, value);
        }

        private bool _isSemDepartamentosMsg;
        public bool IsSemDepartamentosMsg
        {
            get => _isSemDepartamentosMsg;
            set => SetProperty(ref _isSemDepartamentosMsg, value);
        }

        private bool _isCollectionViewVisible;
        public bool IsCollectionViewVisible
        {
            get => _isCollectionViewVisible;
            set => SetProperty(ref _isCollectionViewVisible, value);
        }

        public Command CarregarDepartamentosCommand { get; }
        public Command AddDepartamentoCommand { get; }
        public Command EditarDepartamentoCommand { get; }
        public Command ExcluirDepartamentoCommand { get; }

        public DepartamentosViewModel()
        {
            CarregarDepartamentos();

            Departamentos = new ObservableCollection<Departamento>();

            CarregarDepartamentosCommand = new Command(CarregarDepartamentos);

            AddDepartamentoCommand = new Command(async () => await AddDepartamentoAsync());
            EditarDepartamentoCommand = new Command<Departamento>(async (departamento) => await EditarDepartamentoAsync(departamento));
            ExcluirDepartamentoCommand = new Command<Departamento>(async (departamento) => await ExcluirDepartamentoAsync(departamento));
        }

        async Task EditarDepartamentoAsync(Departamento departamento)
        {
            string departamentoAsString = JsonConvert.SerializeObject(departamento);
            await Shell.Current.GoToAsync($"{nameof(EditarDepartamentoPage)}?{nameof(EditarDepartamentoViewModel.Departamento)}={departamentoAsString}");
        }

        async Task ExcluirDepartamentoAsync(Departamento departamento)
        {
            try
            {
                var resposta = await Shell.Current.DisplayAlert("Atenção!", $"Deseja excluir o departamento {departamento.NomeDepartamento}?", "Sim", "Não");

                if (resposta)
                {
                    await Database.DeleteDepartamentoAsync(departamento.Id);
                    IsBusy = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        void CarregarDepartamentos()
        {
            IsBusy = true;

            try
            {
                Departamentos.Clear();
                var items = Database.GetDepartamentos(true);

                if(items.Count > 0)
                {
                    IsCollectionViewVisible = true;
                    IsSemDepartamentosMsg = false;

                    foreach (var item in items)
                    {
                        Departamentos.Add(item);
                    }
                }
                else
                {
                    IsCollectionViewVisible = false;
                    IsSemDepartamentosMsg = true;
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task AddDepartamentoAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddDepartamentoPage));
        }
    }
}
