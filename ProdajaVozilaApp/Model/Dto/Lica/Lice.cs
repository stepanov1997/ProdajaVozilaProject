using ProdajaVozilaApp.Model.Dto.Alati;

namespace ProdajaVozilaApp.Model.Dto.Lica
{
    public class Lice : IObject
    {
        public int? Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojLicneKarte { get; set; }
        public string Jmbg { get; set; }
        public MjestoStanovanja MjestoStanovanja { get; set; }
        public TipLica TipLica { get; set; }

        public Lice(Lice lice) : this(lice.Id, lice.Ime, lice.Prezime, lice.BrojLicneKarte, lice.Jmbg, lice.MjestoStanovanja, lice.TipLica) {}

        public Lice(int? id, string ime, string prezime, string brojLicneKarte, string jmbg, MjestoStanovanja mjestoStanovanja, TipLica tipLica)
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

    public enum TipLica
    {
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedMember.Global
        PRAVNO,
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedMember.Global
        FIZICKO
    }
}