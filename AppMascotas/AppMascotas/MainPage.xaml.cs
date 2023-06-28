using AppMascotas.Data;
using AppMascotas.Model;
using AppMascotas.vista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using static SQLite.SQLite3;

namespace AppMascotas
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            //llamar al boton
            this.botonCMascota.Clicked += irmascota;
            this.botonCUsuario.Clicked += irusuario;

        }
       
        public async void irmascota(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.Menu());
         }
        public async void irusuario(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new menuUser());


        }
    }
}