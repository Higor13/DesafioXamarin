using DesafioXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DesafioXamarin.ViewModels
{
    public class AddDepartamentoViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public AddDepartamentoViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Curent.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
