using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using RegistroPersonasT.MODELS;
using System.Threading.Tasks;

namespace RegistroPersonasT.CONTROLLERS
{
    public class Personas
    {
        //public SQLiteAsyncConnection connection;

        public class SqliteHelper
        {
            public SQLiteAsyncConnection dbpers;

            public  SqliteHelper(string dbpath)
            {
                dbpers = new SQLiteAsyncConnection(dbpath);
                dbpers.CreateTableAsync<PersonasModels>().Wait();
            }
            public Task<int> Saveperson(PersonasModels personas)
            {
                if (personas.id != 0)

                    return dbpers.UpdateAsync(personas);


                else
                    return dbpers.InsertAsync(personas) ;


            }

            public Task<int> deletepersonasAsync(PersonasModels personasModels)
            {
                return dbpers.DeleteAsync(personasModels);
            }

            public Task<List<PersonasModels>> GetPersonasAsync()
            {
                return dbpers.Table<PersonasModels>().ToListAsync();
            }
             public Task<PersonasModels> GetPersonaByIdAsync(int idperson)
            {
                return dbpers.Table<PersonasModels>().Where(a => a.id == idperson).FirstOrDefaultAsync();
            }

            
        }


        //public Personas(String dbpath)
        //{
        //    connection = new SQLiteAsyncConnection(dbpath);

        //    connection.CreateTableAsync<PersonasModels>().Wait();
        //}





        //public Task<List<PersonasModels>> GetPersonasModels()
        //{
        //    return connection.Table<PersonasModels>().ToListAsync();
        //}
        // public Task<PersonasModels> GetPersonas(int pid)
        //{
        //    return connection.Table<PersonasModels>().Where(i => i.id == pid).FirstOrDefaultAsync();
        //}

        //public Task<int> Eliminarperson(PersonasModels personas)
        //{
        //    return connection.DeleteAsync(personas);


        //}
    }
}
