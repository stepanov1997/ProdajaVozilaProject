﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdajaVozilaApp.Model.Dto.Lica;
using ProdajaVozilaApp.Model.Dto.Vozila;

namespace ProdajaVozilaApp.Model
{
    class KupoprodajniUgovor
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
