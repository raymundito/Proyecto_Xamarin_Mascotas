
using SQLite;
namespace AppMascotas.Model
{
    public class Mascota
    {
        //creacion de la tabla mascotas
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombre { get; set; }
        public int tamanio { get; set; }
        public double peso { get; set; }
        public string habitat { get; set; }
        public double precio { get; set; }
        public string sexo { get; set; }
        public int edad { get; set; }
        public double iva { get; set; }
        public string ruta { get; set; }
    }
    //creacion de la tabla usuario
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int idusuario { get; set; }
        public string nombre { get; set; }
        public string contrasenia { get; set; }
        public string correo { get; set; }
        public string ine { get; set; }

        public string numcuenta { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string ruta { get; set; }

    }
}
