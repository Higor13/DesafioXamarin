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

        private string _departamento;
        public string Departamento
        {
            get => _departamento;
            set => SetProperty(ref _departamento, value);
        }

        private ObservableCollection<Sugestao> _items;
        public ObservableCollection<Sugestao> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public Command CarregarSugestoesCommand { get; }
        public Command AddSugestaoCommand { get; }
        public Command<Sugestao> SugestaoSelecionadaCommand { get; }
        public Command FiltrarCommand { get; }

        public SugestoesViewModel()
        {
            Departamentos = new ObservableCollection<string>();
            Items = new ObservableCollection<Sugestao>();

            CarregarSugestoesCommand = new Command(CarregarSugestoes);
            SugestaoSelecionadaCommand = new Command<Sugestao>(async (item) => await OnSugestaoSelecionadaAsync(item));
            FiltrarCommand = new Command(FiltarPorDepartamento);
            AddSugestaoCommand = new Command(async () => await AddSugestaoAsync());
        }

        void FiltarPorDepartamento()
        {
            try
            {
                Items.Clear();

                if(Departamento == "Todos")
                {
                    CarregarSugestoes();
                }
                else
                {
                    List<Sugestao> result = Database.GetSugestoesPorDepartamento(Departamento);
                    Items = new ObservableCollection<Sugestao>(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
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
                Console.WriteLine(ex);
            }
        }

        void CarregarSugestoes()
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

            CarregarDepartamentos();
        }

        private async Task AddSugestaoAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddSugestaoPage));
        }

        async Task OnSugestaoSelecionadaAsync(Sugestao item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(SugestaoDetalhePage)}?{nameof(SugestaoDetalheViewModel.ItemId)}={item.Id}");
        }
    }
}