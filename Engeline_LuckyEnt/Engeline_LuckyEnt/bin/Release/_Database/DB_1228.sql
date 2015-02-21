-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.5.28 - MySQL Community Server (GPL)
-- Server OS:                    Win32
-- HeidiSQL version:             7.0.0.4053
-- Date/time:                    2012-12-28 11:22:09
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET FOREIGN_KEY_CHECKS=0 */;

-- Dumping database structure for engeline_luckyent
CREATE DATABASE IF NOT EXISTS `engeline_luckyent` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `engeline_luckyent`;


-- Dumping structure for table engeline_luckyent.agentcommission
CREATE TABLE IF NOT EXISTS `agentcommission` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `AgentID` int(10) unsigned NOT NULL,
  `InvoiceID` int(10) unsigned NOT NULL DEFAULT '0',
  `SalesTotal` double NOT NULL DEFAULT '0',
  `SalesItem` double NOT NULL DEFAULT '0',
  `SalesTrading` double NOT NULL DEFAULT '0',
  `SalesFab` double NOT NULL DEFAULT '0',
  `SalesMiscItems` double NOT NULL DEFAULT '0',
  `Canceled` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_agentcommission_salesinvoice` (`InvoiceID`),
  CONSTRAINT `FK_agentcommission_salesinvoice` FOREIGN KEY (`InvoiceID`) REFERENCES `salesinvoice` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.agentcommission: ~0 rows (approximately)
DELETE FROM `agentcommission`;
/*!40000 ALTER TABLE `agentcommission` DISABLE KEYS */;
/*!40000 ALTER TABLE `agentcommission` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.agentcommissionitemdetails
CREATE TABLE IF NOT EXISTS `agentcommissionitemdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ItemDetails_ID` int(10) unsigned NOT NULL,
  `AmountSales` double NOT NULL,
  `CommissionID` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_agentcommissionitemdetails_agentcommission` (`CommissionID`),
  CONSTRAINT `FK_agentcommissionitemdetails_agentcommission` FOREIGN KEY (`CommissionID`) REFERENCES `agentcommission` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.agentcommissionitemdetails: ~0 rows (approximately)
DELETE FROM `agentcommissionitemdetails`;
/*!40000 ALTER TABLE `agentcommissionitemdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `agentcommissionitemdetails` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.agentquota
CREATE TABLE IF NOT EXISTS `agentquota` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `AgentID` int(10) unsigned NOT NULL,
  `Quota` double NOT NULL,
  `FixSalesDetailsID` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_agentquota_contacts` (`AgentID`),
  CONSTRAINT `FK_agentquota_contacts` FOREIGN KEY (`AgentID`) REFERENCES `contacts` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.agentquota: ~0 rows (approximately)
DELETE FROM `agentquota`;
/*!40000 ALTER TABLE `agentquota` DISABLE KEYS */;
/*!40000 ALTER TABLE `agentquota` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.agentquotaexemptitem
CREATE TABLE IF NOT EXISTS `agentquotaexemptitem` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ItemDetailsID` int(10) unsigned NOT NULL,
  `ItemID` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.agentquotaexemptitem: ~0 rows (approximately)
DELETE FROM `agentquotaexemptitem`;
/*!40000 ALTER TABLE `agentquotaexemptitem` DISABLE KEYS */;
/*!40000 ALTER TABLE `agentquotaexemptitem` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.agentquotafixsalesdetails
CREATE TABLE IF NOT EXISTS `agentquotafixsalesdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Quota` double NOT NULL,
  `Commission` double NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.agentquotafixsalesdetails: ~0 rows (approximately)
DELETE FROM `agentquotafixsalesdetails`;
/*!40000 ALTER TABLE `agentquotafixsalesdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `agentquotafixsalesdetails` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.agentquotaitemdetails
CREATE TABLE IF NOT EXISTS `agentquotaitemdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `QuotaID` int(10) unsigned NOT NULL,
  `ItemName` varchar(50) NOT NULL,
  `LimitValue` double NOT NULL DEFAULT '0',
  `PercentCommission` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.agentquotaitemdetails: ~0 rows (approximately)
DELETE FROM `agentquotaitemdetails`;
/*!40000 ALTER TABLE `agentquotaitemdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `agentquotaitemdetails` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.badorder
CREATE TABLE IF NOT EXISTS `badorder` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `BO_Date` datetime NOT NULL,
  `Amount` double NOT NULL DEFAULT '0',
  `VoucherID` int(10) unsigned NOT NULL DEFAULT '0',
  `Cancelled` int(1) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_BadOrder_voucher` (`VoucherID`),
  CONSTRAINT `FK_BadOrder_voucher` FOREIGN KEY (`VoucherID`) REFERENCES `voucher` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.badorder: ~0 rows (approximately)
DELETE FROM `badorder`;
/*!40000 ALTER TABLE `badorder` DISABLE KEYS */;
/*!40000 ALTER TABLE `badorder` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.badorderdetails
CREATE TABLE IF NOT EXISTS `badorderdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `BadOrder_ID` int(10) unsigned NOT NULL DEFAULT '0',
  `SID_ID` int(10) unsigned NOT NULL DEFAULT '0',
  `QTY` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_BadOrderDetails_badorder` (`BadOrder_ID`),
  KEY `FK_BadOrderDetails_stockindetails` (`SID_ID`),
  CONSTRAINT `FK_BadOrderDetails_badorder` FOREIGN KEY (`BadOrder_ID`) REFERENCES `badorder` (`ID`),
  CONSTRAINT `FK_BadOrderDetails_stockindetails` FOREIGN KEY (`SID_ID`) REFERENCES `stockindetails` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.badorderdetails: ~0 rows (approximately)
DELETE FROM `badorderdetails`;
/*!40000 ALTER TABLE `badorderdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `badorderdetails` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.banks
CREATE TABLE IF NOT EXISTS `banks` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `ShortDescription` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.banks: ~3 rows (approximately)
DELETE FROM `banks`;
/*!40000 ALTER TABLE `banks` DISABLE KEYS */;
INSERT INTO `banks` (`ID`, `Name`, `ShortDescription`) VALUES
	(1, 'Metrobank', 'MTBC'),
	(3, 'Banco De Oro', 'BDO'),
	(4, 'New Bank', 'NBK');
/*!40000 ALTER TABLE `banks` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.bundleditem
CREATE TABLE IF NOT EXISTS `bundleditem` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Description` varchar(100) NOT NULL,
  `UnitPrice` double NOT NULL,
  `ComputedPrice` double NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.bundleditem: ~0 rows (approximately)
DELETE FROM `bundleditem`;
/*!40000 ALTER TABLE `bundleditem` DISABLE KEYS */;
/*!40000 ALTER TABLE `bundleditem` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.bundleditemdetails
CREATE TABLE IF NOT EXISTS `bundleditemdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `BundleID` int(10) unsigned NOT NULL,
  `ItemID` int(10) unsigned DEFAULT '0',
  `QTY` int(10) unsigned NOT NULL,
  `UnitPrice` double NOT NULL,
  `FabID` int(10) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.bundleditemdetails: ~0 rows (approximately)
DELETE FROM `bundleditemdetails`;
/*!40000 ALTER TABLE `bundleditemdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `bundleditemdetails` ENABLE KEYS */;


