using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class PaymentsPDC
   {
      public virtual Int32 ID { get; set; }
      public virtual Payments payment { get; set; }
      public virtual Banks bank { get; set; }
      public virtual string AccountNumber { get; set; }
      public virtual string CheckNumber { get; set; }
      public virtual double Amount { get; set; }
      public virtual DateTime CheckDate { get; set; }
      public virtual DateTime ClearingDate { get; set; }
      public virtual eStatus Status { get; set; }

      public enum eStatus
      {
         ForDeposit = 0,
         Good,
         Bounced,
         Returned
      }

      public static string GetStatus(Int32 status)
      {
         switch ((eStatus) status)
         {
            case eStatus.ForDeposit:
               return "For Deposit";
            case eStatus.Good:
               return "Good";
            case eStatus.Bounced:
               return "Bounced";
            case eStatus.Returned:
               return "Returned";
            default:
               return "";
         }
      }

      public static Int32 GetStatus(string status)
      {
         switch (status.ToLower())
         {
            case "for deposit":
               return (Int32) eStatus.ForDeposit;
            case "good":
               return (Int32) eStatus.Good;
            case "bounced":
               return (Int32) eStatus.Bounced;
            case "returned":
               return (Int32) eStatus.Returned;
            default:
               return -1;
         }
      }

      public static DateTime GetClearingDate(DateTime date)
      {
         switch (date.DayOfWeek)
         {
            case DayOfWeek.Monday:
            case DayOfWeek.Tuesday:
            case DayOfWeek.Wednesday:
               return date.AddDays(2);
            case DayOfWeek.Thursday:
            case DayOfWeek.Friday:
               return date.AddDays(4);
            case DayOfWeek.Saturday:
            case DayOfWeek.Sunday:
               return date.AddDays(3);
            default:
               return date.AddDays(2);
         }
      }
   }
}