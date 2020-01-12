using ProdajaVozilaApp.Model.Dto.Lica;

namespace ProdajaVozilaApp.Model.Dto.Vozila
{
    class Automobil : Vozilo
    {
        public int IdAutomobila { get; set; }
        public Automobil(int idAutomobila, int idVozila, string marka, string model, int godinaProizvodnje, string registarskiBroj, string brojSasije, string brojMotora, VlasnikVozila vlasnikVozila) : base(idVozila, marka, model, godinaProizvodnje, registarskiBroj, brojSasije, brojMotora, vlasnikVozila)
        {
            IdAutomobila = idAutomobila;
        }
    }
}
