using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProdajaPrepisVozila.Model.Bridge;
using ProdajaPrepisVozila.Model.Dto.Lica;

namespace ProdajaPrepisVozila.Model.Bridge.MySQL_NoLINQ.LicaStorage
{
    class LiceStorageMySqlNoLinq : IStorage<Lice>
    {
        private const string GetAllQuery =
            @"SELECT lice.id, ime, prezime, brojLicneKarte, jmbg, mjestostanovanja.id AS MjestoStanovanja_id, grad, opstina, ulica, broj, TipLica
              FROM lice
              JOIN mjestostanovanja ON mjestostanovanja.id = MjestoStanovanja_id";

        private const string GetQuery =
            @"SELECT lice.id, ime, prezime, brojLicneKarte, jmbg, mjestostanovanja.id, opstina, ulica, broj, TipLica
              FROM lice
              INNER JOIN mjestostanovanja ON mjestostanovanja.id = MjestoStanovanja_id
              WHERE lice.id=?";

        readonly string _connectionString = $@"Server=127.0.0.1;Database=prodajaprepisvozila;Uid=root;Pwd={Environment.GetEnvironmentVariable("MYSQL_PASS", EnvironmentVariableTarget.User)};";

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
            List<Lice> lica = new List<Lice>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                MySqlCommand command = new MySqlCommand(GetAllQuery, connection);
                connection.Open();
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