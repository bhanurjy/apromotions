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
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `IsActive` bit(1) DEFAULT b'0',
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` int(11) DEFAULT '1',
  `ModifiedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `ModifiedBy` int(11) DEFAULT '1',
  `RoleId` int(11) DEFAULT NULL,
  PRIMARY KEY (`UserId`),
  KEY `FK_Users_RoleID` (`RoleId`),
  CONSTRAINT `FK_Users_RoleID` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`RoleId`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'ruppalapati','R@v!7077','','2017-02-22 12:35:27',1,'2017-02-22 12:35:27',1,1),(17,'school','school','','2017-03-16 16:45:33',1,'2017-03-16 16:45:33',1,2),(19,'sponsor','sponsor','','2017-03-16 19:57:45',1,'2017-03-16 19:57:45',1,3),(20,'ravi','raviku','','2017-03-17 15:39:41',1,'2017-03-17 15:39:41',1,2),(21,'abcd','abcd','\0','2017-03-20 12:51:23',1,'2017-03-20 12:51:23',1,2),(22,'rdudukulu','prime','','2017-04-08 17:02:09',1,'2017-04-08 17:02:09',1,3),(23,'mmaddu','prime','','2017-04-08 17:04:42',1,'2017-04-08 17:04:42',1,3),(24,'ghjgh','gjghj','','2017-04-08 17:05:46',1,'2017-04-08 17:05:46',1,3),(25,'ytutyu','tyutyu','','2017-04-08 17:08:00',1,'2017-04-08 17:08:00',1,3),(26,'hjkhjk','hjkhjk','','2017-04-08 17:14:30',1,'2017-04-08 17:14:30',1,3),(27,'dfgdf','dfgdf','\0','2017-04-08 17:19:23',1,'2017-04-08 17:19:23',1,2),(28,'jkljl','kjljkl','\0','2017-04-08 17:22:13',1,'2017-04-08 17:22:13',1,2);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-06-16 16:45:10
