using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using ProdajaVozilaApp.Model.Dao.LicaDAO;
using ProdajaVozilaApp.Model.Dto.Lica;
using ProdajaVozilaApp.Model.Dto.Vozila;

namespace ProdajaVozilaApp.Model.Dao.VozilaDAO
{
    class VoziloOdFirmeDao : IDao<VoziloOdFirme>
    {
        private const string GetImages = @"SELECT VoziloOdFirme_id, slika FROM slikavozila";

        private const string GetAllQuery =
            @"SELECT voziloodfirme.id, Vozilo_id, cijena, snizenje, opis, marka, model, godiste, registarskiBroj, brojSasije, brojMotora, VlasnikVozila_id, Lice_id, ime, prezime, brojLicneKarte, jmbg, TipLica, MjestoStanovanja_id, grad, opstina, ulica, broj FROM prodajaprepisvozila.voziloodfirme
              LEFT JOIN vozilo on vozilo.id = Vozilo_id 
              LEFT JOIN vlasnikvozila on vlasnikvozila.id = VlasnikVozila_id
              LEFT JOIN lice on lice.id = Lice_id
              LEFT JOIN mjestostanovanja on mjestostanovanja.id = MjestoStanovanja_id";

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
                        /*
                         * voziloodfirme.id, Vozilo_id, cijena, snizenje, opis, slika, marka, model, godiste, registarskiBroj, brojSasije, brojMotora, VlasnikVozila_id, Lice_id, ime, prezime, brojLicneKarte, jmbg, TipLica, MjestoStanovanja_id, grad, opstina, ulica, broj
                         */
                        vozila.Add(new VoziloOdFirme(
                            Convert.IsDBNull(reader["id"]) ? default : reader.GetInt32(reader.GetOrdinal("id")),
                            new Vozilo(Convert.IsDBNull(reader["Vozilo_id"]) ? default : reader.GetInt32(reader.GetOrdinal("Vozilo_id")),
                                Read<string>(reader, "marka"),
                                Read<string>(reader, "model"),
                                Read<int>(reader, "godiste"),
                                Read<string>(reader, "registarskiBroj"),
                                Read<string>(reader, "brojSasije"),
                                Read<string>(reader, "brojMotora"),
                                new VlasnikVozila(
                                    Convert.IsDBNull(reader["VlasnikVozila_id"]) ? default : reader.GetInt32(reader.GetOrdinal("VlasnikVozila_id")),
                                    Convert.IsDBNull(reader["Lice_id"]) ? default : reader.GetInt32(reader.GetOrdinal("Lice_id")),
                                    Read<string>(reader, "ime"),
                                    Read<string>(reader, "prezime"),
                                    Read<string>(reader, "brojLicneKarte"),
                                    Read<string>(reader, "jmbg"),
                                    new MjestoStanovanja(
                                        Convert.IsDBNull(reader["MjestoStanovanja_id"]) ? default : reader.GetInt32(reader.GetOrdinal("MjestoStanovanja_id")),
                                        Read<string>(reader, "grad"),
                                        Read<string>(reader, "opstina"),
                                        Read<string>(reader, "ulica"),
                                        Read<string>(reader, "broj")),
                                    (TipLica) Enum.Parse(typeof(TipLica),
                                        Read<string>(reader, "TipLica")))),
                            new List<byte[]>(),
                            Read<double>(reader, "cijena"),
                            Read<double>(reader, "snizenje"),
                            Read<string>(reader, "opis")));
                    }
                }
                finally
                {
                    reader.Close();
                }

                MySqlCommand commandImages = new MySqlCommand(GetImages, connection.Connection);
                MySqlDataReader readerImages = commandImages.ExecuteReader();
                try
                {
                    while (readerImages.Read())
                    {
                        int id = readerImages.GetInt32(readerImages.GetOrdinal("VoziloOdFirme_id"));
                        byte[] slika = (byte[]) readerImages["slika"];
                        vozila.First(e => e.Id == id).Slike.Add(slika);
                    }
                }
                finally
                {
                    readerImages.Close();
                }
                return vozila;
            }
        }

        public static T Read<T>(MySqlDataReader reader, string input)
        {
            return Convert.IsDBNull(reader[input]) ? default : (T) reader[input];
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
