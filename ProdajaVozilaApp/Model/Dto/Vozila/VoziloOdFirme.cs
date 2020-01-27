using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace ProdajaVozilaApp.Model.Dto.Vozila
{
    public class VoziloOdFirme
    {
        public int? Id { get; set; }
        public Vozilo Vozilo { get; }
        public List<byte[]> Slike { get; set; }
        public double Cijena { get; }
        public double Snizenje { get; }
        public string Opis { get; }

        public VoziloOdFirme(int? id, Vozilo vozilo, List<byte[]> slike, double cijena, double snizenje, string opis)
        {
            Id = id;
            Vozilo = vozilo;
            Slike = slike;
            Cijena = cijena;
            Snizenje = snizenje;
            Opis = opis;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Vozilo)}: {Vozilo}, {nameof(Slike)}: {Slike}, {nameof(Cijena)}: {Cijena}, {nameof(Snizenje)}: {Snizenje}, {nameof(Opis)}: {Opis}";
        }

        public Dictionary<string,string> NapraviRječnikOsobina()
        {
            return new Dictionary<string, string>
            {
                {"Model", Vozilo.Model},
                {"Marka", Vozilo.Marka},
                {"Registarski broj", Vozilo.RegistarskiBroj},
                {"Godina proizvodnje", Vozilo.GodinaProizvodnje.ToString()},
                {"Cijena bez popusta", $"{Cijena} KM"},
                {"Popust", $"{Snizenje * 100} %"},
                {"Ukupna cijena", $"{Cijena * (1 - Snizenje)} KM"}
            };
        }
    }
}
