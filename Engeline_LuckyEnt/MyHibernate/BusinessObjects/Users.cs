using System;
using NHibernate;

namespace MyHibernate.BusinessObjects
{
   public partial class Users
   {
      public virtual Int32 ID { get; set; }
      public virtual string UserName { get; set; }
      public virtual string UserPassword { get; set; }
      public virtual eUserType UserType { get; set; }
      public virtual string IP_Address { get; set; }

      public enum eUserType
      {
         Admin = 1,
         Sales,
         Accounting,
         Encoder
      }

      public string GetUserTypeString(Int32 iType)
      {
         switch (iType)
         {
            case (int) eUserType.Admin:
               return "Admin";
            case (int) eUserType.Accounting:
               return "Accounting";
            case (int) eUserType.Encoder:
               return "Encoder";
            case (int) eUserType.Sales:
               return "Sales";
            default:
               return "";
         }
      }

      public Int32 GetUserTypeInt(string sUserType)
      {
         switch (sUserType.ToLower())
         {
            case "admin":
               return (int) eUserType.Admin;
            case "accounting":
               return (int) eUserType.Accounting;
            case "encoder":
               return (int) eUserType.Encoder;
            case "sales":
               return (int) eUserType.Sales;
            default:
               return 0;
         }
      }
   }
}