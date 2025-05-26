-- MySQL dump 10.13  Distrib 8.0.35, for Linux (x86_64)
--
-- Host: localhost    Database: angle2
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `idCategory` int NOT NULL AUTO_INCREMENT,
  `name` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `dimension` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `price` double DEFAULT '0',
  `colorsAvail` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `optionsAvail` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `imageName` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`idCategory`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Doorless','Small',30,'BW','X','image1.png'),(2,'One Door','Small',30,'BW','X','image2.png'),(3,'Two doors','Small',30,'BW','X','image3.png'),(5,'Doorless','Medium',25,'BW','X','image4.png'),(6,'One Door','Medium',50,'BW','X','image5.png'),(7,'Two Doors','Medium',75,'BW','X','image6.png'),(8,'Doorless','Large',100,'BW','X','image7.png'),(9,'One Door','Large',150,'BW','X','image8.png'),(10,'Two Doors','Large',200,'BW','X','image9.png');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clients` (
  `idClient` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `address` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `email` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idClient`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1,'Nido Flow','50 Promenade de l\'Alma','nido@e621.net','toto'),(2,'h0rs3','Yiff Street 1','h0rs3@fa.net','tata'),(3,'beta','fuzzbal way 34','beta@eta.delota','v0r3'),(4,'Prism','Lab C, Humanum Hepeiros','prism@ecam.be','jaaj');
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `component`
--

DROP TABLE IF EXISTS `component`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `component` (
  `idComponent` int NOT NULL AUTO_INCREMENT,
  `description` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `inStock` int NOT NULL DEFAULT '0',
  `inOrder` int NOT NULL DEFAULT '0',
  `inClient` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`idComponent`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `component`
--

LOCK TABLES `component` WRITE;
/*!40000 ALTER TABLE `component` DISABLE KEYS */;
INSERT INTO `component` VALUES (1,'Planche de fond (Petit)',43,-20,10),(2,'Planche côté (Petit)',46,0,20),(3,'Planche horizontale (Petit)',51,0,20),(4,'Planche de fond (Moyen)',32,0,0),(5,'Planche côté (Moyen)',64,0,0),(6,'Planche horizontale (Moyen)',64,0,0),(7,'Planche de fond (grand)',10,0,0),(8,'Planche côté (grand)',20,0,0),(9,'Planche horizontale (grand)',20,0,0),(10,'Planche porte petit (1 porte)',5,0,0),(11,'Planche porte petit (2 portes)',5,0,0),(12,'Planche porte moyen (1 porte)',10,0,0),(13,'Planche porte moyen (2 portes)',10,0,0),(14,'Planche porte grand (1 porte)',2,0,0),(15,'Planche porte grand (2 portes)',2,0,0),(16,'Angle Iron',172,0,216);
/*!40000 ALTER TABLE `component` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `componentCategory`
--

DROP TABLE IF EXISTS `componentCategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `componentCategory` (
  `idComponent` int NOT NULL,
  `idCategory` int DEFAULT NULL,
  `perCategory` int DEFAULT NULL,
  `idIndex` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`idIndex`) USING BTREE,
  KEY `idCategoryComponentCategory` (`idCategory`),
  KEY `idComponentComponentCategory` (`idComponent`),
  CONSTRAINT `idCategoryComponentCategory` FOREIGN KEY (`idCategory`) REFERENCES `categories` (`idCategory`),
  CONSTRAINT `idComponentComponentCategory` FOREIGN KEY (`idComponent`) REFERENCES `component` (`idComponent`)
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `componentCategory`
--

