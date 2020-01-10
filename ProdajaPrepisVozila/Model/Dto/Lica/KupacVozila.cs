namespace ProdajaPrepisVozila.Model.Dto.Lica
{
    class KupacVozila : Lice
    {
        public KupacVozila(int id, string ime, string prezime, string brojLicneKarte, string jmbg, MjestoStanovanja mjestoStanovanja, TipLica tipLica) : base(id, ime, prezime, brojLicneKarte, jmbg, mjestoStanovanja, tipLica)
        {
        }
    }
}
