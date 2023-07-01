using DesafioXamarin.Models;
using DesafioXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesafioXamarin.Views
{
    public partial class AddSugestaoPage : ContentPage
    {
        public Sugestao Item { get; set; }

        public AddSugestaoPage()
        {
            InitializeComponent();
            BindingContext = new AddSugestaoViewModel();
        }
    }
}