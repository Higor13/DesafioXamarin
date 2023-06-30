using DesafioXamarin.ViewModels;
using DesafioXamarin.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DesafioXamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DepartamentosPage), typeof(DepartamentosPage));
            Routing.RegisterRoute(nameof(AddDepartamentoPage), typeof(AddDepartamentoPage));
            Routing.RegisterRoute(nameof(AddSugestaoPage), typeof(AddSugestaoPage));
        }
    }
}
