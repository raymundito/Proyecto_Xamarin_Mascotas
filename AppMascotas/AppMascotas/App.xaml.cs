using AppMascotas.Data;
using System;
using System.IO;
using Xamarin.Forms;

namespace AppMascotas
{
    public partial class App : Application
    {
        //se crea la base de datos
        private static Database database;
         //Conexion con la base de datos
        public static Database Database
        {
            get
            {
                if (database == null)
                {

                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mascotas.db3"));
                }

                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
