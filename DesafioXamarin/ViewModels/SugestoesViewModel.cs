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
    public class SugestoesViewModel : BaseViewModel
    {
        private ObservableCollection<string> _departamentos;

        public ObservableCollection<string> Departamentos
        {
            get => _departamentos;
            set => SetProperty(ref _departamentos, value);
        }

        private Sugestao _selectedItem;

        public Sugestao SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private string _departamento;
        public string Departamento
        {
            get => _departamento;
            set => SetProperty(ref _departamento, value);
        }

        public ObservableCollection<Sugestao> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Sugestao> ItemTapped { get; }
        public Command FiltrarCommand { get; }

        public SugestoesViewModel()
        {
            Departamentos = new ObservableCollection<string>();
            Items = new ObservableCollection<Sugestao>();
            LoadItemsCommand = new Command(ExecuteLoadItemsCommand);

            ItemTapped = new Command<Sugestao>(OnItemSelected);
            FiltrarCommand = new Command(FiltarPorDepartamento);

            AddItemCommand = new Command(OnAddItem);

            Task.Run(async () => await Database.AddSugestaoAsync(new Sugestao { Titulo = "Titulo 1", Nome = "Higor", Departamento = "TI", Descricao = "Descrição da sugestão 1", Justificativa = "Justificativa 1" }));
            Task.Run(async () => await Database.AddSugestaoAsync(new Sugestao { Titulo = "Titulo 2", Nome = "João", Departamento = "Financeiro", Descricao = "Descrição da sugestão 2", Justificativa = "Justificativa 2" }));
            Task.Run(async () => await Database.AddSugestaoAsync(new Sugestao { Titulo = "Titulo 3", Nome = "José", Departamento = "Administrativo", Descricao = "Descrição da sugestão 3", Justificativa = "Justificativa 3" }));
            Task.Run(async () => await Database.AddSugestaoAsync(new Sugestao { Titulo = "Titulo 4", Nome = "Maria", Departamento = "Comercial", Descricao = "Descrição da sugestão 4", Justificativa = "Justificativa 4" }));
            Task.Run(async () => await Database.AddSugestaoAsync(new Sugestao { Titulo = "Titulo 5", Nome = "Tiago", Departamento = "RH", Descricao = "Descrição da sugestão 5", Justificativa = "Justificativa 5" }));
            Task.Run(async () => await Database.AddSugestaoAsync(new Sugestao { Titulo = "Titulo 6", Nome = "Pedro", Departamento = "Comercial", Descricao = "Descrição da sugestão 6", Justificativa = "Justificativa 6" }));
        }

        void FiltarPorDepartamento()
        {
            var result = Database.GetSugestoesPorDepartamento(Departamento);
        }

        void CarregarDepartamentos()
        {
            try
            {
                Departamentos.Clear();

                List<Departamento> result = Database.GetDepartamentos(true);
                List<string> parcialList = new List<string>();

                foreach (Departamento departamento in result)
                {
                    parcialList.Add(departamento.NomeDepartamento);
                }
                parcialList.Add("Todos");
                Departamentos = new ObservableCollection<string>(parcialList);
            }
            catch (Exception ex)
            {

            }
        }

        void ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();

                var items = Database.GetSugestoes(true);

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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;

            CarregarDepartamentos();
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddSugestaoPage));
        }

        async void OnItemSelected(Sugestao item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(SugestaoDetalhePage)}?{nameof(SugestaoDetalheViewModel.ItemId)}={item.Id}");
        }
    }
}