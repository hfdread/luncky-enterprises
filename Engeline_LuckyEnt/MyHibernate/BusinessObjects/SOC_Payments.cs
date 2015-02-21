using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHibernate.BusinessObjects
{
    public partial class SOC_Payments
    {
        public virtual Int32 ID { get; set; }
        public virtual StatementofAccount statementofaccount { get; set; }
        public virtual String Chequenumber { get; set; }
        public virtual DateTime Issue_Date { get; set; }
        public virtual DateTime Due_Date { get; set; }
        public virtual String Bank { get; set; }
        public virtual double Amount { get; set; }
        public virtual DateTime Payment_Date { get; set; }
        public virtual Int32 ctr { get; set; }
    }
}
