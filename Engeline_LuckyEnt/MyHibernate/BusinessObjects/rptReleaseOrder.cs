using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
    public partial class rptReleaseOrder
    {
        public virtual string WHName { get; set; }
        public virtual string itemName { get; set; }
        public virtual int QTY { get; set; }
        public virtual string Unit { get; set; }
        public virtual string DR { get; set; }
    }
}
