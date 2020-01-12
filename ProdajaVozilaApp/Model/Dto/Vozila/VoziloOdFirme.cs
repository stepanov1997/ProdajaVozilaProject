namespace ProdajaVozilaApp.Model.Dto.Vozila
{
    public class VoziloOdFirme
    {
        public int Id { get; }
        public Vozilo Vozilo { get; }
        public byte[] Slika { get; }
        public double Cijena { get; }
        public double Snizenje { get; }
        public string Opis { get; }

        public VoziloOdFirme(int id, Vozilo vozilo, byte[] slika, double cijena, double snizenje, string opis)
        {
            Id = id;
            Vozilo = vozilo;
            Slika = slika;
            Cijena = cijena;
            Snizenje = snizenje;
            Opis = opis;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Vozilo)}: {Vozilo}, {nameof(Slika)}: {Slika}, {nameof(Cijena)}: {Cijena}, {nameof(Snizenje)}: {Snizenje}, {nameof(Opis)}: {Opis}";
        }
    }
}
