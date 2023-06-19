using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMascotas.vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarUsuario : ContentPage
    {
        public AgregarUsuario()
        {
            InitializeComponent();
            this.listarUsuario.Clicked += ListarUsuario;
            this.AgregarMguardar.Clicked += GuardarUsuario;
            this.regresarmenu.Clicked += Regresarmenu;

        }
        public async void ListarUsuario(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ListarMascota());

        }
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
        public async void Regresarmenu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.Menu());
        }
        public async void GuardarUsuario(object sender, EventArgs e)
        {
            await App.Database.SaveUsuarioAsync(new Model.Usuario
            {
                nombre = nombre.Text,
                contrasenia = contrasenia.Text,
                correo = correo.Text,
                ine = ine.Text,
                numcuenta = numcuenta.Text,
                telefono = telefono.Text,
                direccion = direccion.Text,


            }); ;
            Console.WriteLine("si lo guarde");

            limpiar();
            await Navigation.PushAsync(new ListarUsuario());

        }


    }
}