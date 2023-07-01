using DesafioXamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DesafioXamarin.Views
{
    public partial class DepartamentosPage : ContentPage
    {
        DepartamentosViewModel vm;
        public DepartamentosPage()
        {
            InitializeComponent();
            BindingContext = vm = new DepartamentosViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.OnAppearing();
        }
    }
}