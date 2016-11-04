CREATE DATABASE  IF NOT EXISTS `moviedatabase` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `moviedatabase`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: moviedatabase
-- ------------------------------------------------------
-- Server version	5.7.16-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `movieratingreport`
--

DROP TABLE IF EXISTS `movieratingreport`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movieratingreport` (
  `id` int(11) NOT NULL,
  `name` varchar(50) DEFAULT NULL,
  `rating` float DEFAULT NULL,
  `description` varchar(500) DEFAULT NULL,
  `year` datetime DEFAULT NULL,
  `duration` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Default DB for pulling out a report for all movies and their respective rating';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movieratingreport`
--

LOCK TABLES `movieratingreport` WRITE;
/*!40000 ALTER TABLE `movieratingreport` DISABLE KEYS */;
INSERT INTO `movieratingreport` VALUES (1,'Assassins Creed',6.3,'When Callum Lynch explores the memories of his ancestor Aguilar and gains the skills of a Master Assassin, he discovers he is a descendant of the secret Assassins society. ','2016-12-21 00:00:00','2 h 22 min'),(2,'Into the Inferno',8,'An exploration of active volcanoes around world. ','2016-10-28 00:00:00','1 h 44 min'),(3,'Salt and Fire',4.9,'A scientist blames the head of a large company for an ecological disaster in South America. But when a volcano begins to show signs of erupting, they must unite to avoid a disaster. ','2016-11-17 00:00:00','1 h 38 min'),(4,'Inferno',6.5,'When Robert Langdon wakes up in an Italian hospital with amnesia, he teams up with Dr. Sienna Brooks, and together they must race across Europe against the clock to foil a deadly global plot. ','2016-10-28 00:00:00','2 h 1 min'),(5,'Angels & Demons',6.7,'Harvard symbologist Robert Langdon works to solve a murder and prevent a terrorist act against the Vatican.','2009-05-15 00:00:00','2 h 18 min'),(6,'The Terminal',7.3,'An eastern immigrant finds himself stranded in JFK airport, and must take up temporary residence there. ','2004-06-18 00:00:00','2 h 8 min '),(8,'Cast Away',7.7,'\nA FedEx executive must transform himself physically and emotionally to survive a crash landing on a deserted island. ','2000-12-22 00:00:00','2 h 23 min'),(9,'Captain Phillips',7.9,'The true story of Captain Richard Phillips and the 2009 hijacking by Somali pirates of the US-flagged MV Maersk Alabama, the first American cargo ship to be hijacked in two hundred years. ','2013-10-11 00:00:00','2 h 14 min'),(10,'The Da Vinci Code',6.6,'A murder inside the Louvre and clues in Da Vinci paintings lead to the discovery of a religious mystery protected by a secret society for two thousand years -- which could shake the foundations of Christianity. ','2006-05-19 00:00:00','2 h 29 min');
/*!40000 ALTER TABLE `movieratingreport` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-11-04 17:06:05
