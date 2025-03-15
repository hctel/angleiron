-- --------------------------------------------------------
-- Hôte:                         127.0.0.1
-- Version du serveur:           9.2.0 - MySQL Community Server - GPL
-- SE du serveur:                Win64
-- HeidiSQL Version:             12.10.0.7000
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Listage de la structure de table angleiron. client
CREATE TABLE IF NOT EXISTS `client` (
  `idClient` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Address` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idClient`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Listage des données de la table angleiron.client : ~0 rows (environ)
INSERT INTO `client` (`idClient`, `Name`, `Address`, `Email`, `password`) VALUES
	(1, 'Nido Flow', '50 Promenade de l\'Alma', 'nido@e621.net', 'toto'),
	(2, 'h0rs3', 'Yiff Street 1', 'h0rs3@fa.net', 'tata');

-- Listage de la structure de table angleiron. component
CREATE TABLE IF NOT EXISTS `component` (
  `id_component` int NOT NULL AUTO_INCREMENT,
  `Description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_component`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Listage des données de la table angleiron.component : ~5 rows (environ)
INSERT INTO `component` (`id_component`, `Description`) VALUES
	(1, 'Planche de verre'),
	(2, 'Planche de bois'),
	(3, 'Vis de métal'),
	(4, 'Angleiron'),
	(5, 'Un truc qui sert à faire de la soudure');

-- Listage de la structure de table angleiron. component_type
CREATE TABLE IF NOT EXISTS `component_type` (
  `id_component` int NOT NULL,
  `id_category` int DEFAULT NULL,
  `numberpercategory` int DEFAULT NULL,
  `id_index` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id_index`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Listage des données de la table angleiron.component_type : ~9 rows (environ)
INSERT INTO `component_type` (`id_component`, `id_category`, `numberpercategory`, `id_index`) VALUES
	(1, 1, 4, 1),
	(2, 1, 5, 2),
	(3, 1, 7, 3),
	(4, 1, 5678, 4),
	(5, 1, 766657, 5),
	(1, 2, 254, 6),
	(2, 2, 5445, 7),
	(3, 2, 658746, 8),
	(4, 2, 576, 9),
	(5, 2, 44, 10);

-- Listage de la structure de table angleiron. orders
CREATE TABLE IF NOT EXISTS `orders` (
  `idorder` int NOT NULL AUTO_INCREMENT,
  `id_client` int DEFAULT NULL,
  `id_category` int DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `Already_paid` enum('Y','N') DEFAULT NULL,
  `Status` enum('ORDERED','PAID','IN_PROGRESS','COMPLETED') DEFAULT NULL,
  `date` date DEFAULT (curdate()),
  PRIMARY KEY (`idorder`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Listage des données de la table angleiron.orders : ~3 rows (environ)
INSERT INTO `orders` (`idorder`, `id_client`, `id_category`, `Price`, `Already_paid`, `Status`, `date`) VALUES
	(1, 1, 1, 70, 'Y', 'COMPLETED', '2025-03-10'),
	(2, 2, 1, 69, 'N', 'ORDERED', '2025-03-10'),
	(3, 1, 2, 874, 'Y', 'IN_PROGRESS', '2025-03-10');

-- Listage de la structure de table angleiron. stock
CREATE TABLE IF NOT EXISTS `stock` (
  `id_stock` int NOT NULL AUTO_INCREMENT,
  `id_component` int DEFAULT NULL,
  `Quantity` int DEFAULT NULL,
  `Quantity_client` int DEFAULT NULL,
  `Quantity_order` int DEFAULT NULL,
  `supplier` varchar(45) DEFAULT NULL,
  `Price` int DEFAULT NULL,
  `delivery_duration` int DEFAULT NULL,
  PRIMARY KEY (`id_stock`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Listage des données de la table angleiron.stock : ~5 rows (environ)
INSERT INTO `stock` (`id_stock`, `id_component`, `Quantity`, `Quantity_client`, `Quantity_order`, `supplier`, `Price`, `delivery_duration`) VALUES
	(1, 1, 127, 6, 0, 'ECAM', 5, 1),
	(2, 2, 1, 1, 1, 'gfdsgf', 1, 1),
	(3, 3, 1, 1, 1, 'fdsq', 1, 1),
	(4, 4, 1, 1, 1, 'bv', 1, 1),
	(5, 5, 1, 1, 1, 'ssg', 1, 1);

-- Listage de la structure de table angleiron. table_categories
CREATE TABLE IF NOT EXISTS `table_categories` (
  `id_category` int NOT NULL AUTO_INCREMENT,
  `Dimension` text,
  `Colors_available` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Options_available` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`id_category`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Listage des données de la table angleiron.table_categories : ~3 rows (environ)
INSERT INTO `table_categories` (`id_category`, `Dimension`, `Colors_available`, `Options_available`) VALUES
	(1, '69*69*12', 'RGB', 'X'),
	(2, '128*128*32', 'BW', 'X');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
