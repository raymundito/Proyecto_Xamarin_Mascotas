using AppMascotas.vista;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMascotas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
            this.botonlistar.Clicked += listar;
            this.botoncrear.Clicked += agregar;
        }
        public async void listar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListarMascota());
        }

       
        public async void agregar(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AgregarMascota());

        }
        /*
        public async void agregarUsuario(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AgregarUsuario());

        }
        public async void listarUsuario(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ListarUsuario());

        }*/
    }
}