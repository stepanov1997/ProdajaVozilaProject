INSERT INTO mjestostanovanja(grad,opstina,ulica,broj) 
VALUES ("Prijedor","Prijedor","Kozarska","178");
INSERT INTO lice(ime, prezime, brojLicneKarte, jmbg, MjestoStanovanja_id, TipLica) 
VALUES ("Kristijan", "Stepanov", "23145234141", "424242343", LAST_INSERT_ID(), "Fizicko");

INSERT INTO mjestostanovanja(grad,opstina,ulica,broj) 
VALUES ("Banja Luka","Banja Luka","Carice Milice","2");
INSERT INTO lice(ime, prezime, brojLicneKarte, jmbg, MjestoStanovanja_id, TipLica) 
VALUES ("Ratko", "Milijević", "2431313", "42125125343", LAST_INSERT_ID(), "Fizicko");

INSERT INTO mjestostanovanja(grad,opstina,ulica,broj) 
VALUES ("Trebinje","Trebinje","Save Kovačevića","14");
INSERT INTO lice(ime, prezime, brojLicneKarte, jmbg, MjestoStanovanja_id, TipLica) 
VALUES ("Risto", "Marić", "312312421412", "131242211", LAST_INSERT_ID(), "Fizicko");

INSERT INTO mjestostanovanja(grad,opstina,ulica,broj) 
VALUES ("Novi Grad","Dubovik","Ranka Žeravice","11");
INSERT INTO lice(ime, prezime, brojLicneKarte, jmbg, MjestoStanovanja_id, TipLica) 
VALUES ("Miloš", "Ajduković", "31314124124", "14223412412", LAST_INSERT_ID(), "Fizicko");

INSERT INTO mjestostanovanja(grad,opstina,ulica,broj) 
VALUES ("Grahovo","Grahovo","Pečenci","bb");
INSERT INTO lice(ime, prezime, brojLicneKarte, jmbg, MjestoStanovanja_id, TipLica) 
VALUES ("Lenka", "Rašula", "3131412412", "4235236", LAST_INSERT_ID(), "Fizicko");

INSERT INTO mjestostanovanja(grad,opstina,ulica,broj) 
VALUES ("Prijedor","Prijedor","Miloša Obilića","bb");
INSERT INTO lice(ime, prezime, brojLicneKarte, jmbg, MjestoStanovanja_id, TipLica) 
VALUES ("Auto", "Rača", "44242343", "1314141414124", LAST_INSERT_ID(), "Pravno");

INSERT INTO vlasnikvozila(Lice_id) 
VALUES (LAST_INSERT_ID());