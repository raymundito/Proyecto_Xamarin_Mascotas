using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMascotas.vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class menuUser : ContentPage
	{
		public menuUser ()
		{
			InitializeComponent ();
              this.botonusuario.Clicked += listarUsuario;
              this.botoncrearusuario.Clicked += agregarUsuario;
        }
        public async void agregarUsuario(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AgregarUsuario());

        }
        public async void listarUsuario(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ListarUsuario());

        }
    }
}