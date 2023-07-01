using DesafioXamarin.Models;
using DesafioXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DesafioXamarin.ViewModels
{
    public class DepartamentosViewModel : BaseViewModel
    {
        public ObservableCollection<Departamento> Departamentos { get; }

        public Command LoadItemsCommand { get; }
        public Command AddDepartamentoCommand { get; }

        public DepartamentosViewModel()
        {
            Departamentos = new ObservableCollection<Departamento>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            AddDepartamentoCommand = new Command(AddDepartamentoAsync);
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
