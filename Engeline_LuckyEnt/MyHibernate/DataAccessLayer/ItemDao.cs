using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class ItemDao : GenericDao<Items>
    {
        public override void Delete(Items item)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        //check if item is used in other transactions
                        string SQL = "";
                        PurchaseOrderDetailsDao daoPO = new PurchaseOrderDetailsDao();
                        PurchaseOrderDetails pod;
                        SQL = string.Format("select count(pod.ID) from PurchaseOrderDetails as pod where pod.item is not NULL and pod.item.ID={0}", item.ID);
                        object count = session.CreateQuery(SQL).UniqueResult<object>();

                        if (Convert.ToInt32(count) > 0)
                            throw new Exception("Item is used in other transactions!");

                        session.Delete(item);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }

                }
            }
        }

        public IList<Items> getAllByCondition(string sCondition)
        {
            using (ISession session = getSession())
            {
                return session.CreateQuery("from Items as I where " + sCondition).List<Items>();
            }
        }

        public IList<object> GetItemsForInvoice()
        {
            using (ISession session = getSession())
            {
                IList<Object> lst =
                   session.CreateQuery("from Items as I inner join StockInDetails as sid on I.ID = sid.item.ID").List
                      <Object>();
                return lst;
            }
        }

        public IList<Items> getAllRecords(bool ExcludeWires)
        {
            using (ISession session = getSession())
            {
                if (ExcludeWires)
                {
                    return session.CreateQuery("from Items as I where I.IsWire=false").List<Items>();
                }
                else
                {
                    return session.CreateQuery("from Items as I").List<Items>();
                }
            }
        }

        public IList<Items> getAllItems()
        {
            using (ISession session = getSession())
            {
                return session.CreateQuery("from Items as I order by I.Name").List<Items>();
            }
        }
    }
}