-- Dumping structure for procedure engeline_luckyent.CleanTransactions
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `CleanTransactions`()
BEGIN
SET foreign_key_checks=0;
  TRUNCATE TABLE badorderdetails;
  TRUNCATE TABLE badorder;

  TRUNCATE TABLE agentquotaitemdetails;
  TRUNCATE TABLE agentquotafixsalesdetails;
  TRUNCATE TABLE agentquotaexemptitem;
  TRUNCATE TABLE agentquota;
  TRUNCATE TABLE agentcommissionitemdetails;
  TRUNCATE TABLE agentcommission;
  TRUNCATE TABLE customercommission;

  TRUNCATE TABLE paymentsdetail;
  TRUNCATE TABLE paymentspdc;
  TRUNCATE TABLE payments;

  TRUNCATE TABLE returneditemsdetails;
  TRUNCATE TABLE returneditemsdetails_stockin;  
  TRUNCATE TABLE returneditems;

  TRUNCATE TABLE counterdetails;
  TRUNCATE TABLE counter;

  TRUNCATE TABLE salesinvoicedetails_stockin;
  TRUNCATE TABLE salesinvoicedetails;
  TRUNCATE TABLE salesinvoice;
  
  TRUNCATE TABLE loaneditemsdetails_stockin;
  TRUNCATE TABLE loaneditemsdetails;
  TRUNCATE TABLE loaneditems;

  TRUNCATE TABLE voucherpayment;
  TRUNCATE TABLE voucherdetails;
  TRUNCATE TABLE voucher;

  TRUNCATE TABLE wirebreakdown;
  TRUNCATE TABLE freight;
  TRUNCATE TABLE stockindetails;
  TRUNCATE TABLE StockIn;

  TRUNCATE TABLE purchaseorderdetails;
  TRUNCATE TABLE purchaseorderdiscounts;
  TRUNCATE TABLE purchaseorder;

  TRUNCATE TABLE quotationdetails;
  TRUNCATE TABLE quotation;

  TRUNCATE TABLE BundledItemDetails;
  TRUNCATE TABLE BundledItem;
  TRUNCATE TABLE fabricateditem;
  TRUNCATE TABLE tradingitem;
  TRUNCATE TABLE requestapproval;
  
  TRUNCATE TABLE statementofaccount;
  TRUNCATE TABLE statementofaccountdetails;
  TRUNCATE TABLE soc_payments;
  
  TRUNCATE TABLE settings;
  
  UPDATE Items set QTYOnHand1=0, QTYOnHand2 =0;
  UPDATE Contacts set AgentID=null, CreditUsed=0;
  UPDATE salesinvoice set CounterID=0;
END//
DELIMITER ;


-- Dumping structure for table engeline_luckyent.companyprofile
CREATE TABLE IF NOT EXISTS `companyprofile` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CompanyName` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Phone` varchar(255) DEFAULT NULL,
  `Fax` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Website` varchar(255) DEFAULT NULL,
  `SSS` varchar(50) DEFAULT NULL,
  `TIN` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.companyprofile: ~1 rows (approximately)
DELETE FROM `companyprofile`;
/*!40000 ALTER TABLE `companyprofile` DISABLE KEYS */;
INSERT INTO `companyprofile` (`ID`, `CompanyName`, `Address`, `Phone`, `Fax`, `Email`, `Website`, `SSS`, `TIN`) VALUES
	(1, 'Engeline Lucky Enterprises', 'Cebu City', '1', '2', '3', '4', '5', '6');
/*!40000 ALTER TABLE `companyprofile` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.contacts
CREATE TABLE IF NOT EXISTS `contacts` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CompanyName` varchar(45) DEFAULT NULL,
  `CompanyAddress` varchar(45) DEFAULT NULL,
  `CompanyContactNumber` varchar(45) DEFAULT NULL,
  `Terms` int(10) unsigned DEFAULT '0',
  `Terms_PDC` int(10) unsigned DEFAULT '0',
  `CreditLimit` double DEFAULT '0',
  `ContactType` int(10) unsigned NOT NULL DEFAULT '0',
  `SalesRepresentative` varchar(45) DEFAULT NULL,
  `FirstName` varchar(100) DEFAULT NULL,
  `MiddleName` varchar(45) DEFAULT NULL,
  `LastName` varchar(45) DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `MobileNumber` varchar(45) DEFAULT NULL,
  `LandlineNumber` varchar(45) DEFAULT NULL,
  `FaxNumber` varchar(45) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `Comp_TIN` varchar(45) DEFAULT NULL,
  `Comp_BIR_Acc_No` varchar(45) DEFAULT NULL,
  `Comp_SEC_Acc_No1` varchar(45) DEFAULT NULL,
  `Comp_SEC_Acc_No2` varchar(45) DEFAULT NULL,
  `Comp_C13` varchar(45) DEFAULT NULL,
  `Comp_Non_Vat_Reg` varchar(45) DEFAULT NULL,
  `Comp_Vat_Reg` varchar(45) DEFAULT NULL,
  `Comp_Contact_Person_Accounting` varchar(45) DEFAULT NULL,
  `Comp_Contact_Number_Accounting` varchar(45) DEFAULT NULL,
  `Comp_Contact_Person_Purchasing` varchar(45) DEFAULT NULL,
  `Comp_Contact_Number_Purchasing` varchar(45) DEFAULT NULL,
  `Comp_Contact_Person_HeadOffice` varchar(45) DEFAULT NULL,
  `Comp_Contact_Number_HeadOffice` varchar(45) DEFAULT NULL,
  `BusinessRef_Name1` varchar(45) DEFAULT NULL,
  `BusinessRef_Address1` varchar(45) DEFAULT NULL,
  `BusinessRef_ContactPerson1` varchar(45) DEFAULT NULL,
  `BusinessRef_Number1` varchar(45) DEFAULT NULL,
  `BusinessRef_Name2` varchar(45) DEFAULT NULL,
  `BusinessRef_Address2` varchar(45) DEFAULT NULL,
  `BusinessRef_ContactPerson2` varchar(45) DEFAULT NULL,
  `BusinessRef_Number2` varchar(45) DEFAULT NULL,
  `BusinessRef_Name3` varchar(45) DEFAULT NULL,
  `BusinessRef_Address3` varchar(45) DEFAULT NULL,
  `BusinessRef_ContactPerson3` varchar(45) DEFAULT NULL,
  `BusinessRef_Number3` varchar(45) DEFAULT NULL,
  `StockHolderName1` varchar(45) DEFAULT NULL,
  `StockHolderAddress1` varchar(45) DEFAULT NULL,
  `StockHolderNumber1` varchar(45) DEFAULT NULL,
  `StockHolderName2` varchar(45) DEFAULT NULL,
  `StockHolderAddress2` varchar(45) DEFAULT NULL,
  `StockHolderNumber2` varchar(45) DEFAULT NULL,
  `StockHolderName3` varchar(45) DEFAULT NULL,
  `StockHolderAddress3` varchar(45) DEFAULT NULL,
  `StockHolderNumber3` varchar(45) DEFAULT NULL,
  `BankRef1` int(10) unsigned DEFAULT NULL,
  `BankBranch1` varchar(45) DEFAULT NULL,
  `BankAccountNum1` varchar(45) DEFAULT NULL,
  `BankContactNumber1` varchar(45) DEFAULT NULL,
  `BankRef2` int(10) unsigned DEFAULT NULL,
  `BankBranch2` varchar(45) DEFAULT NULL,
  `BankAccountNum2` varchar(45) DEFAULT NULL,
  `BankContactNumber2` varchar(45) DEFAULT NULL,
  `BankRef3` int(10) unsigned DEFAULT NULL,
  `BankBranch3` varchar(45) DEFAULT NULL,
  `BankAccountNum3` varchar(45) DEFAULT NULL,
  `BankContactNumber3` varchar(45) DEFAULT NULL,
  `BankRef4` int(10) unsigned DEFAULT NULL,
  `BankBranch4` varchar(45) DEFAULT NULL,
  `BankAccountNum4` varchar(45) DEFAULT NULL,
  `BankContactNumber4` varchar(45) DEFAULT NULL,
  `BankRef5` int(10) unsigned DEFAULT NULL,
  `BankBranch5` varchar(45) DEFAULT NULL,
  `BankAccountNum5` varchar(45) DEFAULT NULL,
  `BankContactNumber5` varchar(45) DEFAULT NULL,
  `CompanyOfficial_Name1` varchar(45) DEFAULT NULL,
  `CompanyOfficial_Address1` varchar(45) DEFAULT NULL,
  `CompanyOfficial_Number1` varchar(45) DEFAULT NULL,
  `CompanyOfficial_Designation1` varchar(45) DEFAULT NULL,
  `CompanyOfficial_Name2` varchar(45) DEFAULT NULL,
  `CompanyOfficial_Address2` varchar(45) DEFAULT NULL,
  `CompanyOfficial_Number2` varchar(45) DEFAULT NULL,
  `CompanyOfficial_Designation2` varchar(45) DEFAULT NULL,
  `CompanyOfficial_Name3` varchar(45) DEFAULT NULL,
  `CompanyOfficial_Address3` varchar(45) DEFAULT NULL,
  `CompanyOfficial_Number3` varchar(45) DEFAULT NULL,
  `CompanyOfficial_Designation3` varchar(45) DEFAULT NULL,
  `CreditUsed` double DEFAULT '0',
  `AgentID` int(10) unsigned DEFAULT '0',
  `AnnualCommisionPercentage` double DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.contacts: ~3 rows (approximately)
