using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHibernate.BusinessObjects
{
    public partial class Shipping
    {
        public virtual Int32 ID { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string Contact1 { get; set; }
        public virtual string Contact2 { get; set; }

        public override string ToString()
        {
            return CompanyName;
        }
    }
}
