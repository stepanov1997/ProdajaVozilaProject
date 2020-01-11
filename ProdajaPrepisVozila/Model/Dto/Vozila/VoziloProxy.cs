namespace ProdajaPrepisVozila.Model.Dto.Vozila
{
    public class VoziloProxy
    {
        public int Id { get; }
        public Vozilo Vozilo { get; }
        public byte[] Slika { get; }
        public double Cijena { get; }
        public double Snizenje { get; }
        public string Opis { get; }

        public VoziloProxy(int id, Vozilo vozilo, byte[] slika, double cijena, double snizenje, string opis)
        {
            Id = id;
            Vozilo = vozilo;
            Slika = slika;
            Cijena = cijena;
            Snizenje = snizenje;
            Opis = opis;
        }
    }
}
