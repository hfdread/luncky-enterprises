using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
    public partial class Vantrackers
    {
        public virtual Int32 ID { get; set; }
        public virtual string VanName { get; set; }

        public override string ToString()
        {
            return VanName;
        }
    }
}