DELETE FROM `contacts`;
/*!40000 ALTER TABLE `contacts` DISABLE KEYS */;
INSERT INTO `contacts` (`ID`, `CompanyName`, `CompanyAddress`, `CompanyContactNumber`, `Terms`, `Terms_PDC`, `CreditLimit`, `ContactType`, `SalesRepresentative`, `FirstName`, `MiddleName`, `LastName`, `Address`, `MobileNumber`, `LandlineNumber`, `FaxNumber`, `Description`, `Comp_TIN`, `Comp_BIR_Acc_No`, `Comp_SEC_Acc_No1`, `Comp_SEC_Acc_No2`, `Comp_C13`, `Comp_Non_Vat_Reg`, `Comp_Vat_Reg`, `Comp_Contact_Person_Accounting`, `Comp_Contact_Number_Accounting`, `Comp_Contact_Person_Purchasing`, `Comp_Contact_Number_Purchasing`, `Comp_Contact_Person_HeadOffice`, `Comp_Contact_Number_HeadOffice`, `BusinessRef_Name1`, `BusinessRef_Address1`, `BusinessRef_ContactPerson1`, `BusinessRef_Number1`, `BusinessRef_Name2`, `BusinessRef_Address2`, `BusinessRef_ContactPerson2`, `BusinessRef_Number2`, `BusinessRef_Name3`, `BusinessRef_Address3`, `BusinessRef_ContactPerson3`, `BusinessRef_Number3`, `StockHolderName1`, `StockHolderAddress1`, `StockHolderNumber1`, `StockHolderName2`, `StockHolderAddress2`, `StockHolderNumber2`, `StockHolderName3`, `StockHolderAddress3`, `StockHolderNumber3`, `BankRef1`, `BankBranch1`, `BankAccountNum1`, `BankContactNumber1`, `BankRef2`, `BankBranch2`, `BankAccountNum2`, `BankContactNumber2`, `BankRef3`, `BankBranch3`, `BankAccountNum3`, `BankContactNumber3`, `BankRef4`, `BankBranch4`, `BankAccountNum4`, `BankContactNumber4`, `BankRef5`, `BankBranch5`, `BankAccountNum5`, `BankContactNumber5`, `CompanyOfficial_Name1`, `CompanyOfficial_Address1`, `CompanyOfficial_Number1`, `CompanyOfficial_Designation1`, `CompanyOfficial_Name2`, `CompanyOfficial_Address2`, `CompanyOfficial_Number2`, `CompanyOfficial_Designation2`, `CompanyOfficial_Name3`, `CompanyOfficial_Address3`, `CompanyOfficial_Number3`, `CompanyOfficial_Designation3`, `CreditUsed`, `AgentID`, `AnnualCommisionPercentage`) VALUES
	(3, 'CJ', '', '', 0, 0, 0, 0, '', '', '', '', '', '', '', '', NULL, '', '', '', '', '', '', NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 1, '123', '123123', '', 4, '111', '11', '11', NULL, '', '', NULL, NULL, '', '', '', NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 0, NULL, 0),
	(4, 'Herbert', 'test addres', '', 0, 0, 0, 0, NULL, '', '', '', '', '', '', '', NULL, '', '', '', '', '', '', NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 4, 'test branch', '123', '', 1, 'testing', '12344', '', NULL, '', '', NULL, NULL, '', '', '', NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 0, NULL, 0),
	(5, 'Bert', 'a', 'a', 10, 10, 120000, 7, 'manel', 'asdf', 'a', 'ssd', 'asdfsdf', '123', '1233344', '1235123', NULL, '123', '123', '123', '123', '213', '123', NULL, 'asdf', 'sdf', 'sf', 'sf', 'asdfsdf', 'sdf', 'sdf', 'sf', 'sdf', 'sf', 'sdfdf', 'sdf', 'sf', '123', 'dfsf', 'sdfd', 'sdf3df', '12355123', 'sdf', 'sfsdf', '24123123', 'sdfsdf', 'sdfsdf', '234', 'sdf', 'sd', '234234', 3, 'sd', '123', '123', 3, '33123fff', '12333', '2344', 4, '123123123asdfsadf', '123123', '111111111111', 4, '34543555aasdf', '12334555545', '35345', 1, 'asdff333', '123123', '3123', 'sfdf', 'sadfjalksdfj', '123', 'sdf', 'dfdf', 'sdf', '234234', 'sdfsdf', 'sdfsdf', 'sdf', '234', 'sdfsdfsdf', 0, NULL, 0);
/*!40000 ALTER TABLE `contacts` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.counter
CREATE TABLE IF NOT EXISTS `counter` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CustomerID` int(10) unsigned NOT NULL,
  `CounterDate` datetime NOT NULL,
  `CounterDueDate` datetime NOT NULL,
  `Amount` double NOT NULL DEFAULT '0',
  `Status` int(10) unsigned NOT NULL DEFAULT '0',
  `PrintStatus` int(10) unsigned NOT NULL DEFAULT '0',
  `Balance` double DEFAULT '0',
  `PaymentCash` double DEFAULT '0',
  `PaymentPDC` double DEFAULT '0',
  `PaymentWithHolding` double DEFAULT '0',
  `PaymentForDeposit` double DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_counter_contacts` (`CustomerID`),
  CONSTRAINT `FK_counter_contacts` FOREIGN KEY (`CustomerID`) REFERENCES `contacts` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.counter: ~0 rows (approximately)
DELETE FROM `counter`;
/*!40000 ALTER TABLE `counter` DISABLE KEYS */;
/*!40000 ALTER TABLE `counter` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.counterdetails
CREATE TABLE IF NOT EXISTS `counterdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CounterID` int(10) unsigned NOT NULL,
  `SalesInvoiceID` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_counterdetails_salesinvoice` (`SalesInvoiceID`),
  KEY `FK_counterdetails_counter` (`CounterID`),
  CONSTRAINT `FK_counterdetails_counter` FOREIGN KEY (`CounterID`) REFERENCES `counter` (`ID`),
  CONSTRAINT `FK_counterdetails_salesinvoice` FOREIGN KEY (`SalesInvoiceID`) REFERENCES `salesinvoice` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.counterdetails: ~0 rows (approximately)
DELETE FROM `counterdetails`;
/*!40000 ALTER TABLE `counterdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `counterdetails` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.customercommission
CREATE TABLE IF NOT EXISTS `customercommission` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CustomerID` int(10) unsigned NOT NULL,
  `InvoiceID` int(10) unsigned NOT NULL,
  `Amount` double NOT NULL,
  `Status` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_customercommission_salesinvoice` (`InvoiceID`),
  KEY `FK_customercommission_contacts` (`CustomerID`),
  CONSTRAINT `FK_customercommission_contacts` FOREIGN KEY (`CustomerID`) REFERENCES `contacts` (`ID`),
  CONSTRAINT `FK_customercommission_salesinvoice` FOREIGN KEY (`InvoiceID`) REFERENCES `salesinvoice` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.customercommission: ~0 rows (approximately)
DELETE FROM `customercommission`;
/*!40000 ALTER TABLE `customercommission` DISABLE KEYS */;
/*!40000 ALTER TABLE `customercommission` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.fabricateditem
CREATE TABLE IF NOT EXISTS `fabricateditem` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PO_ID` int(10) unsigned NOT NULL,
  `StockInID` int(10) unsigned DEFAULT NULL,
  `Name` varchar(45) NOT NULL,
  `Description` varchar(45) DEFAULT NULL,
  `QTY` int(10) unsigned NOT NULL,
  `UnitPrice` double NOT NULL,
  `Invoiced` tinyint(1) DEFAULT NULL,
  `Added` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.fabricateditem: ~0 rows (approximately)
DELETE FROM `fabricateditem`;
/*!40000 ALTER TABLE `fabricateditem` DISABLE KEYS */;
/*!40000 ALTER TABLE `fabricateditem` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.freight
CREATE TABLE IF NOT EXISTS `freight` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SI_Amount` double NOT NULL DEFAULT '0',
  `Total_Amount` double NOT NULL DEFAULT '0',
  `FreightPercentage` double NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.freight: ~0 rows (approximately)
DELETE FROM `freight`;
/*!40000 ALTER TABLE `freight` DISABLE KEYS */;
/*!40000 ALTER TABLE `freight` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.itemcategories
CREATE TABLE IF NOT EXISTS `itemcategories` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.itemcategories: ~2 rows (approximately)
DELETE FROM `itemcategories`;
/*!40000 ALTER TABLE `itemcategories` DISABLE KEYS */;
INSERT INTO `itemcategories` (`ID`, `Name`, `Description`) VALUES
	(1, 'Others', 'Others'),
	(3, 'Hardware', 'Hardware');
