using AppMascotas.Data;
using AppMascotas.Model;
using System;
using System.Security.Cryptography;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMascotas.vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarUsuario : ContentPage
    {
        Mascota mascota = new Mascota(); //instancia a mascota
        Usuario lastuser;
        Database database = new Database(); // instancia a la base de datos



        //  public CollectionView collectionView;

        public ListarUsuario()
        {

            InitializeComponent();

            this.botonregresar.Clicked += regresar;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.Database.GetUsuarioAsync();
        }
        //metodo de regresar
        public async void regresar(object sender, EventArgs e)
        {

            await Navigation.PopAsync();

        }



        //obtiene la lista a partir del dato seleccionado
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListarUsuario
                {
                    BindingContext = e.SelectedItem as Usuario
                });
            }
        }
        //limpiar 
        public void limpiar()
        {

            nombre.Text = string.Empty;
            contrasenia.Text = string.Empty;
            correo.Text = string.Empty;
            ine.Text = string.Empty;
            numcuenta.Text = string.Empty;
            telefono.Text = string.Empty;
            direccion.Text = string.Empty;
        }
        //actualizar usuarios
        private async void actualizar(object sender, EventArgs e)
        {
            if (lastuser != null)
            {
                lastuser.nombre = nombre.Text;
                lastuser.contrasenia = contrasenia.Text;
                lastuser.correo = correo.Text;
                lastuser.ine = ine.Text;
                lastuser.numcuenta = numcuenta.Text;
                lastuser.telefono = telefono.Text;
                lastuser.direccion = direccion.Text;

                await App.Database.UpdateUsuarioAsync(lastuser);
                collectionView.ItemsSource = await App.Database.GetUsuarioAsync();
                limpiar();
            }
        }
       //asigna los datos en cada entry dependiendo del elemento seleccionado
        void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            lastuser = e.CurrentSelection[0] as Usuario;
            nombre.Text = lastuser.nombre;
            contrasenia.Text = lastuser.contrasenia;
            correo.Text = lastuser.correo;
            ine.Text = lastuser.ine;
            numcuenta.Text = lastuser.numcuenta;
            telefono.Text = lastuser.telefono;
            direccion.Text = lastuser.direccion;

        }
        private async void eliminar(object sender, EventArgs e)
        {
            if (lastuser != null)
            {
                AgregarUsuario usuario = new AgregarUsuario();
                await App.Database.DeleteUsuarioAsync(lastuser);
                collectionView.ItemsSource = await App.Database.GetUsuarioAsync();
                nombre.Text = "";
                contrasenia.Text = "";
                correo.Text = "";
                ine.Text = "";
                numcuenta.Text = "";
                telefono.Text = "";
                direccion.Text = "";

            }
        }


    }

}