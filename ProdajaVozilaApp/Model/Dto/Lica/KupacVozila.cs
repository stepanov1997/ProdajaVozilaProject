namespace ProdajaVozilaApp.Model.Dto.Lica
{
    class KupacVozila : Lice
    {
        public int IdKupca { get; set; }
        public KupacVozila(int id, int idLica, string ime, string prezime, string brojLicneKarte, string jmbg, MjestoStanovanja mjestoStanovanja, TipLica tipLica) : base(idLica, ime, prezime, brojLicneKarte, jmbg, mjestoStanovanja, tipLica)
        {
            IdKupca = id;
        }
    }
}
