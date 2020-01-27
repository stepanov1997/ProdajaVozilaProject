INSERT INTO vozilo(marka, model, godiste, registarskiBroj, brojSasije, brojMotora, VlasnikVozila_id) 
VALUES ("Fiat","Punto","2006","123-T-321","4242524242", "4322512521", 2);
INSERT INTO voziloodfirme(Vozilo_id, slika, cijena, snizenje, opis) 
VALUES (1, LOAD_FILE("C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/fiatpunto.jpg"), 5000, 0.2, "U dobrom stanju");

INSERT INTO vozilo(marka, model, godiste, registarskiBroj, brojSasije, brojMotora, VlasnikVozila_id) 
VALUES ("Golf","V","2011","222-K-343","1425125125", "141251251251", 1);
INSERT INTO voziloodfirme(Vozilo_id, slika, cijena, snizenje, opis) 
VALUES (LAST_INSERT_ID(), LOAD_FILE("C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/golf5.jpg"), 8500, 0.2, "U odlicnom stanju");

INSERT INTO vozilo(marka, model, godiste, registarskiBroj, brojSasije, brojMotora, VlasnikVozila_id) 
VALUES ("Alfa Romeo","156","2000","444-M-444","424151414", "1525125125", 1);
INSERT INTO voziloodfirme(Vozilo_id, slika, cijena, snizenje, opis) 
VALUES (LAST_INSERT_ID(), LOAD_FILE("C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/alfa.jpg"), 3200, 0.1, "U dobrom stanju");

INSERT INTO vozilo(marka, model, godiste, registarskiBroj, brojSasije, brojMotora, VlasnikVozila_id) 
VALUES ("Škoda","Fabia","2010","344-K-211","1242352356", "73734627", 1);
INSERT INTO voziloodfirme(Vozilo_id, slika, cijena, snizenje, opis) 
VALUES (LAST_INSERT_ID(), LOAD_FILE("C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/fabia.jpg"), 5000, 0.2, "U odlicnom stanju");