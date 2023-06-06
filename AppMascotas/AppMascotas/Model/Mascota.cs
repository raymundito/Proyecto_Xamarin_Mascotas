using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace AppMascotas.Model
{
   public class Mascota
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombre{ get; set; }
        public int tamanio { get; set;}
        public double peso { get; set; }
        public string habitat { get; set; }
        public double precio { get; set; }
        public string sexo { get; set; }
        public int edad { get; set; }
        public double iva { get; set; }
    }
}
