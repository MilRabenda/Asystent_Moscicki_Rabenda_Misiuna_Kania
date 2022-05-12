-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: localhost    Database: laboratorium
-- ------------------------------------------------------
-- Server version	8.0.29

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
-- Table structure for table `analityk`
--

DROP TABLE IF EXISTS `analityk`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `analityk` (
  `idanalityka` int NOT NULL,
  `idosoby` varchar(45) NOT NULL,
  PRIMARY KEY (`idanalityka`,`idosoby`),
  KEY `fk_analityk_osoba1_idx` (`idosoby`),
  CONSTRAINT `fk_analityk_osoba1` FOREIGN KEY (`idosoby`) REFERENCES `osoba` (`idosoby`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `analityk`
--

LOCK TABLES `analityk` WRITE;
/*!40000 ALTER TABLE `analityk` DISABLE KEYS */;
/*!40000 ALTER TABLE `analityk` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `badanie`
--

DROP TABLE IF EXISTS `badanie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `badanie` (
  `idbadania` int NOT NULL,
  `nazwabadania` varchar(100) DEFAULT NULL,
  `cennik` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idbadania`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `badanie`
--

LOCK TABLES `badanie` WRITE;
/*!40000 ALTER TABLE `badanie` DISABLE KEYS */;
/*!40000 ALTER TABLE `badanie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `osoba`
--

DROP TABLE IF EXISTS `osoba`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `osoba` (
  `idosoby` varchar(45) NOT NULL,
  `nazwisko` varchar(200) DEFAULT NULL,
  `imie` varchar(200) DEFAULT NULL,
  `adres` varchar(200) DEFAULT NULL,
  `pesel` varchar(200) DEFAULT NULL,
  `mail` varchar(200) DEFAULT NULL,
  `telefon` varchar(200) DEFAULT NULL,
  `haslo` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idosoby`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `osoba`
--

LOCK TABLES `osoba` WRITE;
/*!40000 ALTER TABLE `osoba` DISABLE KEYS */;
INSERT INTO `osoba` VALUES ('1','Kowalski','Michał','Słoneczna 58 Katowice','11111111111','michal@o2.pl','111111111','haslo');
/*!40000 ALTER TABLE `osoba` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pacjenci`
--

DROP TABLE IF EXISTS `pacjenci`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pacjenci` (
  `idpacjenta` int NOT NULL,
  `idosoby` varchar(45) NOT NULL,
  PRIMARY KEY (`idpacjenta`,`idosoby`),
  KEY `fk_pacjenci_osoba1_idx` (`idosoby`),
  CONSTRAINT `fk_pacjenci_osoba1` FOREIGN KEY (`idosoby`) REFERENCES `osoba` (`idosoby`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='			';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pacjenci`
--

LOCK TABLES `pacjenci` WRITE;
/*!40000 ALTER TABLE `pacjenci` DISABLE KEYS */;
INSERT INTO `pacjenci` VALUES (1,'1');
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
  `idosoby` varchar(45) NOT NULL,
  PRIMARY KEY (`idrecepcjonistki`,`idosoby`),
  KEY `fk_personelrecepcji_osoba1_idx` (`idosoby`),
  CONSTRAINT `fk_personelrecepcji_osoba1` FOREIGN KEY (`idosoby`) REFERENCES `osoba` (`idosoby`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personelrecepcji`
--

LOCK TABLES `personelrecepcji` WRITE;
/*!40000 ALTER TABLE `personelrecepcji` DISABLE KEYS */;
/*!40000 ALTER TABLE `personelrecepcji` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pielegniarki`
--

DROP TABLE IF EXISTS `pielegniarki`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pielegniarki` (
  `idpielegniarki` int NOT NULL,
  `idosoby` varchar(45) NOT NULL,
  PRIMARY KEY (`idpielegniarki`,`idosoby`),
  KEY `fk_pielegniarki_osoba1_idx` (`idosoby`),
  CONSTRAINT `fk_pielegniarki_osoba1` FOREIGN KEY (`idosoby`) REFERENCES `osoba` (`idosoby`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pielegniarki`
--

LOCK TABLES `pielegniarki` WRITE;
/*!40000 ALTER TABLE `pielegniarki` DISABLE KEYS */;
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
  PRIMARY KEY (`idrecepcjonistki`),
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
  `idwizyty` int NOT NULL,
  `datawizyty` datetime DEFAULT NULL,
  PRIMARY KEY (`idwizyty`),
  KEY `idpielegniarki` (`idpielegniarki`),
  KEY `idpacjenta` (`idpacjenta`),
  KEY `idwizyty_idx` (`idwizyty`) /*!80000 INVISIBLE */,
  KEY `idwizyty` (`idwizyty`),
  CONSTRAINT `idpacjenta` FOREIGN KEY (`idpacjenta`) REFERENCES `pacjenci` (`idpacjenta`),
  CONSTRAINT `idpielegniarki` FOREIGN KEY (`idpielegniarki`) REFERENCES `pielegniarki` (`idpielegniarki`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wizyta`
--

LOCK TABLES `wizyta` WRITE;
/*!40000 ALTER TABLE `wizyta` DISABLE KEYS */;
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
  `cenaaktualna` varchar(100) DEFAULT NULL,
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

-- Dump completed on 2022-05-10 20:28:51
