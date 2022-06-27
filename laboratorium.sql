-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: nowy
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `administracja`
--

DROP TABLE IF EXISTS `administracja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `administracja` (
  `idadmina` int unsigned NOT NULL AUTO_INCREMENT,
  `idosoby` int NOT NULL,
  PRIMARY KEY (`idadmina`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administracja`
--

LOCK TABLES `administracja` WRITE;
/*!40000 ALTER TABLE `administracja` DISABLE KEYS */;
INSERT INTO `administracja` VALUES (1,21);
/*!40000 ALTER TABLE `administracja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `analityk`
--

DROP TABLE IF EXISTS `analityk`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `analityk` (
  `idanalityka` int NOT NULL AUTO_INCREMENT,
  `idosoby` int NOT NULL,
  PRIMARY KEY (`idanalityka`,`idosoby`),
  KEY `fk_analityk_osoba1_idx` (`idosoby`),
  CONSTRAINT `fk_analityk_osoba1` FOREIGN KEY (`idosoby`) REFERENCES `osoba` (`idosoby`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `analityk`
--

LOCK TABLES `analityk` WRITE;
/*!40000 ALTER TABLE `analityk` DISABLE KEYS */;
INSERT INTO `analityk` VALUES (1,8),(2,14),(3,17);
/*!40000 ALTER TABLE `analityk` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `badanie`
--

DROP TABLE IF EXISTS `badanie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `badanie` (
  `idbadania` int NOT NULL AUTO_INCREMENT,
  `nazwabadania` varchar(100) DEFAULT NULL,
  `cennik` decimal(10,0) DEFAULT NULL,
  `zdjecie` varchar(45) DEFAULT NULL,
  `wyróżnione` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idbadania`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `badanie`
--

LOCK TABLES `badanie` WRITE;
/*!40000 ALTER TABLE `badanie` DISABLE KEYS */;
INSERT INTO `badanie` VALUES (1,'Badanie Podstawowe',42,'podstawa.jpg',1),(2,'Badanie na Anemię',31,'anemia.jpg',1),(3,'Badanie Serca',45,'a2.jpg',1),(4,'Badanie na Alergię',33,'alergia.jpeg',0),(5,'Badanie na Cukrzycę',36,'cukrzyca.jpg',0),(6,'Badanie nerek',45,'nerki.jpg',0),(7,'Badanie na Reumatyzm',60,'reumatyzm.jpg',0),(8,'Badanie Tarczycy',68,'tarczyca.jpg',0),(9,'Badanie Wątroby',40,'watroba.jpg',0);
/*!40000 ALTER TABLE `badanie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `osoba`
--

DROP TABLE IF EXISTS `osoba`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `osoba` (
  `idosoby` int NOT NULL AUTO_INCREMENT,
  `nazwisko` varchar(200) DEFAULT NULL,
  `imie` varchar(200) DEFAULT NULL,
  `adres` varchar(200) DEFAULT NULL,
  `pesel` varchar(200) DEFAULT NULL,
  `mail` varchar(200) DEFAULT NULL,
  `telefon` varchar(200) DEFAULT NULL,
  `haslo` varchar(200) DEFAULT NULL,
  `aktywne` tinyint(1) NOT NULL,
  PRIMARY KEY (`idosoby`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `osoba`
--

LOCK TABLES `osoba` WRITE;
/*!40000 ALTER TABLE `osoba` DISABLE KEYS */;
INSERT INTO `osoba` VALUES (1,'Kowalski','Michał','Słoneczna 58 Katowice','11111111111','michal@o2.pl','111111111','haslo',0),(2,'Nowak','Michał','Szeroka 3','12345678902','nowak123@gmail.com','222444888','nowak02',0),(3,'Wiśniewski ','Robert','Jagodowa 26','12345678903','wisniewskiRobert@wp.pl','333666999','wisniewski03',0),(4,'Wójcik ','Kajetan','Łokietka 11','12345678904','wojcik.official@gmail.com','444000111','wojcik04',0),(5,'Kowalczyk','Kamil','Katowicka 1','12345678905','kowalczyk.kam@wp.pl','333222111','kowalczyk05',0),(6,'Kamiński','Andrzej','Bytomska 15','12345678906','kaminski@o2.pl','999000222','kaminski06',0),(7,'Lewandowski','Lech','Warszawska 7','12345678907','lewy@wp.pl','555777333','lewandowski07',0),(8,'Zieliński ','Zenon','Głęboka 33','12345678908','zielinski@wp.pl','111000111','zielinski08',0),(9,'Szymański ','Szymon','Powstańców 5','12345678909','szymanski@gmail.com','222333000','szymanski09',0),(10,'Kubicki','Kuba','Kubowska 8','888000888','kubicki88@wp.pl','808888000','kubicki10',0),(11,'Dąbrowska ','Jolanta','Orkowa 32','12345678911','jd@wp.pl','131121111','dabrowska11',0),(12,'Scott','Micheal','Dunder Mifflin','12345678912','Scott@gmail.com','999999999','scott12',0),(13,'Lindemann','Till','TeilStraße','12345678913','Rammstein@gmail.com','669996969','lindemann13',0),(14,'Szcześniak','Filip','Marmurowa 515','12345678914','Taco@wp.pl','515202105','szczesniak14',0),(15,'Ketchum','Ash','Kanto 1','12345678915','CathThemAll@gmail.com','999999','ketchum15',0),(16,'Najman','Marcin','Częstochowska 0','12345678916','vip@o2.pl','10000100','najman16',0),(17,'Malinowski','Łukasz','Skramblowa 2','12345678917','Malin@gmail.com','251251251','malinowski17',0),(18,'Kwiatkowska ','Maria','Wiosenna','12345678918','Kwiatkowska@wp.pl','345345345','kwiatkowska18',0),(19,'Grabowska','Gabriela','Dworcowa','12345678919','Grabowska@gmail.com','223332211','grabowska19',0),(20,'Roche','Vernom','Mahakamska 2','12345678920','Roche@gmail.com','123230321','roche20',0),(21,'Administracyjny','Adam','Szefowska','222333111','admin@gmail.com','123456789','admin',1);
/*!40000 ALTER TABLE `osoba` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pacjenci`
--

DROP TABLE IF EXISTS `pacjenci`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pacjenci` (
  `idpacjenta` int NOT NULL AUTO_INCREMENT,
  `idosoby` int NOT NULL,
  PRIMARY KEY (`idpacjenta`,`idosoby`),
  KEY `fk_pacjenci_osoba1_idx` (`idosoby`),
  CONSTRAINT `fk_pacjenci_osoba1` FOREIGN KEY (`idosoby`) REFERENCES `osoba` (`idosoby`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='			';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pacjenci`
--

LOCK TABLES `pacjenci` WRITE;
/*!40000 ALTER TABLE `pacjenci` DISABLE KEYS */;
INSERT INTO `pacjenci` VALUES (1,1),(3,2),(4,3),(9,4),(6,5),(5,7),(8,9),(7,10),(2,16);
/*!40000 ALTER TABLE `pacjenci` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personelrecepcji`
--

DROP TABLE IF EXISTS `personelrecepcji`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `personelrecepcji` (
  `idrecepcjonistki` int NOT NULL AUTO_INCREMENT,
  `idosoby` int NOT NULL,
  PRIMARY KEY (`idrecepcjonistki`,`idosoby`),
  KEY `fk_personelrecepcji_osoba1_idx` (`idosoby`),
  CONSTRAINT `fk_personelrecepcji_osoba1` FOREIGN KEY (`idosoby`) REFERENCES `osoba` (`idosoby`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personelrecepcji`
--

LOCK TABLES `personelrecepcji` WRITE;
/*!40000 ALTER TABLE `personelrecepcji` DISABLE KEYS */;
INSERT INTO `personelrecepcji` VALUES (1,6),(2,11);
/*!40000 ALTER TABLE `personelrecepcji` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pielegniarki`
--

DROP TABLE IF EXISTS `pielegniarki`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pielegniarki` (
  `idpielegniarki` int NOT NULL AUTO_INCREMENT,
  `idosoby` int NOT NULL,
  PRIMARY KEY (`idpielegniarki`,`idosoby`),
  KEY `fk_pielegniarki_osoba1_idx` (`idosoby`),
  CONSTRAINT `fk_pielegniarki_osoba1` FOREIGN KEY (`idosoby`) REFERENCES `osoba` (`idosoby`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pielegniarki`
--

LOCK TABLES `pielegniarki` WRITE;
/*!40000 ALTER TABLE `pielegniarki` DISABLE KEYS */;
INSERT INTO `pielegniarki` VALUES (1,12),(2,18),(3,19);
/*!40000 ALTER TABLE `pielegniarki` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recepcja`
--

DROP TABLE IF EXISTS `recepcja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recepcja` (
  `idwizyty` int NOT NULL,
  `idrecepcjonistki` int NOT NULL,
  KEY `idrecepcjonistki_idx` (`idrecepcjonistki`),
  KEY `idwizyty1` (`idwizyty`),
  CONSTRAINT `idrecepcjonistki` FOREIGN KEY (`idrecepcjonistki`) REFERENCES `personelrecepcji` (`idrecepcjonistki`),
  CONSTRAINT `idwizyty_a` FOREIGN KEY (`idwizyty`) REFERENCES `wizyta` (`idwizyty`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recepcja`
--

LOCK TABLES `recepcja` WRITE;
/*!40000 ALTER TABLE `recepcja` DISABLE KEYS */;
INSERT INTO `recepcja` VALUES (1,1),(2,2),(3,2),(4,2),(5,1),(6,1),(7,1),(8,1),(9,1),(10,1),(11,2),(12,2),(13,2),(14,2),(15,2),(16,2),(17,2);
/*!40000 ALTER TABLE `recepcja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wizyta`
--

DROP TABLE IF EXISTS `wizyta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `wizyta` (
  `idpacjenta` int NOT NULL,
  `idpielegniarki` int NOT NULL,
  `idwizyty` int NOT NULL AUTO_INCREMENT,
  `datawizyty` datetime DEFAULT NULL,
  `idbadania` int NOT NULL,
  PRIMARY KEY (`idwizyty`),
  KEY `idpielegniarki` (`idpielegniarki`),
  KEY `idpacjenta` (`idpacjenta`),
  KEY `idwizyty_idx` (`idwizyty`) /*!80000 INVISIBLE */,
  KEY `idwizyty` (`idwizyty`),
  KEY `idbadania_w` (`idbadania`),
  CONSTRAINT `idbadania_w` FOREIGN KEY (`idbadania`) REFERENCES `badanie` (`idbadania`),
  CONSTRAINT `idpacjenta` FOREIGN KEY (`idpacjenta`) REFERENCES `pacjenci` (`idpacjenta`),
  CONSTRAINT `idpielegniarki` FOREIGN KEY (`idpielegniarki`) REFERENCES `pielegniarki` (`idpielegniarki`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wizyta`
--

LOCK TABLES `wizyta` WRITE;
/*!40000 ALTER TABLE `wizyta` DISABLE KEYS */;
INSERT INTO `wizyta` VALUES (1,1,1,'2022-05-26 10:30:00',3),(1,2,2,'2022-05-31 10:30:00',5),(2,3,3,'2022-06-01 12:00:00',9),(4,3,4,'2022-06-01 12:30:00',9),(7,3,5,'2022-06-01 12:45:00',9),(8,3,6,'2022-06-01 13:00:00',9),(3,2,7,'2022-06-05 10:00:00',5),(4,2,8,'2022-06-05 10:15:00',5),(5,2,9,'2022-06-05 10:30:00',5),(6,2,10,'2022-06-05 10:45:00',5),(7,2,11,'2022-06-05 11:00:00',5),(9,1,12,'2022-05-26 11:00:00',3),(1,1,13,'2022-05-18 10:00:00',1),(2,1,14,'2022-05-18 10:15:00',1),(3,1,15,'2022-05-18 10:30:00',1),(4,1,16,'2022-05-18 10:45:00',1),(5,1,17,'2022-05-18 11:00:00',1);
/*!40000 ALTER TABLE `wizyta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wykonaniabadania`
--

DROP TABLE IF EXISTS `wykonaniabadania`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `wykonaniabadania` (
  `idwizyty` int NOT NULL,
  `idanalityka` int NOT NULL,
  `idbadania` int NOT NULL,
  `data` datetime DEFAULT NULL,
  `wyniki` varchar(100) DEFAULT NULL,
  `cenaaktualna` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`idbadania`),
  KEY `idanalityka_idx` (`idanalityka`),
  KEY `idbadania_idx` (`idbadania`),
  KEY `idwizyty_idx` (`idwizyty`) /*!80000 INVISIBLE */,
  CONSTRAINT `idanalityka` FOREIGN KEY (`idanalityka`) REFERENCES `analityk` (`idanalityka`),
  CONSTRAINT `idbadania` FOREIGN KEY (`idbadania`) REFERENCES `badanie` (`idbadania`),
  CONSTRAINT `idwizyty_b` FOREIGN KEY (`idwizyty`) REFERENCES `wizyta` (`idwizyty`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wykonaniabadania`
--

LOCK TABLES `wykonaniabadania` WRITE;
/*!40000 ALTER TABLE `wykonaniabadania` DISABLE KEYS */;
/*!40000 ALTER TABLE `wykonaniabadania` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-06-27 12:29:59
