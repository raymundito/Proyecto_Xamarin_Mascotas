using AppMascotas.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppMascotas.Data
{
    public class UsuarioDB
    {
        /*  //crea el crud
          private readonly SQLiteAsyncConnection _database;

          public UsuarioDB(string dbPath)
          {
              _database = new SQLiteAsyncConnection(dbPath);

              _database.CreateTableAsync<Usuario>();//crea la tabla Usuario

          }

          public UsuarioDB()
          {
          }

          //Métodos para crear el crud USUARIO
          //Método para obtener Usuario

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
          public Task validarUsuario(string nombre, string contrasenia)
          {
              return _database.QueryAsync<Usuario>("Select * from Usuario where nombre=? and contrasenia=?", nombre, contrasenia);
          }
      }*/

  } 
    

}
