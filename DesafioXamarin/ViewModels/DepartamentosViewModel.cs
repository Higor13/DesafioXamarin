using DesafioXamarin.Models;
using DesafioXamarin.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DesafioXamarin.ViewModels
{
    public class DepartamentosViewModel : BaseViewModel
    {
        public ObservableCollection<Departamento> Departamentos { get; }

        public Command LoadItemsCommand { get; }
        public Command AddDepartamentoCommand { get; }
        public Command EditarDepartamentoCommand { get; }
        public Command ExcluirDepartamentoCommand { get; }

        public DepartamentosViewModel()
        {
            Task.Run(async () => await ExecuteLoadItemsCommand());

            Departamentos = new ObservableCollection<Departamento>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            AddDepartamentoCommand = new Command(AddDepartamentoAsync);
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
            var resposta = await Shell.Current.DisplayAlert("Atenção!", $"Deseja excluir o departamento {departamento.NomeDepartamento}?","Sim", "Não");

            if (resposta)
            {
                await Database.DeleteDepartamentoAsync(departamento.Id);
                IsBusy = true;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Departamentos.Clear();
                var items = await Database.GetDepartamentosAsync(true);
                foreach (var item in items)
                {
                    Departamentos.Add(item);
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

        private async void AddDepartamentoAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddDepartamentoPage));
        }
    }
}
