-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: academicpramotions
-- ------------------------------------------------------
-- Server version	5.7.10-log

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
-- Table structure for table `sponsorinfo`
--

DROP TABLE IF EXISTS `sponsorinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sponsorinfo` (
  `SponsorId` int(11) NOT NULL AUTO_INCREMENT,
  `SponsorName` varchar(100) DEFAULT NULL,
  `SponsorEmail` varchar(500) DEFAULT NULL,
  `SponsorAddress` varchar(1000) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `State` int(11) DEFAULT NULL,
  `Zip` varchar(20) DEFAULT NULL,
  `BusinessName` varchar(200) DEFAULT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `AlternatePhone` varchar(20) DEFAULT NULL,
  `Fax` varchar(200) DEFAULT NULL,
  `BusinessWebsite` varchar(100) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `UserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`SponsorId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sponsorinfo`
--

LOCK TABLES `sponsorinfo` WRITE;
/*!40000 ALTER TABLE `sponsorinfo` DISABLE KEYS */;
INSERT INTO `sponsorinfo` VALUES (3,'Ravi Uppalapati','test@mail.com','Hyd','Hyd',5,'123456',NULL,'123456','123456','123456','http://xyz.com','2017-03-16 19:57:46',19),(4,'Rafiq Dudukulu','rdudukulu@primetgi.com','Hyd','Hyd',5,'1234567','Software Company','1234567890','1234567890','123456','http://duduk','2017-04-08 17:02:10',22),(5,'Mani kumar','mmaddu@primetgi.com','Hyd','Hyd',1,'123456','Small scale industry','12345','12345','123456','http://mmaddu','2017-04-08 17:04:43',23);
/*!40000 ALTER TABLE `sponsorinfo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-06-16 16:45:09
