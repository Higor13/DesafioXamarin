using System;
using System.Collections.Generic;
using DesafioXamarin.ViewModels;
using Xamarin.Forms;

namespace DesafioXamarin.Views
{	
	public partial class EditarDepartamentoPage : ContentPage
	{	
		public EditarDepartamentoPage ()
		{
			BindingContext = new EditarDepartamentoViewModel();

            InitializeComponent ();
		}
	}
}

