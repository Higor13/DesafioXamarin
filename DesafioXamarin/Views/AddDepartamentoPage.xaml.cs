using DesafioXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesafioXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDepartamentoPage : ContentPage
    {
        public AddDepartamentoPage()
        {
            InitializeComponent();
            this.BindingContext = new AddDepartamentoViewModel();
        }
    }
}