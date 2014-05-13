-- Database: playertracker
-- ------------------------------------------------------
-- Server version	5.7.3-m13-log

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

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `<? DATABASE_NAME>` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `<? DATABASE_NAME>`;

--
-- Table structure for table `players`
--

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `<? PLAYER_TABLE>` (
  `id` int(11) NOT NULL auto_increment,
  `serverId` int(11) NOT NULL,
  `playerName` text(35) NOT NULL,
  `notes` text NOT NULL,
  `violations` text NOT NULL,
  `violationLevel` tinyint(4) NOT NULL,
  PRIMARY KEY (`id`,`serverId`,`playerName`(35)),
  KEY `<? PLAYER_TABLE>` (`serverId`),
  CONSTRAINT `players_ibfk_1` FOREIGN KEY (`serverId`) REFERENCES `<? SERVER_TABLE>` (`serverId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `screenshots`
--

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `<? ATTACHMENT_TABLE>` (
  `playerId` int(11) NOT NULL,
  `serverId` int(11) NOT NULL,
  `data` blob NOT NULL,
  `uploadDate` datetime not null,
  `uploadingUserId` int not null,
  KEY `<? ATTACHMENT_TABLE>` (`serverId`),
  KEY `<? PLAYER_TABLE>` (`playerId`),
  CONSTRAINT `screenshots_ibfk_2` FOREIGN KEY (`playerId`) REFERENCES `<? PLAYER_TABLE>` (`id`),
  CONSTRAINT `screenshots_ibfk_1` FOREIGN KEY (`serverId`) REFERENCES `<? SERVER_TABLE>` (`serverId`),
  CONSTRAINT `screenshots_ibfk_3` FOREIGN KEY (`uploadingUserId`) REFERENCES `<? USER_TABLE>` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `servers`
--

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `<? SERVER_TABLE>` (
  `serverId` int(11) NOT NULL auto_increment,
  `serverName` text NOT NULL,
  PRIMARY KEY (`serverId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `users`
--

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `<? USER_TABLE>` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `firstName` text NOT NULL,
  `lastName` text NOT NULL,
  `email` text NOT NULL,
  `username` text NOT NULL,
  `pass` text NOT NULL,
  `serverAccess` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;