/*!40000 ALTER TABLE `itemcategories` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.items
CREATE TABLE IF NOT EXISTS `items` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ItemDate` datetime NOT NULL,
  `Name` varchar(45) NOT NULL,
  `Description` varchar(45) NOT NULL,
  `Code` varchar(45) DEFAULT NULL,
  `Price1` double NOT NULL DEFAULT '0',
  `Price2` double DEFAULT '0',
  `QTYOnHand1` int(10) unsigned DEFAULT '0',
  `QTYOnHand2` int(10) unsigned DEFAULT '0',
  `CategoryID` int(10) unsigned NOT NULL,
  `LowThreshold` int(10) unsigned DEFAULT '0',
  `ItemType` int(10) unsigned NOT NULL,
  `QTY2` int(10) unsigned DEFAULT '0',
  `IsWire` tinyint(1) DEFAULT '0',
  `wh_id` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.items: ~10 rows (approximately)
DELETE FROM `items`;
/*!40000 ALTER TABLE `items` DISABLE KEYS */;
INSERT INTO `items` (`ID`, `ItemDate`, `Name`, `Description`, `Code`, `Price1`, `Price2`, `QTYOnHand1`, `QTYOnHand2`, `CategoryID`, `LowThreshold`, `ItemType`, `QTY2`, `IsWire`, `wh_id`) VALUES
	(7, '2012-11-15 21:32:35', 'ttt', 'ttt', '', 20, 0, 0, 0, 1, 0, 0, 0, 0, 'WHC'),
	(8, '2012-11-15 21:33:01', 'xx', 'err', 'asdf', 30, 0, 0, 0, 1, 0, 0, 0, 0, 'WHC'),
	(9, '2012-11-18 12:56:58', 'aa', 'aa', '', 11, 0, 0, 0, 1, 0, 0, 0, 0, ''),
	(10, '2012-11-18 12:58:03', 'asdf', 'ddd', '', 20, 0, 0, 0, 1, 0, 0, 0, 0, ''),
	(11, '2012-11-18 13:01:29', 'asdfw', 'asdfwf', '', 1000, 0, 0, 0, 1, 200, 0, 0, 0, ''),
	(12, '2012-11-18 23:27:13', 'new item', 'asdf', '', 100, 0, 0, 0, 1, 20, 0, 0, 0, ''),
	(13, '2012-11-20 15:57:37', 'New item ', 'item 1', '', 20, 0, 0, 0, 1, 100, 0, 0, 0, ''),
	(14, '2012-11-20 15:57:37', 'Next item', 'item 2', '', 25, 0, 0, 0, 1, 10, 0, 0, 0, ''),
	(15, '2012-11-20 15:57:37', 'Old item', 'item 3', '', 10, 0, 0, 0, 1, 11, 0, 0, 0, ''),
	(16, '2012-11-20 15:57:37', 'Damaged item', 'item 4', '', 9, 0, 0, 0, 1, 3, 0, 0, 0, '');
