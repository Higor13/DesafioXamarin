using DesafioXamarin.Models;
using DesafioXamarin.Views;
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

        //public ICommand EditarDepartamentoCommand { get; private set; }
        //public ICommand ExcluirDepartamentoCommand { get; private set; }

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
            await Shell.Current.GoToAsync(nameof(EditarDepartamentoPage));
        }

        async Task ExcluirDepartamentoAsync(Departamento departamento)
        {
            // Add Display alert
            await Shell.Current.GoToAsync(nameof(AddDepartamentoPage));
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
                var items = await DepartamentoDataStore.GetDepartamentosAsync(true);
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
