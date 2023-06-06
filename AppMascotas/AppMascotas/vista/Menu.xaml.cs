using AppMascotas.vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}