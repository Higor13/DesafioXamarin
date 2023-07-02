using DesafioXamarin.Database;
using DesafioXamarin.Services;
using DesafioXamarin.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesafioXamarin
{
    public partial class App : Application
    {
        public static DatabaseContext Database { get; private set; }
        public static string DepartamentoFiltroSelecionado { get; set; }

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3");

            Database = new DatabaseContext(dbPath);

            DependencyService.Register<DatabaseService>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
