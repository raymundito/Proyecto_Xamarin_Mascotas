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
	public partial class AgregarMascota : ContentPage
	{

       

        public AgregarMascota ()
		{
			InitializeComponent ();
            this.AgregarMcancelar.Clicked += Cancelar;
            this.AgregarMguardar.Clicked += Guardar;

        }
        public async void Cancelar(object sender, EventArgs e)
        {

            await Navigation.PopAsync();

        }
        public async void Guardar(object sender, EventArgs e)
        {
            await App.Database.SaveMascotaAsync(new Model.Mascota
            {
                nombre = usuario.Text,
                tamanio = Int32.Parse(tamanio.Text),
                peso = Int32.Parse(peso.Text),
                habitat = habitat.Text,
                precio = Int32.Parse(precio.Text),
                sexo = sexo.Text,
                edad = Int32.Parse(edad.Text),
                iva = Int32.Parse(iva.Text)

            }); ;
            Console.WriteLine("si lo guarde");

            //   nameEntry.Text = string.Empty;
            // subscribed.IsChecked = false;
             ListarMascota lista = new ListarMascota();
            
            lista.collectionView.ItemsSource = await App.Database.GetMascotaAsync();

            // await Navigation.PushAsync(new View.Menu());

        }
		 
	}
}