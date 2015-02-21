-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.5.28 - MySQL Community Server (GPL)
-- Server OS:                    Win32
-- HeidiSQL version:             7.0.0.4053
-- Date/time:                    2012-11-23 17:39:51
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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.agentquotaexemptitem
CREATE TABLE IF NOT EXISTS `agentquotaexemptitem` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ItemDetailsID` int(10) unsigned NOT NULL,
  `ItemID` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.agentquotafixsalesdetails
CREATE TABLE IF NOT EXISTS `agentquotafixsalesdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Quota` double NOT NULL,
  `Commission` double NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.agentquotaitemdetails
CREATE TABLE IF NOT EXISTS `agentquotaitemdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `QuotaID` int(10) unsigned NOT NULL,
  `ItemName` varchar(50) NOT NULL,
  `LimitValue` double NOT NULL DEFAULT '0',
  `PercentCommission` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.banks
CREATE TABLE IF NOT EXISTS `banks` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `ShortDescription` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.bundleditem
CREATE TABLE IF NOT EXISTS `bundleditem` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Description` varchar(100) NOT NULL,
  `UnitPrice` double NOT NULL,
  `ComputedPrice` double NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.freight
CREATE TABLE IF NOT EXISTS `freight` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SI_Amount` double NOT NULL DEFAULT '0',
  `Total_Amount` double NOT NULL DEFAULT '0',
  `FreightPercentage` double NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.itemcategories
CREATE TABLE IF NOT EXISTS `itemcategories` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.purchaseorderdiscounts
CREATE TABLE IF NOT EXISTS `purchaseorderdiscounts` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SupplierID` int(10) unsigned NOT NULL,
  `ItemID` int(10) unsigned NOT NULL,
  `Discount` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.returneditemsdetails
CREATE TABLE IF NOT EXISTS `returneditemsdetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ParentID` int(10) unsigned NOT NULL,
  `QTY1` int(10) unsigned DEFAULT '0',
  `QTY2` int(10) unsigned DEFAULT '0',
  `SalesInvoiceDetailsID` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.settings
CREATE TABLE IF NOT EXISTS `settings` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL DEFAULT '0',
  `Value` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.shipping
CREATE TABLE IF NOT EXISTS `shipping` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CompanyName` varchar(100) NOT NULL,
  `Contact1` varchar(100) DEFAULT NULL,
  `Contact2` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.stockin
CREATE TABLE IF NOT EXISTS `stockin` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PO_ID` int(10) unsigned NOT NULL,
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
  CONSTRAINT `FK_stockin_purchaseorder` FOREIGN KEY (`PO_ID`) REFERENCES `purchaseorder` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.stockindetails
CREATE TABLE IF NOT EXISTS `stockindetails` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `StockInID` int(10) unsigned NOT NULL,
  `ItemIndex` int(10) unsigned NOT NULL,
  `ItemID` int(10) unsigned DEFAULT NULL,
  `FabID` int(10) unsigned DEFAULT NULL,
  `TradeID` int(10) unsigned DEFAULT NULL,
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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.users
CREATE TABLE IF NOT EXISTS `users` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserName` varchar(45) NOT NULL,
  `UserPassword` varchar(255) NOT NULL,
  `UserType` int(10) unsigned NOT NULL,
  `IP_Address` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.vantrackers
CREATE TABLE IF NOT EXISTS `vantrackers` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `VanName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


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

-- Data exporting was unselected.


-- Dumping structure for table engeline_luckyent.warehouse
CREATE TABLE IF NOT EXISTS `warehouse` (
  `ID` varchar(50) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Phone` varchar(255) DEFAULT NULL,
  `Fax` varchar(255) DEFAULT NULL,
  `isDefault` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


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

-- Data exporting was unselected.
/*!40014 SET FOREIGN_KEY_CHECKS=1 */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
