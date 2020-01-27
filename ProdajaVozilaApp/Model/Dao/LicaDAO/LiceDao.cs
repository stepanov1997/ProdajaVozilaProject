using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using ProdajaVozilaApp.Model.Dto.Lica;

namespace ProdajaVozilaApp.Model.Dao.LicaDAO
{
    class LiceDao : IDao<Lice>
    {
        private const string GetAllQuery =
            @"SELECT lice.id, ime, prezime, brojLicneKarte, jmbg, mjestostanovanja.id AS MjestoStanovanja_id, grad, opstina, ulica, broj, TipLica
              FROM lice
              JOIN mjestostanovanja ON mjestostanovanja.id = MjestoStanovanja_id";

        private const string GetQuery =
            @"SELECT lice.id, ime, prezime, brojLicneKarte, jmbg, mjestostanovanja.id as MjestoStanovanja_id, grad, opstina, ulica, broj, TipLica
              FROM lice
              INNER JOIN mjestostanovanja ON mjestostanovanja.id = MjestoStanovanja_id
              WHERE lice.id=@id";

        public void Delete(Lice t)
        {
            throw new NotImplementedException();
        }

        public Lice Get(int id)
        {

            return null;
            //using (MyMySQLConnection connection = new MyMySQLConnection())
            //{
            //    MySqlCommand command = new MySqlCommand(GetQuery, connection.Connection);
            //    connection.Connection.Open();
            //    MySqlDataReader reader = command.ExecuteReader();
            //    command.Parameters.Add("@id", DbType.Int32).Value = id;
            //    var readerData = command.ExecuteReader();
            //    try
            //    {
            //        while(readerData.Read())
            //            return new Lice(
            //                id,
            //                (string)reader["ime"],
            //                (string)reader["prezime"],
            //                (string)reader["brojLicneKarte"],
            //                (string)reader["jmbg"],
            //                new MjestoStanovanja(
            //                    reader.GetInt32(reader.GetOrdinal("MjestoStanovanja_id")),
            //                    (string)reader["grad"],
            //                    (string)reader["opstina"],
            //                    (string)reader["ulica"],
            //                    (string)reader["broj"]),
            //                (TipLica)Enum.Parse(typeof(TipLica), (string)reader["TipLica"]));
            //    }
            //    finally
            //    {
            //        reader.Close();
            //    }

            //    return null;
            //}
        }

        public List<Lice> GetAll()
        {
            List<Lice> lica = new List<Lice>();
            using (MyMySQLConnection connection = new MyMySQLConnection())
            {
                MySqlCommand command = new MySqlCommand(GetAllQuery, connection.Connection);
                connection.Connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        lica.Add(new Lice(
                            reader.GetInt32(reader.GetOrdinal("id")),
                            (string)reader["ime"],
                            (string)reader["prezime"],
                            (string)reader["brojLicneKarte"],
                            (string)reader["jmbg"],
                            new MjestoStanovanja(
                                reader.GetInt32(reader.GetOrdinal("MjestoStanovanja_id")),
                                (string)reader["grad"],
                                (string)reader["opstina"],
                                (string)reader["ulica"],
                                (string)reader["broj"]),
                            (TipLica)Enum.Parse(typeof(TipLica), (string)reader["TipLica"])));
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return lica;
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
