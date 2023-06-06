using AppMascotas.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace AppMascotas.Data
{
   public class Database
    {
        //crea el crud
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Mascota>();
        }

        public Task<List<Mascota>> GetMascotaAsync()
        {
            return _database.Table<Mascota>().ToListAsync();
        }

        public Task<int> SaveMascotaAsync(Mascota mascota)
        {
            return _database.InsertAsync(mascota);
        }

        public Task<int> UpdateMascotaAsync(Mascota mascota)
        {
            return _database.UpdateAsync(mascota);
        }

        public Task<int> DeleteMascotaAsync(Mascota mascota)
        {
            return _database.DeleteAsync(mascota);
        }

        public Task<List<Mascota>> QueryMascotasAsync()
        {
            return _database.QueryAsync<Mascota>("SELECT * FROM Mascota");
        }

       
    }

}
