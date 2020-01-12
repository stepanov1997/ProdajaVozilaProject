namespace ProdajaVozilaApp.Model.Dto.Lica
{
    public class VlasnikVozila : Lice
    {
        public int? IdVlasnika { get; set; }

        public VlasnikVozila(int idVlasnika, Lice lice) : base(lice)
        {
            IdVlasnika = idVlasnika;
        }

        public VlasnikVozila(int? idVlasnika, int? idLica, string ime, string prezime, string brojLicneKarte, string jmbg, MjestoStanovanja mjestoStanovanja, TipLica tipLica) : base(idLica, ime, prezime, brojLicneKarte, jmbg, mjestoStanovanja, tipLica)
        {
            IdVlasnika = idVlasnika;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(IdVlasnika)}: {IdVlasnika}";
        }
    }
}
