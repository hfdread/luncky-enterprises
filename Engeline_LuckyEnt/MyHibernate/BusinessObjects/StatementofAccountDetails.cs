using System;
using NHibernate;

namespace MyHibernate.BusinessObjects
{
    public partial class StatementofAccountDetails
    {
        public virtual Int32 ID { get; set; }
        public virtual StatementofAccount statementofaccount { get; set; }
        public virtual string VanNumber { get; set; }
        public virtual Vantrackers VanTracker { get; set; }
        public virtual Warehouse WhDestination { get; set; }
        public virtual Contacts CustomerDestination { get; set; }
        public virtual Items item { get; set; }
        public virtual Int32 QTY { get; set; }
        public virtual double SellingPrice { get; set; }
        public virtual Int32 Status { get; set; }
        public virtual Int32 ItemIndex { get; set; }


        public enum eStatus
        {
            CANCELLED =0,
            ARRIVED,
            SHUTOUT
        }

        public int GetStatus(string status)
        {
            switch (status.ToLower())
            {
                case "cancelled":
                    return (int)eStatus.CANCELLED;
                case "arrived":
                    return (int)eStatus.ARRIVED;
                case "shutout":
                    return (int)eStatus.SHUTOUT;
                default:
                    return -1;
            }
        }
    }
}
