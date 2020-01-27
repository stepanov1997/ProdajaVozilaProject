CREATE DEFINER=`root`@`localhost` PROCEDURE `add_vozilo_za_prodaju`(out id int, 
in markaIn varchar(20), in modelIn varchar(20), in godisteIn year(4),
in tabliceIn varchar(9), in brojSasijeIn varchar(45), in brojMotoraIn varchar(45),
in cijenaIn double, in snizenjeIn double, in opisIn varchar(45))
BEGIN
	DECLARE idVozila INT;
	INSERT INTO vozilo(marka, model, godiste, registarskiBroj, brojSasije, brojMotora, VlasnikVozila_id) 
	VALUES (markaIn, modelIn, godisteIn, tabliceIn, brojSasijeIn, brojMotoraIn, 2);
    set idVozila = last_insert_id();
    INSERT INTO voziloodfirme(Vozilo_id, cijena, snizenje, opis) 
	VALUES (idVozila, cijenaIn, snizenjeIn, opisIn);
	set id = last_insert_id();
END