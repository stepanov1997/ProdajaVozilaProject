CREATE DEFINER = CURRENT_USER TRIGGER `ProdajaPrepisVozila`.`Stavka_BEFORE_INSERT` BEFORE INSERT ON `Stavka` FOR EACH ROW
BEGIN
select cijena from ProdajaPrepisVozila.KupoprodajniUgovor as tabela
where id = NEW.KupoprodajniUgovor_id;
SET NEW.cijena = tabela.cijena;
END
