using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Data.Linq;
using ProdajaPrepisVozila.Model.Dto.Lica;

namespace ProdajaPrepisVozila.Model.Bridge.MySQL_LINQ.LicaStorage
{
    class LiceStorageMySqlLinq : IStorage<Lice>
    {
        string queryString = "SELECT * FROM mydb.lice";
        string connectionString = @"Server=127.0.0.1;Database=mydb;Uid=root;Pwd=step3110;";

        public void Delete(Lice t)
        {
            throw new NotImplementedException();
        }

        public Lice Get(long id)
        {
            throw new NotImplementedException();
        }

        public List<Lice> GetAll()
        {
            DataContext dataContext = new DataContext(connectionString);
            return null;
        }

        public void Save(Lice t)
        {
            throw new NotImplementedException();
        }

        public void Update(Lice t, params string[] @params)
        {
            throw new NotImplementedException();
        }
    }
}