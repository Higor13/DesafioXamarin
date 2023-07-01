using System;
using System.Diagnostics;
using DesafioXamarin.Models;
using Xamarin.Forms;

namespace DesafioXamarin.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class SugestaoDetalheViewModel : BaseViewModel
	{
        private string _nome;
        private string _titulo;
        private string _departamento;
        private string _sugestao;
        private string _justificativa;

        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        public string Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        public string Sugestao
        {
            get => _sugestao;
            set => SetProperty(ref _sugestao, value);
        }

        public string Departamento
        {
            get => _departamento;
            set => SetProperty(ref _departamento, value);
        }

        public string Justificativa
        {
            get => _justificativa;
            set => SetProperty(ref _justificativa, value);
        }

        private string itemId;
        public string Id { get; set; }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                Sugestao item = await Database.GetSugestaoAsync(itemId);
                Nome = item.Nome;
                Titulo = item.Titulo;
                Sugestao = item.Descricao;
                Departamento = item.Departamento.ToString();
                Justificativa = item.Justificativa;
            }
            catch (Exception)
            {
                Debug.WriteLine("Falha ao carregar item");
            }
        }
    }
}

