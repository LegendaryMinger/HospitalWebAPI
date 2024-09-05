-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: hospital
-- ------------------------------------------------------
-- Server version	8.0.35

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
-- Table structure for table `appointment`
--

DROP TABLE IF EXISTS `appointment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `appointment` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `PatientId` int DEFAULT NULL,
  `EmployeeId` int DEFAULT NULL,
  `ServiceId` int DEFAULT NULL,
  `DateCreation` datetime DEFAULT NULL,
  `DateVisit` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `patient_appointments_idx` (`PatientId`),
  KEY `appointment_service_idx` (`ServiceId`),
  KEY `appointment_employee_idx` (`EmployeeId`),
  CONSTRAINT `appointment_employee` FOREIGN KEY (`EmployeeId`) REFERENCES `employee` (`Id`),
  CONSTRAINT `appointment_patient` FOREIGN KEY (`PatientId`) REFERENCES `patient` (`Id`),
  CONSTRAINT `appointment_service` FOREIGN KEY (`ServiceId`) REFERENCES `service` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `appointment`
--

LOCK TABLES `appointment` WRITE;
/*!40000 ALTER TABLE `appointment` DISABLE KEYS */;
INSERT INTO `appointment` VALUES (1,1,1,1,'2024-07-12 12:20:00','2024-07-14 16:00:00'),(2,2,2,2,'2024-01-14 08:00:00','2024-01-15 12:00:00'),(3,3,3,3,'2024-05-07 10:30:00','2024-05-10 09:00:00'),(4,4,4,4,'2024-05-21 11:15:00','2024-05-23 10:30:00'),(5,5,5,5,'2024-04-05 14:10:00','2024-04-06 14:00:00');
/*!40000 ALTER TABLE `appointment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `appointmentdisease`
--

DROP TABLE IF EXISTS `appointmentdisease`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `appointmentdisease` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DiseaseId` int DEFAULT NULL,
  `AppointmentId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `_disease_idx` (`DiseaseId`),
  KEY `_appointment_idx` (`AppointmentId`),
  CONSTRAINT `AppointmentDisease_Appointment` FOREIGN KEY (`AppointmentId`) REFERENCES `appointment` (`Id`),
  CONSTRAINT `AppointmentDisease_Disease` FOREIGN KEY (`DiseaseId`) REFERENCES `disease` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `appointmentdisease`
--

