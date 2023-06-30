using DesafioXamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DesafioXamarin.Views
{
    public partial class DepartamentosPage : ContentPage
    {
        public DepartamentosPage()
        {
            InitializeComponent();
            BindingContext = new DepartamentosViewModel();
        }
    }
}