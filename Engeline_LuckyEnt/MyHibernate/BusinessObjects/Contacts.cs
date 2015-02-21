using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
    public partial class Contacts
    {
        //contact info
        public virtual Int32 ID { get; set; }

        public virtual string CompanyName { get; set; }
        public virtual string CompanyAddress { get; set; }
        public virtual string CompanyContactNumber { get; set; }
        public virtual Contacts Agent { get; set; }
        public virtual double AnnualCommisionPercentage { get; set; }

        //[Credit Info]
        public virtual Int32 Terms { get; set; }
        public virtual Int32 Terms_PDC { get; set; }
        public virtual double CreditLimit { get; set; }
        public virtual double CreditUsed { get; set; }

        //[Personal Information]
        public virtual Int32 ContactType { get; set; }
        public virtual string SalesRepresentative { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Address { get; set; }
        public virtual string MobileNumber { get; set; }
        public virtual string LandlineNumber { get; set; }
        public virtual string FaxNumber { get; set; }
        public virtual string Description { get; set; }

        //Company Data
        public virtual string Comp_TIN { get; set; }
        public virtual string Comp_BIR_Acc_No { get; set; }
        public virtual string Comp_SEC_Acc_No1 { get; set; }
        public virtual string Comp_SEC_Acc_No2 { get; set; }
        public virtual string Comp_C13 { get; set; }
        public virtual string Comp_Non_Vat_Reg { get; set; }
        public virtual string Comp_Vat_Reg { get; set; }

        //Contact Persons
        public virtual string Comp_Contact_Person_Accounting { get; set; }
        public virtual string Comp_Contact_Number_Accounting { get; set; }
        public virtual string Comp_Contact_Person_Purchasing { get; set; }
        public virtual string Comp_Contact_Number_Purchasing { get; set; }
        public virtual string Comp_Contact_Person_HeadOffice { get; set; }
        public virtual string Comp_Contact_Number_HeadOffice { get; set; }

        //Present Suppliers / Business References
        public virtual string BusinessRef_Name1 { get; set; }
        public virtual string BusinessRef_Address1 { get; set; }
        public virtual string BusinessRef_ContactPerson1 { get; set; }
        public virtual string BusinessRef_Number1 { get; set; }
        public virtual string BusinessRef_Name2 { get; set; }
        public virtual string BusinessRef_Address2 { get; set; }
        public virtual string BusinessRef_ContactPerson2 { get; set; }
        public virtual string BusinessRef_Number2 { get; set; }
        public virtual string BusinessRef_Name3 { get; set; }
        public virtual string BusinessRef_Address3 { get; set; }
        public virtual string BusinessRef_ContactPerson3 { get; set; }
        public virtual string BusinessRef_Number3 { get; set; }

        //Principal Stock Holders / Incorporators
        public virtual string StockHolderName1 { get; set; }
        public virtual string StockHolderAddress1 { get; set; }
        public virtual string StockHolderNumber1 { get; set; }

        public virtual string StockHolderName2 { get; set; }
        public virtual string StockHolderAddress2 { get; set; }
        public virtual string StockHolderNumber2 { get; set; }

        public virtual string StockHolderName3 { get; set; }
        public virtual string StockHolderAddress3 { get; set; }
        public virtual string StockHolderNumber3 { get; set; }

        //Bank Reference
        public virtual Banks BankRef1 { get; set; }
        public virtual string BankBranch1 { get; set; }
        public virtual string BankAccountNum1 { get; set; }
        public virtual string BankContactNumber1 { get; set; }

        public virtual Banks BankRef2 { get; set; }
        public virtual string BankBranch2 { get; set; }
        public virtual string BankAccountNum2 { get; set; }
        public virtual string BankContactNumber2 { get; set; }

        public virtual Banks BankRef3 { get; set; }
        public virtual string BankBranch3 { get; set; }
        public virtual string BankAccountNum3 { get; set; }
        public virtual string BankContactNumber3 { get; set; }

        public virtual Banks BankRef4 { get; set; }
        public virtual string BankBranch4 { get; set; }
        public virtual string BankAccountNum4 { get; set; }
        public virtual string BankContactNumber4 { get; set; }

        public virtual Banks BankRef5 { get; set; }
        public virtual string BankBranch5 { get; set; }
        public virtual string BankAccountNum5 { get; set; }
        public virtual string BankContactNumber5 { get; set; }

        //Company Officials
        public virtual string CompanyOfficial_Name1 { get; set; }
        public virtual string CompanyOfficial_Address1 { get; set; }
        public virtual string CompanyOfficial_Number1 { get; set; }
        public virtual string CompanyOfficial_Designation1 { get; set; }
        public virtual string CompanyOfficial_Name2 { get; set; }
        public virtual string CompanyOfficial_Address2 { get; set; }
        public virtual string CompanyOfficial_Number2 { get; set; }
        public virtual string CompanyOfficial_Designation2 { get; set; }
        public virtual string CompanyOfficial_Name3 { get; set; }
        public virtual string CompanyOfficial_Address3 { get; set; }
        public virtual string CompanyOfficial_Number3 { get; set; }
        public virtual string CompanyOfficial_Designation3 { get; set; }

        public static List<String> GetContactTypes()
        {
            List<String> lst = new List<string>();
            lst.Add("Suppliers");
            lst.Add("Suppliers - Cebu");
            lst.Add("Suppliers - Manila");
            lst.Add("Customers");
            lst.Add("Customers - Dealer");
            lst.Add("Customers - Company");
            lst.Add("Customers - Personal");
            lst.Add("Customers - Contractor");
            lst.Add("Agent - In-House");
            lst.Add("Agent - Freelance");

            return lst;
        }

        public enum eContactType
        {
            Suppliers = 0,
            SuppliersCebu,
            SuppliersManila,
            Customers,
            CustomersDealer,
            CustomersCompany,
            CustomersPersonal,
            CustomersContractor,
            AgentInHouse,
            AgentFreelance
        }

        public static string GetContactType(eContactType eType)
        {
            switch (eType)
            {
                case eContactType.Suppliers:
                    return "Suppliers";
                case eContactType.SuppliersCebu:
                    return "Suppliers - Cebu";
                case eContactType.SuppliersManila:
                    return "Suppliers - Manila";
                case eContactType.Customers:
                    return "Customers";
                case eContactType.CustomersCompany:
                    return "Customers - Company";
                case eContactType.CustomersContractor:
                    return "Customers - Contractor";
                case eContactType.CustomersDealer:
                    return "Customers - Dealer";
                case eContactType.CustomersPersonal:
                    return "Customers - Personal";
                case eContactType.AgentFreelance:
                    return "Agent - Freelance";
                case eContactType.AgentInHouse:
                    return "Agent - In-House";
                default:
                    return "";
            }
        }

        public static Int32 GetContactType(string sType)
        {
            switch (sType)
            {
                case "Agent - Freelance":
                    return (int)eContactType.AgentFreelance;
                case "Agent - In-House":
                    return (int)eContactType.AgentInHouse;
                case "Customers":
                    return (int)eContactType.Customers;
                case "Customers - Company":
                    return (int)eContactType.CustomersCompany;
                case "Customers - Contractor":
                    return (int)eContactType.CustomersContractor;
                case "Customers - Dealer":
                    return (int)eContactType.CustomersDealer;
                case "Customers - Personal":
                    return (int)eContactType.CustomersPersonal;
                case "Suppliers":
                    return (int)eContactType.Suppliers;
                case "Suppliers - Cebu":
                    return (int)eContactType.SuppliersCebu;
                case "Suppliers - Manila":
                    return (int)eContactType.SuppliersManila;
                default:
                    return -1;
            }
        }

        public override string ToString()
        {
            if (CompanyName != "")
            {
                return CompanyName;
            }
            else
            {
                return string.Format("{0}, {1}", LastName, FirstName);
            }
        }
    }
}