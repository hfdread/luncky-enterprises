using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHibernate.BusinessObjects
{
    public partial class DamagedMissing
    {
        public virtual Int32 ID { get; set; }
        public virtual StockIn stockin { get; set; }
        public virtual Items item { get; set; }
        public virtual Int32 Original_Qty { get; set; }
        public virtual Int32 Damage_Qty { get; set; }
        public virtual Int32 Missing_Qty { get; set; }
        public virtual DateTime TrxDate { get; set; }
        public virtual bool ReStock { get; set; }
        public virtual Int32 NewStockinID { get; set; }
        public virtual string Warehouse { get; set; }
        public virtual double SellingPrice { get; set; }

        //not mapped
        public virtual Int32 SalvageQuantity { get; set; }
    }
}
