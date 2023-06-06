using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;
using AppMascotas.Model;
using SQLitePCL;
using AppMascotas.Data;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;

namespace AppMascotas.vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListarMascota : ContentPage
       	{
        Mascota mascota = new Mascota();

        Database database = new Database();

        //  public CollectionView collectionView;

        public ListarMascota ()
		{

			InitializeComponent ();
                       
            this.botonregresar.Clicked += regresar;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.Database.GetMascotaAsync();
        }
        public async void regresar(object sender, EventArgs e)
        {

            await Navigation.PopAsync();

        }



        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListarMascota
                {
                    BindingContext = e.SelectedItem as Mascota
                });
            }
        }
        private async void actualizar(object sender, EventArgs e)
        {
                   mascota = (Mascota)BindingContext;
                    await database.UpdateMascotaAsync(mascota);
                    await DisplayAlert("Aviso", "Registro actualizado exitosamente.", "Aceptar");
                    await Navigation.PushAsync(new ListarMascota());
          }
        private async void eliminar(object sender, EventArgs e)
        {

            var result = await DisplayAlert("Confirmar", "Estas seguro de eliminar el registro", "Aceptar", "Cancelar");
            if (result)//True si se preciona Aceptar, y se elimina el registro.
            {
                mascota = (Mascota)BindingContext;
                await database.DeleteMascotaAsync(mascota);
                await Navigation.PushAsync(new ListarMascota());
            }
            else
            {//False si se preciona Cancelar, y se cancela la elimación del registro.
                return;
            }
        }








  //      Mascota lastSelection;
        // Delete









        //async void actualizar(System.Object sender, System.EventArgs e)
        //{
        //    if (lastSelection != null)
        //    {
        //        //lastSelection.nombre = nombre.Text;
        //        //lastSelection.peso = tamanio.Text;
        //        //lastSelection.habitat = peso.Text;
        //        //lastSelection.precio = habitat.Text;
        //        //lastSelection.sexo = precio.Text;
        //        //lastSelection.edad = sexo.Text;
        //        //lastSelection.iva = edad.Text;
        //        //await App.Database.UpdateMascotaAsync(lastSelection);

        //        //collectionView.ItemsSource = await App.Database.GetMascotaAsync();
        //    }
        //}

      //actualiza
        //async void eliminar(System.Object sender, System.EventArgs e)
        //{
        //    if (lastSelection != null)
        //    {
        //        await App.Database.DeleteMascotaAsync(lastSelection);

        //        //collectionView.ItemsSource = await App.Database.GetMascotaAsync();

        //        //usuario.Text = "";
        //        //tamanio.Text = "";
        //        //peso.Text = "";
        //        //habitat.Text = "";
        //        //precio.Text = "";
        //        //sexo.Text = "";
        //        //edad.Text = "";
              

        //    }

        //}
    }

}