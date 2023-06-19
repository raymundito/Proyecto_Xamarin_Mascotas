using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace AppMascotas.vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarMascota : ContentPage
    {


        public AgregarMascota()
        {
            InitializeComponent();
            this.listarMascota.Clicked += ListarMascota;
            this.AgregarMguardar.Clicked += Guardar;
            this.regresarmenu.Clicked += Regresarmenu;


        }
        public async void ListarMascota(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ListarMascota());

        }
        //limpiar los entrys
        public void limpiar()
        {
            usuario.Text = string.Empty;
            tamanio.Text = string.Empty;
            peso.Text = string.Empty;
            habitat.Text = string.Empty;
            precio.Text = string.Empty;
            //sexo.Text = string.Empty;
            edad.Text = string.Empty;
            iva.Text = string.Empty;
            ruta.Text = string.Empty;
        }
        public async void Regresarmenu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.Menu());
        }       
        //guarda un registro
        public async void Guardar(object sender, EventArgs e)

        {
            
             //Comparación si los hay campos vacios
            if (usuario.Text == "" & tamanio.Text == "" & peso.Text == "" & habitat.Text == "" & precio.Text == ""  & edad.Text == "" & iva.Text == "" & ruta.Text == "")
            {
                await DisplayAlert("Aviso", "Existen campos sin rellenar", "Ok");
            }
            else
            {
                //Guardar las mascotas a la base de datos
                await App.Database.SaveMascotaAsync(new Model.Mascota
                {

                    nombre = usuario.Text,
                    tamanio = Int32.Parse(tamanio.Text),
                    peso = Int32.Parse(peso.Text),
                    habitat = habitat.Text,
                    precio = Int32.Parse(precio.Text),                    
                    sexo= sexo.Text,

                    // sexo = sexo.Text,
                    edad = Int32.Parse(edad.Text),
                    iva = Int32.Parse(iva.Text),
                    ruta = ruta.Text

                }); ;

                limpiar(); //limpiar los entrys
                await Navigation.PushAsync(new ListarMascota());  //navegacion entre vistas

            }



        }


    }
}