using DesafioXamarin.Models;
using DesafioXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static SQLite.SQLite3;

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

        private bool _isSemSugestoesMsgVisible;
        public bool IsSemSugestoesMsgVisible
        {
            get => _isSemSugestoesMsgVisible;
            set => SetProperty(ref _isSemSugestoesMsgVisible, value);
        }

        private bool _isCollectionViewVisible;
        public bool IsCollectionViewVisible
        {
            get => _isCollectionViewVisible;
            set => SetProperty(ref _isCollectionViewVisible, value);
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
            FiltrarCommand = new Command(FiltrarPorDepartamento);
            AddSugestaoCommand = new Command(async () => await AddSugestaoAsync());
        }

        void FiltrarPorDepartamento()
        {
            try
            {
                if (!string.IsNullOrEmpty(Departamento))
                {
                    Preferences.Set("departamentoFiltroSelecionado", Departamento);
                }
                
                Items.Clear();

                if(Preferences.Get("departamentoFiltroSelecionado", string.Empty) == "Todos")
                {
                    CarregarSugestoes();
                }
                else if(!string.IsNullOrEmpty(Preferences.Get("departamentoFiltroSelecionado", string.Empty)))
                {
                    Departamento = Preferences.Get("departamentoFiltroSelecionado", string.Empty);
                    CarregarSugestoesPorFiltro();
                }
                else
                {
                    CarregarSugestoes();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        void CarregarSugestoesPorFiltro()
        {
            IsBusy = true;

            try
            {
                Items.Clear();

                IsCollectionViewVisible = true;
                IsSemSugestoesMsgVisible = false;

                List<Sugestao> result = Database.GetSugestoesPorDepartamento(Preferences.Get("departamentoFiltroSelecionado", string.Empty));

                ChecarQuantidadeSugestoes(result);
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

        private void ChecarQuantidadeSugestoes(List<Sugestao> result)
        {
            try
            {
                if (result.Count > 0)
                {
                    foreach (var item in result)
                    {
                        Items.Add(item);
                    }
                }
                else
                {
                    IsCollectionViewVisible = false;
                    IsSemSugestoesMsgVisible = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        void CarregarDepartamentos()
        {
            try
            {
                Departamentos.Clear();

                List<Departamento> result = Database.GetDepartamentos(true);
                List<string> parcialList = new List<string>();

                if (result.Count > 0)
                {

                    foreach (Departamento departamento in result)
                    {
                        parcialList.Add(departamento.NomeDepartamento);
                    }
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

                IsCollectionViewVisible = true;
                IsSemSugestoesMsgVisible = false;

                var items = Database.GetSugestoes(true);

                ChecarQuantidadeSugestoes(items);
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