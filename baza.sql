#insert into wizyta (idpacjenta,idpielegniarki,datawizyty,idbadania) values (1, 1,'2022-05-18 10:00',1),(2, 1,'2022-05-18 10:15',1),(3, 1,'2022-05-18 10:30',1),(4, 1,'2022-05-18 10:45',1),(5, 1,'2022-05-18 11:00',1);
#update wizyta set datawizyty='2022-05-31 10:30' where idpacjenta=1 and idpielegniarki=2;
#select * from wizyta;
#select * from personelrecepcji;
#insert into recepcja (idwizyty,idrecepcjonistki) values (11,2),(12,2),(13,2),(14,2),(15,2),(16,2),(17,2);
#select * from recepcja;
#insert into wykonaniabadania (idwizyty,idanalityka,idbadania,data,wyniki,cenaaktualna) values (1,1,1,);
#select * from wykonaniabadania;