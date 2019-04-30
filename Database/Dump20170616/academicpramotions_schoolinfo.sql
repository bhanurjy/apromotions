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
-- Table structure for table `schoolinfo`
--

DROP TABLE IF EXISTS `schoolinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `schoolinfo` (
  `SchoolInfoId` int(11) NOT NULL AUTO_INCREMENT,
  `SchoolName` varchar(150) DEFAULT NULL,
  `SchoolFirstColor` varchar(50) DEFAULT NULL,
  `MastCot` varchar(50) DEFAULT NULL,
  `SchoolAddress` varchar(500) DEFAULT NULL,
  `City` varchar(50) DEFAULT NULL,
  `Zip` varchar(20) DEFAULT NULL,
  `ShippingAddress` varchar(500) DEFAULT NULL,
  `ShippingCity` varchar(50) DEFAULT NULL,
  `ShippingState` int(11) DEFAULT NULL,
  `ShippingZip` varchar(20) DEFAULT NULL,
  `Telephone` varchar(20) DEFAULT NULL,
  `AlternateTelephone` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Website` varchar(100) DEFAULT NULL,
  `ContactNumber` varchar(20) DEFAULT NULL,
  `ContactTitle` varchar(100) DEFAULT NULL,
  `ItemsRequiredFor` varchar(100) DEFAULT NULL,
  `ReceiveItemsForYear` varchar(10) DEFAULT NULL,
  `ItemsUsedFor` varchar(50) DEFAULT NULL,
  `AnnounceSponcerName` bit(1) DEFAULT NULL,
  `SchoolSecondColor` varchar(50) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `StateId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `IsActive` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`SchoolInfoId`),
  KEY `FK_SchoolState_SchoolStateId_idx` (`StateId`),
  CONSTRAINT `FK_SchoolState_SchoolStateId` FOREIGN KEY (`StateId`) REFERENCES `state` (`StateId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schoolinfo`
--

LOCK TABLES `schoolinfo` WRITE;
/*!40000 ALTER TABLE `schoolinfo` DISABLE KEYS */;
INSERT INTO `schoolinfo` VALUES (19,'Manoj Public School','White',NULL,'Hyderabad','Hyderabad','123456789','Hyderabad','Hyderabad',5,'123456','32131','32132','Hyderabad','http://Hyderabad','Hyderabad','Hyderabad','football,Cricket','1','1','\0',NULL,'2017-03-16 16:45:34',5,17,1),(20,'Ravi School','Orange',NULL,'Hyderabad','Hyderabad','123456','Hyderabad','Hyderabad',3,'123456','1234567890','1234578903','m@gmail.com','http://www.xyz.com','Ravi','Mr','football,basketball','1','1','\0',NULL,'2017-03-17 15:39:42',10,20,1),(21,'Abcd English school','Pink',NULL,'12345','Hyderabad','123456','Hyderabad','Hyderabad',5,'123456','9014032111','9012032111','abcd@mail.com','http://abcd','Ravi','Architect','football','1','1','\0',NULL,'2017-03-20 12:51:23',5,21,0),(22,'gfdgdfg','dfgdf','dfg','dfgdfg','dfgdfg','546546456','45656','hyd',14,'56456','456456456','546456546','546546456','http://4564','ryrty','rtyrty','football,cricket','1','1','\0','dfg','2017-04-08 17:19:23',13,27,0),(23,'kjlj','jkljkl',NULL,'jklkjl','jkljkl','89789','jkljkl','jklkjl',4,'89089','89089','8909','kjouio','http://ouipo','iouio','uiouo','football','1','1','\0',NULL,'2017-04-08 17:22:13',2,28,0);
/*!40000 ALTER TABLE `schoolinfo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-06-16 16:45:08
