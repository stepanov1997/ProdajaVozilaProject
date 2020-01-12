using ProdajaVozilaApp.Model.Dto.Lica;

namespace ProdajaVozilaApp.Model.Dto.Vozila
{
    class Motocikl : Vozilo
    {
        public Motocikl(int id, string marka, string model, int godinaProizvodnje, string registarskiBroj, string brojSasije, string brojMotora, VlasnikVozila vlasnikVozila) : base(id, marka, model, godinaProizvodnje, registarskiBroj, brojSasije, brojMotora, vlasnikVozila)
        {
        }
    }
}
