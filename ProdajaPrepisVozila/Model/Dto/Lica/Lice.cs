namespace ProdajaPrepisVozila.Model.Dto.Lica
{
    class Lice
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojLicneKarte { get; set; }
        public string Jmbg { get; set; }
        public MjestoStanovanja MjestoStanovanja { get; set; }
        public TipLica TipLica { get; set; }

        public Lice(int id, string ime, string prezime, string brojLicneKarte, string jmbg, MjestoStanovanja mjestoStanovanja, TipLica tipLica)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            BrojLicneKarte = brojLicneKarte;
            Jmbg = jmbg;
            MjestoStanovanja = mjestoStanovanja;
            TipLica = tipLica;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Ime)}: {Ime}, {nameof(Prezime)}: {Prezime}, {nameof(BrojLicneKarte)}: {BrojLicneKarte}, {nameof(Jmbg)}: {Jmbg}, {nameof(MjestoStanovanja)}: {MjestoStanovanja}, {nameof(TipLica)}: {TipLica}";
        }
    }

    internal enum TipLica
    {
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedMember.Global
        PRAVNO,
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedMember.Global
        FIZICKO
    }
}