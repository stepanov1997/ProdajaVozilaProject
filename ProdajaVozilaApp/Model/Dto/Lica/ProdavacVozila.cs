namespace ProdajaVozilaApp.Model.Dto.Lica
{
   
    class ProdavacVozila : VlasnikVozila
    { 
        public int IdProdavca { get; set; }
        public ProdavacVozila(int idProdavca, int idVlasnika, int idLica, string ime, string prezime, string brojLicneKarte, string jmbg, MjestoStanovanja mjestoStanovanja, TipLica tipLica) : base(idVlasnika, idLica, ime, prezime, brojLicneKarte, jmbg, mjestoStanovanja, tipLica)
        {
            IdProdavca = idProdavca;
        }
    }
}
