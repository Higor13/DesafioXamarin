using DesafioXamarin.Models;
using DesafioXamarin.ViewModels;
using DesafioXamarin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesafioXamarin.Views
{
    public partial class SugestoesPage : ContentPage
    {
        SugestoesViewModel _viewModel;

        public SugestoesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new SugestoesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}