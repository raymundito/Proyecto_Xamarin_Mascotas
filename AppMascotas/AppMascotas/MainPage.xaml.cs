using System;
using Xamarin.Forms;

namespace AppMascotas
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            //llamar al boton
            this.irprincipal.Clicked += siguiente;

        }

        public async void siguiente(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new View.Menu());

        }


    }
}