LOCK TABLES `componentCategory` WRITE;
/*!40000 ALTER TABLE `componentCategory` DISABLE KEYS */;
INSERT INTO `componentCategory` VALUES (1,1,1,16),(2,1,2,17),(3,1,2,18),(16,1,12,19),(1,2,1,20),(2,2,2,21),(3,2,2,22),(10,2,1,23),(16,2,12,24),(1,3,1,25),(2,3,2,26),(3,3,2,27),(11,3,2,28),(16,3,12,29),(4,5,1,30),(5,5,2,31),(6,5,2,32),(16,5,14,33),(4,6,1,34),(5,6,2,35),(6,6,2,36),(12,6,1,37),(16,6,14,38),(4,7,1,39),(5,7,2,40),(6,7,2,41),(13,7,2,42),(16,7,14,43),(7,8,1,44),(8,8,2,45),(9,8,2,46),(16,8,16,47),(7,9,1,48),(8,9,2,49),(9,9,2,50),(14,9,1,51),(16,9,16,52),(7,10,1,53),(8,10,2,54),(9,10,2,55),(15,10,2,56),(16,10,16,57);
/*!40000 ALTER TABLE `componentCategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `idOrder` int NOT NULL AUTO_INCREMENT,
  `idClient` int DEFAULT NULL,
  `idCategory` int DEFAULT NULL,
  `price` double DEFAULT NULL,
  `alreadyPaid` enum('Y','N') CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `status` enum('ORDERED','PAID','IN_PROGRESS','COMPLETED') CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `date` date DEFAULT (curdate()),
  `color` tinytext,
  PRIMARY KEY (`idOrder`) USING BTREE,
  KEY `idCategory-Client` (`idCategory`),
  KEY `idClient-order` (`idClient`),
  CONSTRAINT `idCategory-Client` FOREIGN KEY (`idCategory`) REFERENCES `categories` (`idCategory`),
  CONSTRAINT `idClient-order` FOREIGN KEY (`idClient`) REFERENCES `clients` (`idClient`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (5,1,1,50,'Y','COMPLETED','2025-05-22','B'),(8,1,1,30,'N','ORDERED','2025-05-26','M'),(9,4,1,210,'N','ORDERED','2025-05-26','B'),(10,4,1,210,'N','ORDERED','2025-05-26','B'),(11,4,1,210,'N','ORDERED','2025-05-26','B'),(12,4,1,210,'N','ORDERED','2025-05-26','B'),(13,4,1,210,'N','ORDERED','2025-05-26','B'),(14,4,1,210,'N','ORDERED','2025-05-26','B'),(15,4,1,210,'N','ORDERED','2025-05-26','B'),(16,4,1,210,'N','ORDERED','2025-05-26','B');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stock` (
  `idStock` int NOT NULL AUTO_INCREMENT,
  `idComponent` int DEFAULT NULL,
  `quantityInStock` int DEFAULT NULL,
  `quantityClient` int DEFAULT NULL,
  `quantityOrder` int DEFAULT NULL,
  `supplier` varchar(45) DEFAULT NULL,
  `price` int DEFAULT NULL,
  `deliveryDuration` int DEFAULT NULL,
  PRIMARY KEY (`idStock`) USING BTREE,
  KEY `idComponentStock` (`idComponent`),
  CONSTRAINT `idComponentStock` FOREIGN KEY (`idComponent`) REFERENCES `component` (`idComponent`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock`
--

LOCK TABLES `stock` WRITE;
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
INSERT INTO `stock` VALUES (1,1,43,10,-20,'ECAM',5,1),(2,2,46,20,0,'ECAM',1,1),(3,3,51,20,0,'e621 Corporation',1,1),(4,4,32,0,0,'ECAM',1,1),(5,5,64,0,0,'ECAM',1,1),(6,6,64,0,0,'e621 Corporation',6,2),(7,7,10,0,0,'ECAM',1,1),(8,8,20,0,0,'ECAM',1,1),(9,9,20,0,0,'e621 Corporation',1,1),(11,10,5,0,0,'Yiff Industries',1,1),(12,11,5,0,0,'Yiff Industries',1,1),(13,12,10,0,0,'Yiff Industries',1,1),(14,13,10,0,0,'Yiff Industries',1,1),(15,14,2,0,0,'Yiff Industries',1,1),(16,15,2,0,0,'Yiff Industries',1,1),(17,16,86,108,0,'MetalWork AG',1,1),(18,16,86,108,0,'JaaJ Manufacturing',2,1);
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `after_stock_insert` AFTER INSERT ON `stock` FOR EACH ROW BEGIN
    CALL update_component_totals();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `after_stock_update` AFTER UPDATE ON `stock` FOR EACH ROW BEGIN
    CALL update_component_totals();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `after_stock_delete` AFTER DELETE ON `stock` FOR EACH ROW BEGIN
    CALL update_component_totals();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-26 16:24:39
