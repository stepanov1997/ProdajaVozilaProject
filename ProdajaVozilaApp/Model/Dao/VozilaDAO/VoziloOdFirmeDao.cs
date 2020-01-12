using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using ProdajaVozilaApp.Model.Dao.LicaDAO;
using ProdajaVozilaApp.Model.Dto.Vozila;

namespace ProdajaVozilaApp.Model.Dao.VozilaDAO
{
    class VoziloOdFirmeDao : IDao<VoziloOdFirme>
    {
        private const string GetAllQuery =
            @"SELECT * FROM voziloodfirme";

        private const string GetQuery =
            @"SELECT * FROM voziloodfirme
              WHERE voziloodfirme.id=@id;";

        public void Delete(VoziloOdFirme t)
        {
            throw new NotImplementedException();
        }

        public VoziloOdFirme Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<VoziloOdFirme> GetAll()
        {
            List<VoziloOdFirme> vozila = new List<VoziloOdFirme>();
            using (MyMySQLConnection connection = new MyMySQLConnection())
            {
                MySqlCommand command = new MySqlCommand(GetAllQuery, connection.Connection);
                connection.Connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        vozila.Add(new VoziloOdFirme(
                            reader.GetInt32(reader.GetOrdinal("id")),
                            new VoziloDao().Get(reader.GetInt32(reader.GetOrdinal("Vozilo_id"))), 
                            (byte[])reader["slika"],
                            (double)reader["cijena"],
                            (double)reader["snizenje"],
                            (string)reader["opis"]));
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return vozila;
        }

        public void Save(VoziloOdFirme t)
        {
            throw new NotImplementedException();
        }

        public void Update(VoziloOdFirme t, params string[] @params)
        {
            throw new NotImplementedException();
        }
    }
}
