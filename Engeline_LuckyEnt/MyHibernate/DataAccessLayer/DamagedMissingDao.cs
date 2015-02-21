using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class DamagedMissingDao : GenericDao<DamagedMissing>
    {
        public IList<DamagedMissing> GetMissingDamageByStockinID(Int32 StockinID)
        {
            using (ISession session = getSession())
            {
                string SQL =string.Format("from DamagedMissing dm where dm.stockin.ID={0}", StockinID);
                return session.CreateQuery(SQL).List<DamagedMissing>();
            }
        }

        public IList<DamagedMissing> GetAllRecordsByCriteria(StockIn SI, Items I, string Type, DateTime dateFrom, DateTime dateTo)
        {
            using (ISession session = getSession())
            {
                string SQL = "";
                SQL = string.Format("from DamagedMissing dm where dm.TrxDate between '{0}' and '{1}'", dateFrom.ToString(FMT_MYSQL_DATE_START), dateTo.ToString(FMT_MYSQL_DATE_END));

                if (SI != null)
                    SQL += string.Format(" and dm.stockin.ID={0}", SI.ID);
                if (I != null)
                    SQL += string.Format(" and dm.item.ID={0}", I.ID);
                if(Type.ToLower() == "damaged")
                    SQL += " and dm.Damage_Qty > 0";
                if (Type.ToLower() == "missing")
                    SQL += " and dm.Missing_Qty > 0";

                return session.CreateQuery(SQL).List<DamagedMissing>();
            }
        }
    }
}
