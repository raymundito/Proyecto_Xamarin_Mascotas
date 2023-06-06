using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;

namespace AppMascotas.vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListarMascota : ContentPage
       	{
        private SQLiteAsyncConnection conectar;
        private ObservableCollection <Registro> tablaRegistro;

        //  public CollectionView collectionView;

        public ListarMascota ()
		{
			InitializeComponent ();

            this.botonregresar.Clicked += regresar;
        }
        public async void regresar(object sender, EventArgs e)
        {

            await Navigation.PopAsync();

        }
    }

}