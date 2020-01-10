namespace ProdajaPrepisVozila.Model.Dto.Lica
{
    class VlasnikVozila : Lice
    {
        public VlasnikVozila(int id, string ime, string prezime, string brojLicneKarte, string jmbg, MjestoStanovanja mjestoStanovanja, TipLica tipLica) : base(id, ime, prezime, brojLicneKarte, jmbg, mjestoStanovanja, tipLica)
        {
        }
    }
}
