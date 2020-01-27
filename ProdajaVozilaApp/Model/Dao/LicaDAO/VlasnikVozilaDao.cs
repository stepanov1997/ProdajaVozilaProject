using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using ProdajaVozilaApp.Model.Dto.Lica;

namespace ProdajaVozilaApp.Model.Dao.LicaDAO
{
    class VlasnikVozilaDao : IDao<VlasnikVozila>
    {
        private const string GetAllQuery =
            @"SELECT lice.id, ime, prezime, brojLicneKarte, jmbg, mjestostanovanja.id AS MjestoStanovanja_id, grad, opstina, ulica, broj, TipLica
              FROM lice
              JOIN mjestostanovanja ON mjestostanovanja.id = MjestoStanovanja_id;";

        private const string GetQuery =
            @"SELECT * FROM prodajaprepisvozila.vlasnikvozila
              WHERE vlasnikvozila.id=@id;";

        public void Delete(VlasnikVozila t)
        {
            throw new NotImplementedException();
        }

        public VlasnikVozila Get(int id)
        {
            using (MyMySQLConnection connection = new MyMySQLConnection())
            {
                MySqlCommand command = new MySqlCommand(GetQuery, connection.Connection);
                connection.Connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                try
                {
                    return null;
                    command.ExecuteReader().Read();
                    Lice lice = new LiceDao().Get(reader.GetInt32(reader.GetOrdinal("Lice_id")));
                    if (lice == null) return null;
                    return new VlasnikVozila(id, lice);
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public List<VlasnikVozila> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(VlasnikVozila t)
        {
            throw new NotImplementedException();
        }

        public void Update(VlasnikVozila t, params string[] @params)
        {
            throw new NotImplementedException();
        }
    }
}
