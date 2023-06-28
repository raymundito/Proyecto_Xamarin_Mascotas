using AppMascotas.Data;
using AppMascotas.Model;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMascotas.vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarMascota : ContentPage
    {
        Mascota mascota = new Mascota(); /*creacion de instancia a Mascota*/
        Mascota lastpet;
        Database database = new Database();  /*instancia a la base de datos*/

        //  public CollectionView collectionView;

        public ListarMascota()
        {

            InitializeComponent();

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



        //Listar las mascotas al seleccionar un elemento
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

        //limpiar los campos 
        public void limpiar()
        {
            nombre.Text = string.Empty;
            peso.Text = string.Empty;
            habitat.Text = string.Empty;
            precio.Text = string.Empty;
           // sexo.Text = string.Empty;
            edad.Text = string.Empty;
            iva.Text = string.Empty;
            ruta.Text = string.Empty;
        }
        //Actualizar los elementos 
        private async void actualizar(object sender, EventArgs e)
        {
            //Condicional para mostrar aviso si se ha seleccionado un elemento
            if (this.mystack.IsVisible == false)
            {
                //permite enviar un mensaje de alerta
                await DisplayAlert("Aviso", "No ha seleccionado una mascota", "Ok");
            }
            else if (this.mystack.IsVisible == true)
            {
                if (lastpet != null)
                {
                    lastpet.nombre = nombre.Text;
                    lastpet.peso = double.Parse(peso.Text);
                    lastpet.habitat = habitat.Text;
                    lastpet.precio = double.Parse(precio.Text);
                    lastpet.sexo = sexo.Text;
                    lastpet.edad = Int32.Parse(edad.Text);
                    lastpet.iva = double.Parse(iva.Text);
                    lastpet.ruta = ruta.Text;


                    await App.Database.UpdateMascotaAsync(lastpet); //actualiza elemento
                    collectionView.ItemsSource = await App.Database.GetMascotaAsync();
                    limpiar(); //limpia los entry
                    this.mystack.IsVisible = false; 
                    await DisplayAlert("Aviso", "Actualizado correctamente", "Ok");
                }


            }
        }
        //obtiene los datos en el entry
        void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            this.mystack.IsVisible = true;

            lastpet = e.CurrentSelection[0] as Mascota;
            nombre.Text = lastpet.nombre;
            peso.Text = lastpet.peso.ToString();
            habitat.Text = lastpet.habitat;
            precio.Text = lastpet.precio.ToString();
            sexo.Text = lastpet.sexo;
            edad.Text = lastpet.edad.ToString();
            iva.Text = lastpet.iva.ToString();
            ruta.Text = lastpet.ruta;
        }
        //Eliminar mascotas
        private async void eliminar(object sender, EventArgs e)
        {
            if (this.mystack.IsVisible)
            {
                //mensaje si esta seguro de eliminar una mascota
                var ans = await DisplayAlert("Eliminando Mascota ", "¿Está seguro de eliminar a '" + this.nombre.Text + "' ?", "Si", "No");
                if (ans == true)
                {
                    if (lastpet != null)
                    {

                        AgregarMascota mascota = new AgregarMascota(); //instancia a Mascota
                        await App.Database.DeleteMascotaAsync(lastpet); // Elimina la mascota seleccionada
                        collectionView.ItemsSource = await App.Database.GetMascotaAsync(); // obtiene las mascotas actualizadas
                        nombre.Text = "";
                        peso.Text = "";
                        habitat.Text = "";
                        precio.Text = "";
                        sexo.Text = "";
                        edad.Text = "";
                        iva.Text = "";
                        ruta.Text = "";
                        this.mystack.IsVisible = false;

                    }
                }
            }
            else
            {
                await DisplayAlert("Aviso", "No ha seleccionado ninguna Mascota", "Ok");
            }


        }
    }

}