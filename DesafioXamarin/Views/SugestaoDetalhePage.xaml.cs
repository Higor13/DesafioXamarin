using System;
using System.Collections.Generic;
using DesafioXamarin.ViewModels;
using Xamarin.Forms;

namespace DesafioXamarin.Views
{	
	public partial class SugestaoDetalhePage : ContentPage
	{	
		public SugestaoDetalhePage()
		{
			BindingContext = new SugestaoDetalheViewModel();

            InitializeComponent ();
		}
	}
}

