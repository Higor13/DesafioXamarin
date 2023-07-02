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
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        private string _titulo;
        public string Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        private string _sugestao;
        public string Sugestao
        {
            get => _sugestao;
            set => SetProperty(ref _sugestao, value);
        }

        private string _departamento;
        public string Departamento
        {
            get => _departamento;
            set => SetProperty(ref _departamento, value);
        }

        private string _justificativa;
        public string Justificativa
        {
            get => _justificativa;
            set => SetProperty(ref _justificativa, value);
        }

        private int _itemId;
        public int ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;
                CarregarSugestaoId(value);
            }
        }

        public void CarregarSugestaoId(int sugestaoId)
        {
            try
            {
                Sugestao item = Database.GetSugestao(sugestaoId);

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

