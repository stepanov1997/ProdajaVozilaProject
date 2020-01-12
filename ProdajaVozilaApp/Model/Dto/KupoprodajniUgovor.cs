using System;
using ProdajaVozilaApp.Model.Dto.Alati;
using ProdajaVozilaApp.Model.Dto.Lica;
using ProdajaVozilaApp.Model.Dto.Vozila;

namespace ProdajaVozilaApp.Model.Dto
{
    class KupoprodajniUgovor : IObject
    {
        public KupacVozila KupacVozila { get; set; }
        public ProdavacVozila ProdavacVozila { get; set; }
        public Vozilo Vozilo { get; set; }
        public DateTime Datum { get; set; }
        public double CijenaVozila { get; set; }
        public double CijenaUgovora { get; set; }

        public KupoprodajniUgovor(KupacVozila kupacVozila, ProdavacVozila prodavacVozila, Vozilo vozilo, DateTime datum, double cijenaVozila, double cijenaUgovora)
        {
            KupacVozila = kupacVozila;
            ProdavacVozila = prodavacVozila;
            Vozilo = vozilo;
            Datum = datum;
            CijenaVozila = cijenaVozila;
            CijenaUgovora = cijenaUgovora;
        }
    }
}
