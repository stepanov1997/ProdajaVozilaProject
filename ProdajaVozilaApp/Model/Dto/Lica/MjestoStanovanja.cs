namespace ProdajaVozilaApp.Model.Dto.Lica
{
    public class MjestoStanovanja
    {
        public int Id { get; set; }
        public string Grad { get; set; }
        public string Opstina { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }

        public MjestoStanovanja(int id, string grad, string opstina, string ulica, string broj)
        {
            Id = id;
            Grad = grad;
            Opstina = opstina;
            Ulica = ulica;
            Broj = broj;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Grad)}: {Grad}, {nameof(Opstina)}: {Opstina}, {nameof(Ulica)}: {Ulica}, {nameof(Broj)}: {Broj}";
        }
    }
}