LOCK TABLES `appointmentdisease` WRITE;
/*!40000 ALTER TABLE `appointmentdisease` DISABLE KEYS */;
INSERT INTO `appointmentdisease` VALUES (1,1,1),(2,2,2),(3,3,3),(4,4,4),(5,5,5);
/*!40000 ALTER TABLE `appointmentdisease` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comment`
--

DROP TABLE IF EXISTS `comment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comment` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `PatientId` int DEFAULT NULL,
  `ServiceId` int DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `DateCreation` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `comment_patient_idx` (`PatientId`),
  KEY `comment_service_idx` (`ServiceId`),
  CONSTRAINT `comment_patient` FOREIGN KEY (`PatientId`) REFERENCES `patient` (`Id`),
  CONSTRAINT `comment_service` FOREIGN KEY (`ServiceId`) REFERENCES `service` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comment`
--

LOCK TABLES `comment` WRITE;
/*!40000 ALTER TABLE `comment` DISABLE KEYS */;
INSERT INTO `comment` VALUES (1,1,1,'В клинике меня принял замечательный хирург, который провел лапароскопическую операцию по удалению желчного пузыря. Процедура прошла быстро и без осложнений. Доктор был профессионален, объяснил все детали и ответил на все вопросы. Восстановление после операции прошло гладко. Очень благодарен за качественное медицинское обслуживание!','2024-01-09 10:35:00'),(2,2,2,'Недавно сделал пломбирование у стоматолога в этой клинике. Процедура была проведена аккуратно и безболезненно. Врач использовал современные материалы, и результат превосходный. Теперь зуб не беспокоит, и я могу спокойно есть и улыбаться. Очень доволен качеством работы и вниманием со стороны специалиста!','2024-04-02 18:15:00'),(3,3,3,'Посетил невролога для диагностики частых головных болей. Доктор тщательно выслушал мои жалобы, провел необходимые обследования и предложил эффективное лечение. Теперь состояние заметно улучшилось, и я чувствую себя намного лучше. Очень ценю профессионализм и внимательное отношение врача.','2024-05-15 16:30:00'),(4,4,4,'Сделал общий анализ крови в лаборатории. Процесс забора крови был быстрым и безболезненным. Лаборант оказался очень внимательным и аккуратным. Результаты были готовы в срок, и я получил четкие рекомендации от врача. Большое спасибо за качественное и оперативное обслуживание!','2024-02-26 17:40:00'),(5,5,5,'Обратился к травматологу после получения перелома ноги. Доктор быстро и профессионально оказал первую помощь, иммобилизировал конечность и дал четкие рекомендации по дальнейшему лечению. Теперь я на пути к выздоровлению и очень благодарен за оперативную помощь и грамотное лечение!','2024-07-07 14:35:00');
/*!40000 ALTER TABLE `comment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `department` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `CountRooms` int DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (1,'Хирургия',8,'г. Пермь, ул. Карла Маркса, д. 52'),(2,'Стоматология',5,'г. Пермь, ул. Гусарова, д. 7'),(3,'Неврология',8,'г. Пермь, пр. Октябрьский, д. 34'),(4,'Лаборатория',4,'г. Пермь, ул. Карла Маркса, д. 52'),(5,'Травматология',5,'г. Пермь, ул. Карла Маркса, д. 52');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `disease`
--

DROP TABLE IF EXISTS `disease`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `disease` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Symptoms` varchar(300) DEFAULT NULL,
  `Indications` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disease`
--

LOCK TABLES `disease` WRITE;
/*!40000 ALTER TABLE `disease` DISABLE KEYS */;
INSERT INTO `disease` VALUES (1,'Аппендицит','Боль в нижней правой части живота, тошнота, рвота, высокая температура, потеря аппетита.','Необходима срочная хирургическая операция по удалению аппендикса (аппендикэктомия). Может потребоваться антибактериальная терапия и послеоперационный уход.'),(2,'Кариес','Болезненные ощущения в зубе, чувствительность к горячему и холодному, видимые черные или коричневые пятна на зубах, неприятный запах изо рта.','Проведение пломбирования или реставрации зуба для удаления пораженной ткани и восстановления структуры зуба. Регулярная гигиена полости рта и профилактические осмотры.'),(3,'Миозит','Боль и слабость в мышцах, особенно после физической нагрузки, трудности с движением, отек и покраснение в области пораженных мышц.','Применение противовоспалительных препаратов, физическая терапия для укрепления мышц и улучшения подвижности. В случае инфекционного миозита могут потребоваться антибиотики.'),(4,'Анемия','Усталость, слабость, бледность кожи, головокружение, одышка.','Выполнение полного анализа крови для определения типа анемии, назначение лечения в зависимости от причины (например, железосодержащие препараты для железодефицитной анемии, витамины, изменение диеты).'),(5,'Ушиб','Боль в области травмы, отек, синяк, ограниченная подвижность в пораженной области.','Применение холода для уменьшения отека, покой и иммобилизация пострадавшего участка, обезболивающие средства. В случае серьезных ушибов может потребоваться дополнительное обследование и лечение.');
/*!40000 ALTER TABLE `disease` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DepartmentId` int DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Title` varchar(100) DEFAULT NULL,
  `DateEntry` date DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `employee_department_idx` (`DepartmentId`),
  CONSTRAINT `employee_department` FOREIGN KEY (`DepartmentId`) REFERENCES `department` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,1,'Пименов Алексей Никитич','Хирург','2023-10-23','г. Пермь, ул. Дзержинского, д. 21'),(2,2,'Григорьева Вероника Вячеславовна','Стоматолог','2022-01-26','г. Пермь, пр. Ленинского Комсомола, д. 60'),(3,3,'Орлова Анна Артемовна','Невролог','2020-07-06','г. Пермь, ул. Сибирякова, д. 18'),(4,4,'Климова Лилия Марковна','Лаборант','2023-01-25','г. Пермь, ул. Фрунзе, д. 27'),(5,5,'Семенов Виктор Тимофеевич','Травматолог','2022-02-03','г. Пермь, ул. Тимирязева, д. 4');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipment`
--

DROP TABLE IF EXISTS `equipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipment` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DepartmentId` int DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Count` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `equipment_department_idx` (`DepartmentId`),
  CONSTRAINT `equipment_department` FOREIGN KEY (`DepartmentId`) REFERENCES `department` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipment`
--

LOCK TABLES `equipment` WRITE;
/*!40000 ALTER TABLE `equipment` DISABLE KEYS */;
INSERT INTO `equipment` VALUES (1,1,'Лапароскоп',5),(2,2,'Интраоральная камера',2),(3,3,'Электроэнцефалограф (ЭЭГ)',3),(4,4,'Автоматический анализатор крови',3),(5,5,'Рентгеновский аппарат',2);
/*!40000 ALTER TABLE `equipment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gender`
--

DROP TABLE IF EXISTS `gender`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gender` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gender`
--

LOCK TABLES `gender` WRITE;
/*!40000 ALTER TABLE `gender` DISABLE KEYS */;
INSERT INTO `gender` VALUES (1,'Мужской'),(2,'Женский');
/*!40000 ALTER TABLE `gender` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `history`
--

DROP TABLE IF EXISTS `history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `history` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `PatientId` int DEFAULT NULL,
  `EmployeeId` int DEFAULT NULL,
  `DiseaseId` int DEFAULT NULL,
  `DateIllness` datetime DEFAULT NULL,
  `DateCure` datetime DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `history_patient_idx` (`PatientId`),
  KEY `history_employee_idx` (`EmployeeId`),
  KEY `history_disease_idx` (`DiseaseId`),
  CONSTRAINT `history_disease` FOREIGN KEY (`DiseaseId`) REFERENCES `disease` (`Id`),
  CONSTRAINT `history_employee` FOREIGN KEY (`EmployeeId`) REFERENCES `employee` (`Id`),
  CONSTRAINT `history_patient` FOREIGN KEY (`PatientId`) REFERENCES `patient` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `history`
--

LOCK TABLES `history` WRITE;
/*!40000 ALTER TABLE `history` DISABLE KEYS */;
INSERT INTO `history` VALUES (1,1,1,1,'2024-07-14 16:00:00','2024-07-21 16:00:00','Лечение прошло без осложнений'),(2,2,2,2,'2024-01-15 12:00:00','2024-01-15 12:00:00','Лечение прошло без осложнений'),(3,3,3,3,'2024-05-10 09:00:00','2024-06-10 09:00:00','Лечение прошло без осложнений'),(4,4,4,4,'2024-05-23 10:30:00','2024-05-30 10:30:00','Лечение прошло без осложнений'),(5,5,5,5,'2024-04-06 14:00:00','2024-04-10 14:00:00','Лечение прошло без осложнений');
/*!40000 ALTER TABLE `history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instruction`
--

DROP TABLE IF EXISTS `instruction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instruction` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EmployeeId` int DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Description` varchar(500) DEFAULT NULL,
  `DateCreation` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `instruction_employee_idx` (`EmployeeId`),
  CONSTRAINT `instruction_employee` FOREIGN KEY (`EmployeeId`) REFERENCES `employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instruction`
--

LOCK TABLES `instruction` WRITE;
/*!40000 ALTER TABLE `instruction` DISABLE KEYS */;
INSERT INTO `instruction` VALUES (1,1,'Проведение лапароскопической холецистэктомии','Эта инструкция предназначена для хирургов, занимающихся лапароскопическим удалением желчного пузыря. Включает подготовку пациента, выбор инструментов, технику выполнения операции и меры предосторожности. Упоминаются также рекомендации по послеоперационному уходу и возможные осложнения, такие как инфекции и повреждение соседних органов.','2024-09-04 00:00:00'),(2,2,'Процедура установки зубных имплантатов','Инструкция предназначена для стоматологов, занимающихся установкой зубных имплантатов. Включает этапы подготовки пациента, выбор и стерилизацию имплантатов, технику их установки, а также рекомендации по последующему уходу за имплантатами и контрольным обследованиям. Упоминаются возможные осложнения и методы их предотвращения.','2024-09-05 00:00:00'),(3,3,'Диагностике и лечению мигрени','Эта инструкция предназначена для неврологов и описывает процесс диагностики мигрени. Включает в себя сбор анамнеза, методы физического и нейрологического обследования, использование диагностических тестов и выбор подходящих терапевтических методов. Также даны рекомендации по изменению образа жизни пациента и управлению мигренями в долгосрочной перспективе.','2024-01-15 00:00:00'),(4,4,'Проведение общего анализа крови','Инструкция предназначена для лаборантов, занимающихся выполнением общего анализа крови. Описывает подготовку к забору крови, технику проведения анализа, правильное использование лабораторного оборудования, интерпретацию результатов и меры безопасности при работе с биологическими образцами. Также даны рекомендации по очистке и стерилизации оборудования.','2024-05-12 00:00:00'),(5,5,'Оказание первой помощи при переломах конечностей','Эта инструкция предназначена для травматологов и описывает шаги по оказанию первой помощи при переломах. Включает в себя методы иммобилизации сломанной конечности, обезболивание, рекомендации по транспортировке пациента в медицинское учреждение и предварительное лечение до поступления в больницу. Также даны советы по предотвращению осложнений, таких как шок или инфекция.','2024-06-08 00:00:00');
/*!40000 ALTER TABLE `instruction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `patient`
--

DROP TABLE IF EXISTS `patient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patient` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `GenderId` int DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Age` int DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `patient_gender_idx` (`GenderId`),
  CONSTRAINT `patient_gender` FOREIGN KEY (`GenderId`) REFERENCES `gender` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patient`
--

LOCK TABLES `patient` WRITE;
/*!40000 ALTER TABLE `patient` DISABLE KEYS */;
INSERT INTO `patient` VALUES (1,2,'Виноградова Ирина Александровна',28,'г. Пермь, ул. Сибирская, д. 45'),(2,1,'Морозов Василий Всеволодович',45,'г. Пермь, пр. Победы, д. 78'),(3,2,'Сергеева Варвара Артёмовна',54,'г. Пермь, ул. Комсомольская, д. 30'),(4,2,'Лазарева Стефания Игоревна',32,'г. Пермь, ул. 9 Мая, д. 56'),(5,1,'Колесников Артем Тимофеевич',38,'г. Пермь, ул. Московская, д. 22');
/*!40000 ALTER TABLE `patient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payment` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ServiceId` int DEFAULT NULL,
  `PatientId` int DEFAULT NULL,
  `Type` varchar(45) DEFAULT NULL,
  `DatePayment` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `payment_patient_idx` (`PatientId`),
  KEY `payment_service_idx` (`ServiceId`),
  CONSTRAINT `payment_patient` FOREIGN KEY (`PatientId`) REFERENCES `patient` (`Id`),
  CONSTRAINT `payment_service` FOREIGN KEY (`ServiceId`) REFERENCES `service` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` VALUES (1,1,1,'Наличный расчет','2024-07-14 18:00:00'),(2,2,2,'Безналичный расчет','2024-01-15 13:30:00'),(3,3,3,'Безналичный расчет','2024-05-10 10:00:00'),(4,4,4,'Наличный расчет','2024-05-23 10:45:00'),(5,5,5,'Безналичный расчет','2024-04-06 16:00:00');
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `service`
--

DROP TABLE IF EXISTS `service`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `service` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DepartmentId` int DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `service_department_idx` (`DepartmentId`),
  CONSTRAINT `service_department` FOREIGN KEY (`DepartmentId`) REFERENCES `department` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `service`
--

LOCK TABLES `service` WRITE;
/*!40000 ALTER TABLE `service` DISABLE KEYS */;
INSERT INTO `service` VALUES (1,1,'Прием хирурга',1000),(2,2,'Пломбирование зуба',1500),(3,3,'Прием невролога',1200),(4,4,'Анализ крови',500),(5,5,'Прием травматолога',800);
/*!40000 ALTER TABLE `service` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-09-06  1:03:58