/*!40000 ALTER TABLE `items` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.loaneditems
CREATE TABLE IF NOT EXISTS `loaneditems` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CustomerID` int(10) unsigned NOT NULL DEFAULT '0',
  `TransactionDate` datetime NOT NULL,
  `Terms` int(10) unsigned NOT NULL DEFAULT '0',
  `Notes` varchar(255) DEFAULT NULL,
  `AmountDue` double unsigned NOT NULL DEFAULT '0',
  `Canceled` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `Status` tinyint(2) unsigned NOT NULL DEFAULT '0',
  `UserID` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_LoanedItems_contacts` (`CustomerID`),
  KEY `FK_LoanedItems_users` (`UserID`),
  CONSTRAINT `FK_LoanedItems_contacts` FOREIGN KEY (`CustomerID`) REFERENCES `contacts` (`ID`),
  CONSTRAINT `FK_LoanedItems_users` FOREIGN KEY (`UserID`) REFERENCES `users` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.loaneditems: ~0 rows (approximately)
DELETE FROM `loaneditems`;
/*!40000 ALTER TABLE `loaneditems` DISABLE KEYS */;
/*!40000 ALTER TABLE `loaneditems` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.loaneditemsdetails
CREATE TABLE IF NOT EXISTS `loaneditemsdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `LoanedItemsID` int(10) unsigned NOT NULL,
  `ItemID` int(10) unsigned DEFAULT NULL,
  `FabID` int(10) unsigned DEFAULT NULL,
  `TradeID` int(10) unsigned DEFAULT NULL,
  `BundleID` int(10) unsigned DEFAULT NULL,
  `QTY1` int(10) unsigned NOT NULL DEFAULT '0',
  `QTY2` int(10) unsigned NOT NULL DEFAULT '0',
  `QTY_Returned` int(10) unsigned NOT NULL DEFAULT '0',
  `QTY_Invoiced` int(10) unsigned NOT NULL DEFAULT '0',
  `AgentPrice1` double NOT NULL,
  `AgentPrice2` double NOT NULL,
  `AgentDiscount` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_LoanedItemsDetails_loaneditems` (`LoanedItemsID`),
  KEY `FK_LoanedItemsDetails_items` (`ItemID`),
  KEY `FK_LoanedItemsDetails_bundleditem` (`BundleID`),
  KEY `FK_LoanedItemsDetails_fabricateditem` (`FabID`),
  KEY `FK_LoanedItemsDetails_tradingitem` (`TradeID`),
  CONSTRAINT `FK_LoanedItemsDetails_bundleditem` FOREIGN KEY (`BundleID`) REFERENCES `bundleditem` (`ID`),
  CONSTRAINT `FK_LoanedItemsDetails_fabricateditem` FOREIGN KEY (`FabID`) REFERENCES `fabricateditem` (`ID`),
  CONSTRAINT `FK_LoanedItemsDetails_items` FOREIGN KEY (`ItemID`) REFERENCES `items` (`ID`),
  CONSTRAINT `FK_LoanedItemsDetails_loaneditems` FOREIGN KEY (`LoanedItemsID`) REFERENCES `loaneditems` (`ID`),
  CONSTRAINT `FK_LoanedItemsDetails_tradingitem` FOREIGN KEY (`TradeID`) REFERENCES `tradingitem` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.loaneditemsdetails: ~0 rows (approximately)
DELETE FROM `loaneditemsdetails`;
/*!40000 ALTER TABLE `loaneditemsdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `loaneditemsdetails` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.loaneditemsdetails_stockin
CREATE TABLE IF NOT EXISTS `loaneditemsdetails_stockin` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `LoanedItemsDetailsID` int(10) unsigned NOT NULL,
  `StockInDetailsID` int(10) unsigned NOT NULL,
  `QTY1` int(10) unsigned NOT NULL,
  `QTY2` int(10) unsigned NOT NULL,
  `SellingDiscount1` varchar(50) DEFAULT NULL,
  `SellingDiscount2` varchar(50) DEFAULT NULL,
  `SellingPrice1` double NOT NULL,
  `SellingPrice2` double NOT NULL,
  `Roll_ID` int(11) DEFAULT NULL,
  `QTY_Returned` int(10) unsigned NOT NULL DEFAULT '0',
  `QTY_Invoiced` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_LoanedItemsDetails_StockIn_loaneditemsdetails` (`LoanedItemsDetailsID`),
  KEY `FK_LoanedItemsDetails_StockIn_stockindetails` (`StockInDetailsID`),
  CONSTRAINT `FK_LoanedItemsDetails_StockIn_loaneditemsdetails` FOREIGN KEY (`LoanedItemsDetailsID`) REFERENCES `loaneditemsdetails` (`ID`),
  CONSTRAINT `FK_LoanedItemsDetails_StockIn_stockindetails` FOREIGN KEY (`StockInDetailsID`) REFERENCES `stockindetails` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.loaneditemsdetails_stockin: ~0 rows (approximately)
DELETE FROM `loaneditemsdetails_stockin`;
/*!40000 ALTER TABLE `loaneditemsdetails_stockin` DISABLE KEYS */;
/*!40000 ALTER TABLE `loaneditemsdetails_stockin` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.payments
CREATE TABLE IF NOT EXISTS `payments` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CustomerID` int(10) unsigned NOT NULL,
  `InvoiceID` int(10) unsigned DEFAULT '0',
  `CounterID` double DEFAULT '0',
  `PaymentDate` datetime NOT NULL,
  `Amount` double NOT NULL,
  `AmountApplied` double NOT NULL,
  `PaymentType` int(10) unsigned NOT NULL,
  `AmountUsed` double NOT NULL,
  `Canceled` tinyint(1) DEFAULT '0',
  `PDC_ID` int(10) unsigned DEFAULT '0',
  `Reviewed` tinyint(1) DEFAULT '0',
  `UserID` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_payments_contacts` (`CustomerID`),
  CONSTRAINT `FK_payments_contacts` FOREIGN KEY (`CustomerID`) REFERENCES `contacts` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.payments: ~0 rows (approximately)
DELETE FROM `payments`;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.paymentsdetail
CREATE TABLE IF NOT EXISTS `paymentsdetail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PaymentID` int(10) unsigned NOT NULL,
  `InvoiceID` int(10) unsigned NOT NULL,
  `Amount` double NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_paymentsdetail_salesinvoice` (`InvoiceID`),
  KEY `FK_paymentsdetail_payments` (`PaymentID`),
  CONSTRAINT `FK_paymentsdetail_payments` FOREIGN KEY (`PaymentID`) REFERENCES `payments` (`ID`),
  CONSTRAINT `FK_paymentsdetail_salesinvoice` FOREIGN KEY (`InvoiceID`) REFERENCES `salesinvoice` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.paymentsdetail: ~0 rows (approximately)
DELETE FROM `paymentsdetail`;
/*!40000 ALTER TABLE `paymentsdetail` DISABLE KEYS */;
/*!40000 ALTER TABLE `paymentsdetail` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.paymentspdc
CREATE TABLE IF NOT EXISTS `paymentspdc` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `BankID` int(10) unsigned NOT NULL,
  `AccountNumber` varchar(45) NOT NULL,
  `CheckNumber` varchar(45) NOT NULL,
  `CheckDate` datetime NOT NULL,
  `Amount` double NOT NULL,
  `Status` int(10) unsigned NOT NULL DEFAULT '0',
  `PaymentID` int(10) unsigned NOT NULL,
  `ClearingDate` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_paymentspdc_payments` (`PaymentID`),
  KEY `FK_paymentspdc_banks` (`BankID`),
  CONSTRAINT `FK_paymentspdc_banks` FOREIGN KEY (`BankID`) REFERENCES `banks` (`ID`),
  CONSTRAINT `FK_paymentspdc_payments` FOREIGN KEY (`PaymentID`) REFERENCES `payments` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.paymentspdc: ~0 rows (approximately)
DELETE FROM `paymentspdc`;
/*!40000 ALTER TABLE `paymentspdc` DISABLE KEYS */;
/*!40000 ALTER TABLE `paymentspdc` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.purchaseorder
CREATE TABLE IF NOT EXISTS `purchaseorder` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SupplierID` int(10) unsigned NOT NULL DEFAULT '0',
  `GracePeriod` int(10) unsigned DEFAULT '0',
  `TransactionDate` datetime NOT NULL,
  `Status` int(10) unsigned DEFAULT NULL,
  `Notes` varchar(45) DEFAULT NULL,
  `AmountDue` double NOT NULL,
  `Fabricated` tinyint(1) DEFAULT '0',
  `Trading` tinyint(1) DEFAULT '0',
  `Excess` tinyint(1) DEFAULT '0',
  `UserID` int(10) unsigned DEFAULT '0',
  `Canceled` tinyint(1) DEFAULT '0',
  `wh_id` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_purchaseorder_contacts` (`SupplierID`),
  CONSTRAINT `FK_purchaseorder_contacts` FOREIGN KEY (`SupplierID`) REFERENCES `contacts` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.purchaseorder: ~0 rows (approximately)
DELETE FROM `purchaseorder`;
/*!40000 ALTER TABLE `purchaseorder` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchaseorder` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.purchaseorderdetails
CREATE TABLE IF NOT EXISTS `purchaseorderdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PO_ID` int(10) unsigned DEFAULT NULL,
  `ItemID` int(10) unsigned DEFAULT NULL,
  `FabID` int(10) unsigned DEFAULT NULL,
  `TradingID` int(10) unsigned DEFAULT NULL,
  `QTY1` int(10) unsigned DEFAULT NULL,
  `QTY2` int(10) unsigned DEFAULT NULL,
  `SellingPrice1` double DEFAULT NULL,
  `SellingPrice2` double DEFAULT NULL,
  `Discount` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `ItemIndex` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.purchaseorderdetails: ~0 rows (approximately)
DELETE FROM `purchaseorderdetails`;
/*!40000 ALTER TABLE `purchaseorderdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchaseorderdetails` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.purchaseorderdiscounts
CREATE TABLE IF NOT EXISTS `purchaseorderdiscounts` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SupplierID` int(10) unsigned NOT NULL,
  `ItemID` int(10) unsigned NOT NULL,
  `Discount` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.purchaseorderdiscounts: ~0 rows (approximately)
DELETE FROM `purchaseorderdiscounts`;
/*!40000 ALTER TABLE `purchaseorderdiscounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchaseorderdiscounts` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.quotation
CREATE TABLE IF NOT EXISTS `quotation` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CustomerID` int(10) unsigned NOT NULL,
  `QuotationDate` datetime NOT NULL,
  `Notes` varchar(100) NOT NULL,
  `AmountDue` double NOT NULL,
  `UserID` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_quotation_contacts` (`CustomerID`),
  CONSTRAINT `FK_quotation_contacts` FOREIGN KEY (`CustomerID`) REFERENCES `contacts` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.quotation: ~0 rows (approximately)
DELETE FROM `quotation`;
/*!40000 ALTER TABLE `quotation` DISABLE KEYS */;
/*!40000 ALTER TABLE `quotation` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.quotationdetails
CREATE TABLE IF NOT EXISTS `quotationdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `QuotationID` int(10) unsigned NOT NULL,
  `ItemID` int(10) unsigned DEFAULT '0',
  `FabID` int(10) unsigned DEFAULT '0',
  `TradeID` int(10) unsigned DEFAULT '0',
  `QTY1` int(10) unsigned DEFAULT '0',
  `QTY2` int(10) unsigned DEFAULT '0',
  `AgentDiscount` varchar(45) DEFAULT NULL,
  `AgentPrice1` double DEFAULT '0',
  `AgentPrice2` double DEFAULT '0',
  `CustomerDiscount` varchar(45) DEFAULT NULL,
  `CustomerPrice1` double DEFAULT '0',
  `CustomerPrice2` double DEFAULT '0',
  `BundleID` int(10) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.quotationdetails: ~0 rows (approximately)
DELETE FROM `quotationdetails`;
/*!40000 ALTER TABLE `quotationdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `quotationdetails` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.requestapproval
CREATE TABLE IF NOT EXISTS `requestapproval` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RequestDate` datetime NOT NULL,
  `Terminal` varchar(45) NOT NULL,
  `UserID` int(10) unsigned NOT NULL,
  `Message` varchar(200) NOT NULL,
  `RequestType` int(10) unsigned NOT NULL,
  `Status` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.requestapproval: ~0 rows (approximately)
DELETE FROM `requestapproval`;
/*!40000 ALTER TABLE `requestapproval` DISABLE KEYS */;
/*!40000 ALTER TABLE `requestapproval` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.returneditems
CREATE TABLE IF NOT EXISTS `returneditems` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `InvoiceID` int(10) unsigned NOT NULL,
  `TransactionDate` datetime NOT NULL,
  `Notes` varchar(100) DEFAULT NULL,
  `Amount` double NOT NULL,
  `EnteredBy` int(10) unsigned NOT NULL,
  `Canceled` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_returneditems_salesinvoice` (`InvoiceID`),
  CONSTRAINT `FK_returneditems_salesinvoice` FOREIGN KEY (`InvoiceID`) REFERENCES `salesinvoice` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.returneditems: ~0 rows (approximately)
DELETE FROM `returneditems`;
/*!40000 ALTER TABLE `returneditems` DISABLE KEYS */;
/*!40000 ALTER TABLE `returneditems` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.returneditemsdetails
CREATE TABLE IF NOT EXISTS `returneditemsdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ParentID` int(10) unsigned NOT NULL,
  `QTY1` int(10) unsigned DEFAULT '0',
  `QTY2` int(10) unsigned DEFAULT '0',
  `SalesInvoiceDetailsID` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.returneditemsdetails: ~0 rows (approximately)
DELETE FROM `returneditemsdetails`;
/*!40000 ALTER TABLE `returneditemsdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `returneditemsdetails` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.returneditemsdetails_stockin
CREATE TABLE IF NOT EXISTS `returneditemsdetails_stockin` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `DetailsID` int(10) unsigned NOT NULL,
  `SID_ID` int(10) unsigned NOT NULL,
  `QTY1` int(10) unsigned DEFAULT NULL,
  `QTY2` int(10) unsigned DEFAULT NULL,
  `Roll_ID` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.returneditemsdetails_stockin: ~0 rows (approximately)
DELETE FROM `returneditemsdetails_stockin`;
/*!40000 ALTER TABLE `returneditemsdetails_stockin` DISABLE KEYS */;
/*!40000 ALTER TABLE `returneditemsdetails_stockin` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.salesinvoice
CREATE TABLE IF NOT EXISTS `salesinvoice` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `InvoiceType` int(10) unsigned NOT NULL,
  `ReceiptNumber` varchar(45) DEFAULT NULL,
  `PO_Number` varchar(45) DEFAULT NULL,
  `CustomerID` int(10) unsigned NOT NULL,
  `InvoiceDate` datetime NOT NULL,
  `PaymentType` int(10) unsigned NOT NULL,
  `Terms` int(10) unsigned DEFAULT NULL,
  `Notes` varchar(100) DEFAULT NULL,
  `AmountDue` double NOT NULL,
  `PaymentCash` double DEFAULT '0',
  `PaymentPDC` double DEFAULT '0',
  `CounterID` int(10) unsigned DEFAULT NULL,
  `LoanedItemID` int(10) unsigned DEFAULT '0',
  `Printed` tinyint(1) DEFAULT NULL,
  `Deleted` tinyint(1) DEFAULT NULL,
  `BadDebt` tinyint(1) DEFAULT NULL,
  `Withheld` tinyint(1) DEFAULT NULL,
  `UserID` int(10) unsigned DEFAULT NULL,
  `PaymentStatus` int(10) unsigned DEFAULT '0',
  `PaymentForDeposit` double DEFAULT '0',
  `WithholdingAmount` double DEFAULT '0',
  `PaymentWithholding` double DEFAULT '0',
  `AmountReturned` double DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_salesinvoice_contacts` (`CustomerID`),
  CONSTRAINT `FK_salesinvoice_contacts` FOREIGN KEY (`CustomerID`) REFERENCES `contacts` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.salesinvoice: ~0 rows (approximately)
DELETE FROM `salesinvoice`;
/*!40000 ALTER TABLE `salesinvoice` DISABLE KEYS */;
/*!40000 ALTER TABLE `salesinvoice` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.salesinvoicedetails
CREATE TABLE IF NOT EXISTS `salesinvoicedetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SalesInvoiceID` int(10) unsigned NOT NULL,
  `ItemID` int(10) unsigned DEFAULT NULL,
  `TradeID` int(10) unsigned DEFAULT NULL,
  `FabID` int(10) unsigned DEFAULT NULL,
  `BundleID` int(10) unsigned DEFAULT NULL,
  `QTY1` int(10) unsigned DEFAULT NULL,
  `QTY2` int(10) unsigned DEFAULT NULL,
  `AgentDiscount` varchar(45) DEFAULT NULL,
  `AgentPrice1` double DEFAULT NULL,
  `AgentPrice2` double DEFAULT NULL,
  `CustomerDiscount` varchar(45) DEFAULT NULL,
  `CustomerPrice1` double DEFAULT NULL,
  `CustomerPrice2` double DEFAULT NULL,
  `QTY_Returned` int(10) DEFAULT NULL,
  `LoanedItemDetailsID` int(10) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_salesinvoicedetails_items` (`ItemID`),
  KEY `FK_salesinvoicedetails_tradingitem` (`TradeID`),
  KEY `FK_salesinvoicedetails_fabricateditem` (`FabID`),
  KEY `FK_salesinvoicedetails_bundleditem` (`BundleID`),
  CONSTRAINT `FK_salesinvoicedetails_bundleditem` FOREIGN KEY (`BundleID`) REFERENCES `bundleditem` (`ID`),
  CONSTRAINT `FK_salesinvoicedetails_fabricateditem` FOREIGN KEY (`FabID`) REFERENCES `fabricateditem` (`ID`),
  CONSTRAINT `FK_salesinvoicedetails_items` FOREIGN KEY (`ItemID`) REFERENCES `items` (`ID`),
  CONSTRAINT `FK_salesinvoicedetails_tradingitem` FOREIGN KEY (`TradeID`) REFERENCES `tradingitem` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.salesinvoicedetails: ~0 rows (approximately)
DELETE FROM `salesinvoicedetails`;
/*!40000 ALTER TABLE `salesinvoicedetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `salesinvoicedetails` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.salesinvoicedetails_stockin
CREATE TABLE IF NOT EXISTS `salesinvoicedetails_stockin` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SIV_DetailsID` int(10) unsigned NOT NULL,
  `StockInDetailsID` int(10) unsigned NOT NULL,
  `SellingDiscount1` varchar(45) DEFAULT NULL,
  `SellingDiscount2` varchar(45) DEFAULT NULL,
  `SellingPrice1` double DEFAULT '0',
  `SellingPrice2` double DEFAULT '0',
  `QTY1` int(10) unsigned DEFAULT '0',
  `QTY2` int(10) unsigned DEFAULT '0',
  `Roll_ID` int(10) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_salesinvoicedetails_stockin_salesinvoicedetails` (`SIV_DetailsID`),
  KEY `FK_salesinvoicedetails_stockin_stockindetails` (`StockInDetailsID`),
  CONSTRAINT `FK_salesinvoicedetails_stockin_salesinvoicedetails` FOREIGN KEY (`SIV_DetailsID`) REFERENCES `salesinvoicedetails` (`ID`),
  CONSTRAINT `FK_salesinvoicedetails_stockin_stockindetails` FOREIGN KEY (`StockInDetailsID`) REFERENCES `stockindetails` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.salesinvoicedetails_stockin: ~0 rows (approximately)
DELETE FROM `salesinvoicedetails_stockin`;
/*!40000 ALTER TABLE `salesinvoicedetails_stockin` DISABLE KEYS */;
/*!40000 ALTER TABLE `salesinvoicedetails_stockin` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.settings
CREATE TABLE IF NOT EXISTS `settings` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL DEFAULT '0',
  `Value` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.settings: ~0 rows (approximately)
DELETE FROM `settings`;
/*!40000 ALTER TABLE `settings` DISABLE KEYS */;
/*!40000 ALTER TABLE `settings` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.shipping
CREATE TABLE IF NOT EXISTS `shipping` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CompanyName` varchar(100) NOT NULL,
  `Contact1` varchar(100) DEFAULT NULL,
  `Contact2` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.shipping: ~2 rows (approximately)
DELETE FROM `shipping`;
/*!40000 ALTER TABLE `shipping` DISABLE KEYS */;
INSERT INTO `shipping` (`ID`, `CompanyName`, `Contact1`, `Contact2`) VALUES
	(4, 'Manels', '123', ''),
	(6, 'Kevins', '', '');
