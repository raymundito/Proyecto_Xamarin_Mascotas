using AppMascotas.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
           
            await Navigation.PushAsync(new View.Menu() );

        }
        

    }
}
