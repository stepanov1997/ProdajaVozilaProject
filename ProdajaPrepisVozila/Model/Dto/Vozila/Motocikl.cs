using ProdajaPrepisVozila.Model.Dto.Lica;

namespace ProdajaPrepisVozila.Model.Dto.Vozila
{
    class Motocikl : Vozilo
    {
        public Motocikl(int id, string marka, string model, int godinaProizvodnje, int registarskiBroj, string brojSasije, string brojMotora, VlasnikVozila vlasnikVozila) : base(id, marka, model, godinaProizvodnje, registarskiBroj, brojSasije, brojMotora, vlasnikVozila)
        {
        }
    }
}
