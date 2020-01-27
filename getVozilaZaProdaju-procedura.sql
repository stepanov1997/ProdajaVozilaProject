CREATE DEFINER=`root`@`localhost` PROCEDURE `get_all_vozila_za_prodaju`()
BEGIN
   SELECT voziloodfirme.id as id, Vozilo_id, cijena, snizenje, opis, marka, model, godiste, registarskiBroj, brojSasije, brojMotora, VlasnikVozila_id, Lice_id, ime, prezime, brojLicneKarte, jmbg, TipLica, MjestoStanovanja_id, grad, opstina, ulica, broj FROM prodajaprepisvozila.voziloodfirme
   LEFT JOIN vozilo on vozilo.id = Vozilo_id 
   LEFT JOIN vlasnikvozila on vlasnikvozila.id = VlasnikVozila_id
   LEFT JOIN lice on lice.id = Lice_id
   LEFT JOIN mjestostanovanja on mjestostanovanja.id = MjestoStanovanja_id;
END