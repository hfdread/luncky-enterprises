using System;
using System.Collections.Generic;


namespace MyHibernate.BusinessObjects
{
    public partial class StatementofAccount
    {
        public virtual Int32 ID { get; set; }
        public virtual Contacts Supplier { get; set; }
        public virtual DateTime EstimatedArrival { get; set; }
        public virtual DateTime TransactionDate { get; set; }
        public virtual Shipping ShippingCompany { get; set; }
        public virtual string ShipName { get; set; }
        public virtual string VoyageNumber { get; set; }
        public virtual string BillofLeading { get; set; }
        public virtual Int32 Payment { get; set; }
        public virtual DateTime PayDate { get; set; }
        public virtual string ChequeNumber { get; set; }
        public virtual Int32 ShippingStatus { get; set; }
        public virtual string Notes { get; set; }
        public virtual Double AmountDue { get; set; }
        public virtual Double AmountDueOverride { get; set; }
        public virtual Users user { get; set; }
        public virtual bool Canceled { get; set; }
        public virtual string wh_id { get; set; }
        public virtual Int32 Handling { get; set; }
        public virtual IList<StatementofAccountDetails> details { get; set; }


        public StatementofAccount()
        {
            details = new List<StatementofAccountDetails>();
        }

        public enum ePayment
        {
            PAID = 0,
            UNPAID,
            PPAID
        }

        public enum eHandling
        {
            PREPAID=0,
            COLLECT
        }
        public enum eShipStatus
        {
            ARRIVED = 0,
            SHUTOUT,
            CANCELLED,
            SOME_CANCELLED,
            SOME_SHUTOUT,
            SOME_ARRIVE
        }

        public int GetShipStatus(string ShipStatus)
        { 
            switch(ShipStatus.ToLower())
            {
                case "arrived":
                    return (int)eShipStatus.ARRIVED;
                case "shutout":
                    return (int)eShipStatus.SHUTOUT;
                case "cancelled":
                    return (int)eShipStatus.CANCELLED;
                //case "some cancelled":
                //    return (int)eShipStatus.SOME_CANCELLED;
                //case "some shutout":
                //    return (int)eShipStatus.SOME_SHUTOUT;
                //case "some arrived":
                //    return (int)eShipStatus.SOME_ARRIVE;
                default:
                    if (ShipStatus.Contains("-C") || ShipStatus.Contains("C-"))
                        return (int)eShipStatus.SOME_CANCELLED;
                    else if (ShipStatus.Contains("-S") || ShipStatus.Contains("S-"))
                        return (int)eShipStatus.SOME_SHUTOUT;
                    else if (ShipStatus.Contains("-A") || ShipStatus.Contains("A-"))
                        return (int)eShipStatus.SOME_ARRIVE;
                    else
                        return -1;
            }
        }

        public int GetPaymentType(string PayType)
        {
            switch (PayType.ToLower())
            {
                case "paid":
                    return (int)ePayment.PAID;
                case "unpaid":
                    return (int)ePayment.UNPAID;
                case "ppaid":
                    return (int)ePayment.PPAID;
                default:
                    return -1;
            }
        }

        public int GetHandling(string handling)
        {
            switch (handling.ToLower())
            {
                case "prepaid":
                    return (int)eHandling.PREPAID;
                case "collect":
                    return (int)eHandling.COLLECT;
                default:
                    return -1;
            }
        }
       
    }
}
