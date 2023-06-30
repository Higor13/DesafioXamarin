using DesafioXamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DesafioXamarin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}