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
        public ObservableCollection<Sugestao> Items { get; }

        public Command AddDepartamentoCommand { get; }

        List<string> _departamentos;

        public List<string> Departamentos
        {
            get => _departamentos;
            set => SetProperty(ref _departamentos, value);
        }

        public DepartamentosViewModel()
        {
            Items = new ObservableCollection<Sugestao>();

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

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await SugestoesDataStore.GetSugestoesAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
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
