using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class StockInDetailsDao : GenericDao<StockInDetails>
    {
        public IList<StockInDetails> GetNoPriceItems(StockIn SI)
        {
            using (ISession session = getSession())
            {
                string SQL = "";

                if (SI == null)
                {
                    SQL =
                       @"from StockInDetails as sid where sid.stockin.Canceled=false and 
                            (sid.SellingPrice1=0 and sid.SellingDiscount1='')";
                }
                else
                {
                    SQL =
                       @"from StockInDetails as sid where sid.stockin.Canceled=false and 
                            (sid.SellingPrice1=0 and sid.SellingDiscount1='') and sid.stockin.ID=" +
                       SI.ID;
                }
                return session.CreateQuery(SQL).List<StockInDetails>();
            }
        }

        public void SaveBatch(IList<StockInDetails> lst)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (StockInDetails sid in lst)
                        {
                            session.SaveOrUpdate("StockInDetails", sid);
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        if (!transaction.WasRolledBack)
                            transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void LockItem(StockInDetails sid, int bSet)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    if (sid.Status != bSet)
                    {
                        try
                        {
                            sid.Status = bSet;
                            session.SaveOrUpdate("StockInDetails", sid);
                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
        }

        public void LockItem(IList<StockInDetails> lst_sid, int bSet)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (StockInDetails sid in lst_sid)
                        {
                            if (sid.Status != bSet)
                            {
                                sid.Status = bSet;
                                session.SaveOrUpdate("StockInDetails", sid);
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        if (!transaction.WasRolledBack)
                            transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public IList<StockInDetails> GetAvailableStocks(string condition, Warehouse fromWH)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from StockInDetails as sid where sid.stockin.Canceled=False and sid.QTY_OnHand1>0 and sid.WarehouseStockin='{0}'",
                        fromWH.ID);
                if (condition != "")
                {
                    SQL += string.Format(" and ({0})", condition);
                   
                }

                SQL += string.Format(" order by sid.item.Name,sid.stockin.StockInDate");
                return session.CreateQuery(SQL).List<StockInDetails>();
            }
        }

        public IList<StockInDetails> GetAvailableStocks(string condition, bool NormalItem, bool FabItem, bool TradeItem, bool bExludeNoStockItems = false)
        {
            using (ISession session = getSession())
            {
                string SQL = "";
                if (condition != "")
                {
                    if (NormalItem)
                    {
                        SQL = string.Format("from StockInDetails as sid where sid.stockin.Canceled=False and sid.QTY_OnHand1>0 and ({0})", condition);
                        if (bExludeNoStockItems)
                        {
                            SQL += string.Format(" and sid.item.QTYOnHand1>0");
                        }
                        SQL += "  order by sid.item.Name,sid.stockin.StockInDate";
                    }
                    else if (FabItem)
                        SQL =
                           string.Format(
                              "from StockInDetails as sid where sid.stockin.Canceled=False and sid.QTY_OnHand1>0 and {0} order by sid.fabricateditem.Name,sid.stockin.StockInDate",
                              condition);
                    else if (TradeItem)
                        SQL =
                           string.Format(
                              "from StockInDetails as sid where sid.stockin.Canceled=False and sid.QTY_OnHand1>0 and {0} order by sid.tradingitem.Name,sid.stockin.StockInDate",
                              condition);
                }
                else
                {
                    if (NormalItem)
                    {
                        SQL = string.Format("from StockInDetails as sid where sid.stockin.Canceled=False and sid.QTY_OnHand1>0 ", condition);
                        if (bExludeNoStockItems)
                        {
                            SQL += string.Format(" and sid.item.QTYOnHand1>0");
                        }
                        SQL += "  order by sid.item.Name,sid.stockin.StockInDate";
                    }
                    else if (FabItem)
                        SQL =
                           string.Format(
                              "from StockInDetails as sid where sid.stockin.Canceled=False and (sid.QTY_OnHand1>0 or sid.QTY_OnHand2>0) order by sid.fabricateditem.Name,sid.stockin.StockInDate",
                              condition);
                    else if (TradeItem)
                        SQL =
                           string.Format(
                              "from StockInDetails as sid where sid.stockin.Canceled=False and (sid.QTY_OnHand1>0 or sid.QTY_OnHand2>0) order by sid.tradingitem.Name,sid.stockin.StockInDate",
                              condition);
                }
                return session.CreateQuery(SQL).List<StockInDetails>();
            }
        }

        public IList<StockInDetails> GetAvailableStocks(Int32 ID, bool NormalItem, bool FabItem, bool TradeItem)
        {
            using (ISession session = getSession())
            {
                string SQL = "";
                if (NormalItem)
                    SQL =
                       string.Format(
                          "from StockInDetails as sid where sid.stockin.Canceled=False and (sid.QTY_OnHand1>0 or sid.QTY_OnHand2>0) and sid.item.ID={0} order by sid.item.Name,sid.stockin.StockInDate",
                          ID);
                else if (FabItem)
                    SQL =
                       string.Format(
                          "from StockInDetails as sid where sid.stockin.Canceled=False and (sid.QTY_OnHand1>0 or sid.QTY_OnHand2>0) and sid.fabricateditem ={0} order by sid.fabricateditem.Name,sid.stockin.StockInDate",
                          ID);
                else if (TradeItem)
                    SQL =
                       string.Format(
                          "from StockInDetails as sid where sid.stockin.Canceled=False and (sid.QTY_OnHand1>0 or sid.QTY_OnHand2>0) and sid.tradingitem.ID={0} order by sid.tradingitem.Name,sid.stockin.StockInDate",
                          ID);

                return session.CreateQuery(SQL).List<StockInDetails>();
            }
        }

        public Int32 GetNextWireBreakdownID(Int32 StockInDetailsID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("select MAX(wb.BreakDownID) from WireBreakdown wb where wb.SID.ID={0}", StockInDetailsID);
                object result = session.CreateQuery(SQL).UniqueResult();
                if (result != null)
                {
                    try
                    {
                        return Convert.ToInt32(result.ToString()) + 1;
                    }
                    catch
                    {
                        return 1;
                    }
                }
                else
                    return 1;
            }
        }

        public Int32 GetNextWireBreakdownID(Int32 StockInDetailsID, ISession session)
        {
            string SQL = string.Format("select MAX(wb.BreakDownID) from WireBreakdown wb where wb.SID.ID={0}", StockInDetailsID);
            object result = session.CreateQuery(SQL).UniqueResult();
            if (result != null)
            {
                try
                {
                    return Convert.ToInt32(result.ToString()) + 1;
                }
                catch
                {
                    return 1;
                }
            }
            else
                return 1;
        }

        public StockInDetails GetItemByIndex(StockIn si, Int32 itemIndex)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from StockInDetails sid where sid.stockin.ID={0} and sid.ItemIndex={1}",si.ID, itemIndex);
                return session.CreateQuery(SQL).UniqueResult<StockInDetails>();
            }
        }
    }
}