/*!40000 ALTER TABLE `shipping` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.soc_payments
CREATE TABLE IF NOT EXISTS `soc_payments` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SOC_ID` int(10) unsigned NOT NULL,
  `Chequenumber` varchar(100) DEFAULT NULL,
  `Amount` double NOT NULL,
  `Payment_Date` datetime NOT NULL,
  `ctr` int(10) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_soc_payments_statementofaccount` (`SOC_ID`),
  CONSTRAINT `FK_soc_payments_statementofaccount` FOREIGN KEY (`SOC_ID`) REFERENCES `statementofaccount` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.soc_payments: ~25 rows (approximately)
DELETE FROM `soc_payments`;
/*!40000 ALTER TABLE `soc_payments` DISABLE KEYS */;
/*!40000 ALTER TABLE `soc_payments` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.statementofaccount
CREATE TABLE IF NOT EXISTS `statementofaccount` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SupplierID` int(10) unsigned NOT NULL DEFAULT '0',
  `EstimatedArrival` datetime NOT NULL,
  `TransactionDate` datetime NOT NULL,
  `Shipping` varchar(100) NOT NULL,
  `ShipName` varchar(100) DEFAULT NULL,
  `VoyageNumber` varchar(100) NOT NULL,
  `BillofLeading` varchar(100) NOT NULL,
  `Payment` int(1) DEFAULT '1',
  `PayDate` datetime DEFAULT NULL,
  `ChequeNumber` varchar(100) DEFAULT NULL,
  `ShippingStatus` int(1) DEFAULT '0',
  `Handling` int(1) DEFAULT '0',
  `Notes` varchar(45) DEFAULT NULL,
  `AmountDue` double NOT NULL,
  `UserID` int(10) unsigned DEFAULT '0',
  `Canceled` tinyint(1) DEFAULT '0',
  `wh_id` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_statementofaccount_contacts` (`SupplierID`),
  CONSTRAINT `FK_statementofaccount_contacts` FOREIGN KEY (`SupplierID`) REFERENCES `contacts` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.statementofaccount: ~15 rows (approximately)
DELETE FROM `statementofaccount`;
/*!40000 ALTER TABLE `statementofaccount` DISABLE KEYS */;
/*!40000 ALTER TABLE `statementofaccount` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.statementofaccountdetails
CREATE TABLE IF NOT EXISTS `statementofaccountdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SOC_ID` int(10) unsigned DEFAULT NULL,
  `VanNumber` varchar(20) NOT NULL,
  `VanTracker` int(10) unsigned DEFAULT '0',
  `WhDestination` varchar(50) DEFAULT NULL,
  `CustomerDestination` int(10) unsigned DEFAULT '0',
  `ItemID` int(10) unsigned DEFAULT NULL,
  `QTY` int(10) unsigned DEFAULT NULL,
  `SellingPrice` double DEFAULT NULL,
  `Status` int(1) DEFAULT '0',
  `ItemIndex` int(10) DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.statementofaccountdetails: ~33 rows (approximately)
DELETE FROM `statementofaccountdetails`;
/*!40000 ALTER TABLE `statementofaccountdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `statementofaccountdetails` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.stockin
CREATE TABLE IF NOT EXISTS `stockin` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PO_ID` int(10) unsigned DEFAULT NULL,
  `SOC_ID` int(10) unsigned DEFAULT NULL,
  `InvoiceNo` varchar(30) DEFAULT NULL,
  `DeliveryReceipt` varchar(30) DEFAULT NULL,
  `Shipper` varchar(50) DEFAULT NULL,
  `WaybillNo` varchar(30) DEFAULT NULL,
  `PackingListNo` varchar(30) DEFAULT NULL,
  `InvoiceDate` datetime DEFAULT NULL,
  `ShippingDate` datetime DEFAULT NULL,
  `ArrivalDate` datetime DEFAULT NULL,
  `DueDate` datetime DEFAULT NULL,
  `StockInDate` datetime NOT NULL,
  `Status` int(10) unsigned NOT NULL DEFAULT '0',
  `Notes` varchar(100) DEFAULT NULL,
  `FreightID` int(10) unsigned DEFAULT '0',
  `AmountDue` double NOT NULL,
  `AmountPaid` double NOT NULL,
  `DueDays` int(10) unsigned DEFAULT '0',
  `Canceled` tinyint(1) DEFAULT '0',
  `UserID` int(10) unsigned NOT NULL,
  `Paid` tinyint(1) unsigned DEFAULT '0',
  `wh_id` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_stockin_purchaseorder` (`PO_ID`),
  KEY `FK_stockin_statementofaccount` (`SOC_ID`),
  CONSTRAINT `FK_stockin_purchaseorder` FOREIGN KEY (`PO_ID`) REFERENCES `purchaseorder` (`ID`),
  CONSTRAINT `FK_stockin_statementofaccount` FOREIGN KEY (`SOC_ID`) REFERENCES `statementofaccount` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.stockin: ~3 rows (approximately)
DELETE FROM `stockin`;
/*!40000 ALTER TABLE `stockin` DISABLE KEYS */;
/*!40000 ALTER TABLE `stockin` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.stockindetails
CREATE TABLE IF NOT EXISTS `stockindetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `StockInID` int(10) unsigned NOT NULL,
  `ItemIndex` int(10) unsigned NOT NULL,
  `ItemID` int(10) unsigned DEFAULT NULL,
  `FabID` int(10) unsigned DEFAULT NULL,
  `TradeID` int(10) unsigned DEFAULT NULL,
  `WarehouseStockin` varchar(50) DEFAULT NULL,
  `QTY1` int(10) unsigned NOT NULL,
  `QTY2` int(10) unsigned DEFAULT NULL,
  `QTY_OnHand1` int(10) unsigned NOT NULL DEFAULT '0',
  `QTY_OnHand2` int(10) unsigned NOT NULL DEFAULT '0',
  `QTY_OnHandWire` varchar(255) NOT NULL,
  `QTY_BadOrder` int(11) DEFAULT '0',
  `Price1` double DEFAULT '0',
  `Price2` double DEFAULT '0',
  `SellingPrice1` double DEFAULT '0',
  `SellingPrice2` double DEFAULT '0',
  `Status` int(10) unsigned DEFAULT '0',
  `Freight` double DEFAULT '0',
  `Discount` varchar(45) DEFAULT NULL,
  `SellingDiscount1` varchar(45) DEFAULT NULL,
  `SellingDiscount2` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.stockindetails: ~5 rows (approximately)
DELETE FROM `stockindetails`;
/*!40000 ALTER TABLE `stockindetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `stockindetails` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.tradingitem
CREATE TABLE IF NOT EXISTS `tradingitem` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PO_ID` int(10) unsigned NOT NULL,
  `StockInID` int(10) unsigned DEFAULT NULL,
  `Name` varchar(45) NOT NULL,
  `Description` varchar(45) DEFAULT NULL,
  `QTY` int(10) unsigned NOT NULL,
  `UnitPrice` double NOT NULL,
  `Invoiced` tinyint(1) DEFAULT NULL,
  `Added` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.tradingitem: ~0 rows (approximately)
DELETE FROM `tradingitem`;
/*!40000 ALTER TABLE `tradingitem` DISABLE KEYS */;
/*!40000 ALTER TABLE `tradingitem` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.userpermissions
CREATE TABLE IF NOT EXISTS `userpermissions` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ContactsAdd` int(10) unsigned DEFAULT '0',
  `ContactsEdit` int(10) unsigned DEFAULT '0',
  `ContactsDelete` int(10) unsigned DEFAULT '0',
  `ContactsViewSuppliersManila` int(10) unsigned DEFAULT '0',
  `PO_Add` int(10) unsigned DEFAULT '0',
  `PO_Edit` int(10) unsigned DEFAULT '0',
  `PO_Delete` int(10) unsigned DEFAULT '0',
  `PO_ViewSuppliersManila` int(10) unsigned DEFAULT '0',
  `PO_ChangeStatus` int(10) unsigned DEFAULT '0',
  `SI_Add` int(10) unsigned DEFAULT '0',
  `SI_Edit` int(10) unsigned DEFAULT '0',
  `SI_Delete` int(10) unsigned DEFAULT '0',
  `SI_AddSuppliersManila` int(10) unsigned DEFAULT '0',
  `SI_ViewSuppliersManila` int(10) unsigned DEFAULT '0',
  `SI_Freight` int(10) unsigned DEFAULT '0',
  `Item_Add` int(10) unsigned DEFAULT '0',
  `Item_Edit` int(10) unsigned DEFAULT '0',
  `Item_Delete` int(10) unsigned DEFAULT '0',
  `SIV_Add` int(10) unsigned DEFAULT '0',
  `SIV_Edit` int(10) unsigned DEFAULT '0',
  `SIV_Delete` int(10) unsigned DEFAULT '0',
  `Voucher_Add` int(10) unsigned DEFAULT '0',
  `Voucher_Edit` int(10) unsigned DEFAULT '0',
  `Voucher_Delete` int(10) unsigned DEFAULT '0',
  `Counter_Add` int(10) unsigned DEFAULT '0',
  `Counter_Edit` int(10) unsigned DEFAULT '0',
  `Counter_Delete` int(10) unsigned DEFAULT '0',
  `Counter_SetPaid` int(10) unsigned DEFAULT '0',
  `Counter_PaymentAdd` int(10) unsigned DEFAULT '0',
  `Counter_PaymentDelete` int(10) unsigned DEFAULT '0',
  `LoanedItems_Add` int(10) unsigned DEFAULT '0',
  `LoanedItems_Edit` int(10) unsigned DEFAULT '0',
  `LoanedItems_Delete` int(10) unsigned DEFAULT '0',
  `Quotation_Add` int(10) unsigned DEFAULT '0',
  `Quotation_Edit` int(10) unsigned DEFAULT '0',
  `Quotation_Delete` int(10) unsigned DEFAULT '0',
  `View_Contacts` int(10) unsigned DEFAULT '0',
  `View_PO` int(10) unsigned DEFAULT '0',
  `View_StockIn` int(10) unsigned DEFAULT '0',
  `View_BO` int(10) unsigned DEFAULT '0',
  `View_ReturnedItems` int(10) unsigned DEFAULT '0',
  `View_Vouchers` int(10) unsigned DEFAULT '0',
  `View_Inventory` int(10) unsigned DEFAULT '0',
  `View_SalesInvoice` int(10) unsigned DEFAULT '0',
  `View_Checks` int(10) unsigned DEFAULT '0',
  `View_Payments` int(10) unsigned DEFAULT '0',
  `View_Agents` int(10) unsigned DEFAULT '0',
  `View_DailySummaryReport` int(10) unsigned DEFAULT '0',
  `View_CustomerAccounting` int(10) unsigned DEFAULT '0',
  `View_CustomerCommission` int(10) unsigned DEFAULT '0',
  `PO_AddSuppliersManila` int(10) unsigned DEFAULT '0',
  `UserID` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.userpermissions: ~6 rows (approximately)
DELETE FROM `userpermissions`;
/*!40000 ALTER TABLE `userpermissions` DISABLE KEYS */;
INSERT INTO `userpermissions` (`ID`, `ContactsAdd`, `ContactsEdit`, `ContactsDelete`, `ContactsViewSuppliersManila`, `PO_Add`, `PO_Edit`, `PO_Delete`, `PO_ViewSuppliersManila`, `PO_ChangeStatus`, `SI_Add`, `SI_Edit`, `SI_Delete`, `SI_AddSuppliersManila`, `SI_ViewSuppliersManila`, `SI_Freight`, `Item_Add`, `Item_Edit`, `Item_Delete`, `SIV_Add`, `SIV_Edit`, `SIV_Delete`, `Voucher_Add`, `Voucher_Edit`, `Voucher_Delete`, `Counter_Add`, `Counter_Edit`, `Counter_Delete`, `Counter_SetPaid`, `Counter_PaymentAdd`, `Counter_PaymentDelete`, `LoanedItems_Add`, `LoanedItems_Edit`, `LoanedItems_Delete`, `Quotation_Add`, `Quotation_Edit`, `Quotation_Delete`, `View_Contacts`, `View_PO`, `View_StockIn`, `View_BO`, `View_ReturnedItems`, `View_Vouchers`, `View_Inventory`, `View_SalesInvoice`, `View_Checks`, `View_Payments`, `View_Agents`, `View_DailySummaryReport`, `View_CustomerAccounting`, `View_CustomerCommission`, `PO_AddSuppliersManila`, `UserID`) VALUES
	(2, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 10),
	(3, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 9),
	(4, 0, 2, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 3),
	(5, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
	(6, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 2),
	(7, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 4);
/*!40000 ALTER TABLE `userpermissions` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.users
CREATE TABLE IF NOT EXISTS `users` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserName` varchar(45) NOT NULL,
  `UserPassword` varchar(255) NOT NULL,
  `UserType` int(10) unsigned NOT NULL,
  `IP_Address` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.users: ~1 rows (approximately)
DELETE FROM `users`;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`ID`, `UserName`, `UserPassword`, `UserType`, `IP_Address`) VALUES
	(1, 'Admin', '098041032145010129162170023221186002198155094148', 1, NULL);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.vantrackers
CREATE TABLE IF NOT EXISTS `vantrackers` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `VanName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.vantrackers: ~5 rows (approximately)
DELETE FROM `vantrackers`;
/*!40000 ALTER TABLE `vantrackers` DISABLE KEYS */;
INSERT INTO `vantrackers` (`ID`, `VanName`) VALUES
	(1, 'VAN A'),
	(2, 'VAN B'),
	(3, 'VAN C'),
	(4, 'VAN D'),
	(5, 'VAN E');
/*!40000 ALTER TABLE `vantrackers` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.voucher
CREATE TABLE IF NOT EXISTS `voucher` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SupplierID` int(10) unsigned NOT NULL DEFAULT '0',
  `VoucherDate` datetime NOT NULL,
  `Amount` double NOT NULL DEFAULT '0',
  `AmountBO` double NOT NULL DEFAULT '0',
  `BadOrderID` int(10) unsigned DEFAULT NULL,
  `Cancelled` tinyint(1) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_Vouchers_contacts` (`SupplierID`),
  CONSTRAINT `FK_Vouchers_contacts` FOREIGN KEY (`SupplierID`) REFERENCES `contacts` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.voucher: ~0 rows (approximately)
DELETE FROM `voucher`;
/*!40000 ALTER TABLE `voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `voucher` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.voucherdetails
CREATE TABLE IF NOT EXISTS `voucherdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `StockinID` int(10) unsigned NOT NULL DEFAULT '0',
  `VoucherID` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK__stockin` (`StockinID`),
  KEY `FK__voucher` (`VoucherID`),
  CONSTRAINT `FK__stockin` FOREIGN KEY (`StockinID`) REFERENCES `stockin` (`ID`),
  CONSTRAINT `FK__voucher` FOREIGN KEY (`VoucherID`) REFERENCES `voucher` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.voucherdetails: ~0 rows (approximately)
DELETE FROM `voucherdetails`;
/*!40000 ALTER TABLE `voucherdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `voucherdetails` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.voucherpayment
CREATE TABLE IF NOT EXISTS `voucherpayment` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `BankID` int(10) unsigned DEFAULT '0',
  `VoucherID` int(10) unsigned NOT NULL DEFAULT '0',
  `AccountNumber` varchar(30) DEFAULT NULL,
  `CheckNumber` varchar(30) DEFAULT NULL,
  `Amount` double unsigned NOT NULL,
  `CheckDate` datetime NOT NULL,
  `ClearingDate` datetime NOT NULL,
  `Status` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_VoucherPayment_banks` (`BankID`),
  KEY `FK_VoucherPayment_voucher` (`VoucherID`),
  CONSTRAINT `FK_VoucherPayment_banks` FOREIGN KEY (`BankID`) REFERENCES `banks` (`ID`),
  CONSTRAINT `FK_VoucherPayment_voucher` FOREIGN KEY (`VoucherID`) REFERENCES `voucher` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.voucherpayment: ~0 rows (approximately)
DELETE FROM `voucherpayment`;
/*!40000 ALTER TABLE `voucherpayment` DISABLE KEYS */;
/*!40000 ALTER TABLE `voucherpayment` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.warehouse
CREATE TABLE IF NOT EXISTS `warehouse` (
  `ID` varchar(50) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Phone` varchar(255) DEFAULT NULL,
  `Fax` varchar(255) DEFAULT NULL,
  `isDefault` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.warehouse: ~2 rows (approximately)
DELETE FROM `warehouse`;
/*!40000 ALTER TABLE `warehouse` DISABLE KEYS */;
INSERT INTO `warehouse` (`ID`, `Name`, `Address`, `Phone`, `Fax`, `isDefault`) VALUES
	('WHB1', 'Warebouse B Branch 1', 'Cebu City', '', '', 1),
	('WHB2', 'Warehouse A ', '', '', '', 0);
/*!40000 ALTER TABLE `warehouse` ENABLE KEYS */;


-- Dumping structure for table engeline_luckyent.wirebreakdown
CREATE TABLE IF NOT EXISTS `wirebreakdown` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `StockInDetails_ID` int(10) unsigned NOT NULL DEFAULT '0',
  `QTY_OnHand` int(10) unsigned NOT NULL,
  `QTY_Original` int(10) unsigned NOT NULL,
  `BreakDownID` int(10) unsigned NOT NULL DEFAULT '0',
  `BreakDownID_Source` int(10) DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table engeline_luckyent.wirebreakdown: ~0 rows (approximately)
DELETE FROM `wirebreakdown`;
/*!40000 ALTER TABLE `wirebreakdown` DISABLE KEYS */;
/*!40000 ALTER TABLE `wirebreakdown` ENABLE KEYS */;
/*!40014 SET FOREIGN_KEY_CHECKS=1 */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
