using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using ProdajaVozilaApp.Model.Dao.LicaDAO;
using ProdajaVozilaApp.Model.Dto.Lica;
using ProdajaVozilaApp.Model.Dto.Vozila;

namespace ProdajaVozilaApp.Model.Dao.VozilaDAO
{
    class VoziloDao : IDao<Vozilo>
    {
        private const string GetAllQuery =
            @"SELECT * FROM vozilo;";

        private const string GetQuery =
            @"SELECT * FROM vozilo
              WHERE vozilo.id=@id;";

        public void Delete(Vozilo t)
        {

        }

        public Vozilo Get(int id)
        {
            using (MyMySQLConnection connection = new MyMySQLConnection())
            {
                MySqlCommand command = new MySqlCommand(GetQuery, connection.Connection);
                command.Parameters.Add("@id", DbType.Int32).Value = id;
                connection.Connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        return new Vozilo(id,
                                                (string)reader["marka"],
                                                (string)reader["model"],
                                                (int)reader["godiste"],
                                                (string)reader["registarskiBroj"],
                                                (string)reader["brojSasije"],
                                                (string)reader["brojMotora"],
                                                new VlasnikVozilaDao().Get(reader.GetInt32(reader.GetOrdinal("VlasnikVozila_id"))));
                    }

                    return null;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public List<Vozilo> GetAll()
        {
            List<Vozilo> vozila = new List<Vozilo>();
            using (MyMySQLConnection connection = new MyMySQLConnection())
            {
                MySqlCommand command = new MySqlCommand(GetAllQuery, connection.Connection);
                connection.Connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        vozila.Add(new Vozilo(
                            reader.GetInt32(reader.GetOrdinal("id")),
                            (string)reader["marka"],
                            (string)reader["model"],
                            int.Parse((string)reader["godiste"]),
                            (string)reader["registarskiBroj"],
                            (string)reader["brojSasije"],
                            (string)reader["brojMotora"],
                            new VlasnikVozilaDao().Get(reader.GetInt32(reader.GetOrdinal("VlasnikVozila_id")))));
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return vozila;
        }

        public void Save(Vozilo t)
        {
            throw new NotImplementedException();
        }

        public void Update(Vozilo t, params string[] @params)
        {
            throw new NotImplementedException();
        }
    }
}
