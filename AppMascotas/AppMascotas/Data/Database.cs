using AppMascotas.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppMascotas.Data
{
    public class Database
    {
        //crea el crud
        public readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Mascota>(); //crea la tabla Mascota
            _database.CreateTableAsync<Usuario>();//crea la tabla Usuario

        }

        public Database()
        {
        }
        //Método para obtener mascotas
        public Task<List<Mascota>> GetMascotaAsync()
        {
            return _database.Table<Mascota>().ToListAsync();
        }
        //Método para guardar mascotas

        public Task<int> SaveMascotaAsync(Mascota mascota)
        {
            return _database.InsertAsync(mascota);

        }
        //Método para actualizar mascotas

        public Task<int> UpdateMascotaAsync(Mascota mascota)
        {
            return _database.UpdateAsync(mascota);
        }
        //Método para Eliminar mascotas

        public Task<int> DeleteMascotaAsync(Mascota mascota)
        {
            return _database.DeleteAsync(mascota);
        }
        //Método para seleccionar todas las  mascotas

        public Task<List<Mascota>> QueryMascotasAsync()
        {
            return _database.QueryAsync<Mascota>("SELECT * FROM Mascota");
        }



        //    //Métodos para crear el crud USUARIO
        //    //Método para obtener Usuario

        public Task<List<Usuario>> GetUsuarioAsync()
        {
            return _database.Table<Usuario>().ToListAsync();
        }

        //Método para guardar Usuario
        public Task<int> SaveUsuarioAsync(Usuario usuario)
        {
            return _database.InsertAsync(usuario);
        }
        //Método para actualizar Usuario
        public Task<int> UpdateUsuarioAsync(Usuario usuario)
        {
            return _database.UpdateAsync(usuario);
        }
        //Método para eliminar Usuario
        public Task<int> DeleteUsuarioAsync(Usuario usuario)
        {
            return _database.DeleteAsync(usuario);
        }
        //Método para Seleccionar  Usuario
        public Task<List<Usuario>> QueryUsuarioAsync()
        {
            return _database.QueryAsync<Usuario>("SELECT * FROM Usuario");
        }

        //Método para obtener  para validar contasenia y usuario
         public IEnumerable<Usuario> validarUsuario(string nombre, string contrasenia)
          {
              var result= _database.QueryAsync<Usuario>("Select * from Usuario Where nombre=? and contrasenia=?", nombre, contrasenia);
              return result.Result;
          }

       


    }

}
