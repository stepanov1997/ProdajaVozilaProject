using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using MySql.Data.MySqlClient;
using ProdajaVozilaApp.Model.Dao.LicaDAO;
using ProdajaVozilaApp.Model.Dto.Lica;
using ProdajaVozilaApp.Model.Dto.Vozila;

namespace ProdajaVozilaApp.Model.Dao.VozilaDAO
{
    class VoziloOdFirmeDao : IDao<VoziloOdFirme>
    {
        private const string AddImages = @"INSERT INTO slikavozila(VoziloOdFirme_id, slika) VALUES (@id, @slika);";
        private const string GetImages = @"SELECT VoziloOdFirme_id, slika FROM slikavozila";

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
                MySqlCommand command = new MySqlCommand("get_all_vozila_za_prodaju", connection.Connection);
                command.CommandType = CommandType.StoredProcedure;
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
                            new Vozilo(
                                Convert.IsDBNull(reader["Vozilo_id"])
                                    ? default
                                    : reader.GetInt32(reader.GetOrdinal("Vozilo_id")),
                                Read<string>(reader, "marka"),
                                Read<string>(reader, "model"),
                                Read<int>(reader, "godiste"),
                                Read<string>(reader, "registarskiBroj"),
                                Read<string>(reader, "brojSasije"),
                                Read<string>(reader, "brojMotora"),
                                new VlasnikVozila(
                                    Convert.IsDBNull(reader["VlasnikVozila_id"])
                                        ? default
                                        : reader.GetInt32(reader.GetOrdinal("VlasnikVozila_id")),
                                    Convert.IsDBNull(reader["Lice_id"])
                                        ? default
                                        : reader.GetInt32(reader.GetOrdinal("Lice_id")),
                                    Read<string>(reader, "ime"),
                                    Read<string>(reader, "prezime"),
                                    Read<string>(reader, "brojLicneKarte"),
                                    Read<string>(reader, "jmbg"),
                                    new MjestoStanovanja(
                                        Convert.IsDBNull(reader["MjestoStanovanja_id"])
                                            ? default
                                            : reader.GetInt32(reader.GetOrdinal("MjestoStanovanja_id")),
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
            using (MyMySQLConnection connection = new MyMySQLConnection())
            {
                MySqlCommand cmd = new MySqlCommand("add_vozilo_za_prodaju", connection.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("markaIn", MySqlDbType.VarChar).Value = t.Vozilo.Marka;
                cmd.Parameters.Add("modelIn", MySqlDbType.VarChar).Value = t.Vozilo.Model;
                cmd.Parameters.Add("godisteIn", MySqlDbType.Year).Value = t.Vozilo.GodinaProizvodnje;
                cmd.Parameters.Add("tabliceIn", MySqlDbType.VarChar).Value = t.Vozilo.RegistarskiBroj;
                cmd.Parameters.Add("brojSasijeIn", MySqlDbType.VarChar).Value = t.Vozilo.BrojSasije;
                cmd.Parameters.Add("brojMotoraIn", MySqlDbType.VarChar).Value = t.Vozilo.BrojMotora;
                cmd.Parameters.Add("cijenaIn", MySqlDbType.Double).Value = t.Cijena;
                cmd.Parameters.Add("snizenjeIn", MySqlDbType.Double).Value = t.Snizenje;
                cmd.Parameters.Add("opisIn", MySqlDbType.VarChar).Value = t.Opis;

                try
                {
                    connection.Connection.Open();
                    cmd.ExecuteNonQuery();
                    int id = int.Parse(cmd.Parameters["id"].Value.ToString());
                    t.Id = id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Greška");
                }

                MySqlCommand commandImages = new MySqlCommand(AddImages, connection.Connection);
                commandImages.CommandType = CommandType.Text;
                commandImages.Prepare();
                if (t.Id.HasValue)
                {
                    foreach (var slikaBytes in t.Slike)
                    {
                        commandImages.Parameters.Clear();
                        commandImages.Parameters.Add("@id", MySqlDbType.Int32).Value = t.Id.Value;
                        commandImages.Parameters.Add("@slika", MySqlDbType.LongBlob).Value = slikaBytes;
                        commandImages.ExecuteNonQuery();
                    }
                }
                connection.Connection.Close();
            }
        }


        public void Update(VoziloOdFirme t, params string[] @params)
        {
            throw new NotImplementedException();
        }
    }
}
