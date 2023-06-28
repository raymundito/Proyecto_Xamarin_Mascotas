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

            await Navigation.PushAsync(new ListarUsuario());

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
            ruta.Text = string.Empty;

        }
        public async void Regresarmenu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.Menu());
        }
        public async void GuardarUsuario(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.nombre.Text) ||
                string.IsNullOrWhiteSpace(this.contrasenia.Text) || 
                string.IsNullOrWhiteSpace(this.correo.Text) ||
                string.IsNullOrWhiteSpace(this.ine.Text) ||
                string.IsNullOrWhiteSpace(this.numcuenta.Text) ||
                string.IsNullOrWhiteSpace(this.telefono.Text) ||
                string.IsNullOrWhiteSpace(this.direccion.Text) ||
                string.IsNullOrWhiteSpace(this.ruta.Text))
            {
                await DisplayAlert("Aviso", "Existen campos sin rellenar", "Ok");
            }
            else { 
            await App.Database.SaveUsuarioAsync(new Model.Usuario
            {
                nombre = nombre.Text,
                contrasenia = contrasenia.Text,
                correo = correo.Text,
                ine = ine.Text,
                numcuenta = numcuenta.Text,
                telefono = telefono.Text,
                direccion = direccion.Text,
                ruta = ruta.Text

            }); ;       



            limpiar();
            await Navigation.PushAsync(new ListarUsuario());
                await DisplayAlert("Aviso", "Se ha guardado con éxito", "Ok");
            }

        }


    }
}