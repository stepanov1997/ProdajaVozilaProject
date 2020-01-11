using ProdajaPrepisVozila.Model.Dto.Lica;

namespace ProdajaPrepisVozila.Model.Dto.Vozila
{
    public class Vozilo
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int GodinaProizvodnje { get; set; }
        public int RegistarskiBroj { get; set; }
        public string BrojSasije { get; set; }
        public string BrojMotora { get; set; }
        public VlasnikVozila VlasnikVozila { get; set; }

        public Vozilo(int id, string marka, string model, int godinaProizvodnje, int registarskiBroj, string brojSasije,
            string brojMotora, VlasnikVozila vlasnikVozila)
        {
            Id = id;
            Marka = marka;
            Model = model;
            GodinaProizvodnje = godinaProizvodnje;
            RegistarskiBroj = registarskiBroj;
            BrojSasije = brojSasije;
            BrojMotora = brojMotora;
            VlasnikVozila = vlasnikVozila;
        }
    }
}