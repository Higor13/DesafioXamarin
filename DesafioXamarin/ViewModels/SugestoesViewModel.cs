﻿using DesafioXamarin.Models;
using DesafioXamarin.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DesafioXamarin.ViewModels
{
    public class SugestoesViewModel : BaseViewModel
    {
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

        public ObservableCollection<Sugestao> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Sugestao> ItemTapped { get; }

        public SugestoesViewModel()
        {
            Items = new ObservableCollection<Sugestao>();
            LoadItemsCommand = new Command(ExecuteLoadItemsCommand);

            ItemTapped = new Command<Sugestao>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
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
            //await Shell.Current.GoToAsync(nameof(SugestaoDetalhePage));
        }
    }
}