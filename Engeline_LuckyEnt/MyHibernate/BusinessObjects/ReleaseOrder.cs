using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
    public partial class ReleaseOrder
    {
        public virtual Int32 ID { get; set; }
        public virtual string DR_Number { get; set; }
        public virtual DateTime Trx_Date { get; set; }
        public virtual string Driver { get; set; }
        public virtual string Truck { get; set; }
        public virtual string Notes { get; set; }
        public virtual string Warehouse { get; set; }

        //unmapped
        public virtual List<Items> item { get; set; }
    }
}
