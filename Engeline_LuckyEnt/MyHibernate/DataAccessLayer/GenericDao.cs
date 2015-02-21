using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace MyHibernate.DataAccessLayer
{
    public class GenericDao<T>
    {
        //private ISession ISession { get; set; }
        public const string FMT_MYSQL_DATE = "yyyy-MM-dd HH-mm-ss";
        public const string FMT_MYSQL_DATE_START = "yyyy-MM-dd 00:00:00";
        public const string FMT_MYSQL_DATE_END = "yyyy-MM-dd 23:59:59";
        public string ErrorMessage = "";

        public GenericDao()
        {
            ISession session = Factories.MyORM.GetCurrentSession();
            if (!Factories.MyORM.IsInitialized()) ErrorMessage = Factories.MyORM.LastErrorMessage();
        }

        public bool IsInitialized()
        {
            return Factories.MyORM.IsInitialized();
        }

        public ISession getSession()
        {
            return Factories.MyORM.GetCurrentSession();
        }

        public virtual T GetById(int id)
        {
            using (ISession session = getSession())
            {
                return (T)session.Get(typeof(T), id);
            }
        }

        public IList<T> GetByIdList(int id)
        {
            ICriteria targetObjects = getSession().CreateCriteria(typeof(T))
               .Add(Restrictions.Eq("ID", id));
            IList<T> itemList = targetObjects.List<T>();
            getSession().Close();
            return itemList;
        }

        public virtual T GetByName(string fld, string value)
        {
            using (ISession session = getSession())
            {
                T obj = session
                   .CreateCriteria(typeof(T))
                   .Add(Restrictions.Eq(fld, value))
                   .UniqueResult<T>();
                return obj;
            }
        }

        public virtual T GetByName(string fld, object value)
        {
            using (ISession session = getSession())
            {
                T obj = session
                   .CreateCriteria(typeof(T))
                   .Add(Restrictions.Eq(fld, value))
                   .UniqueResult<T>();
                return obj;
            }
        }

        public virtual IList<T> GetAllRecordsByField(string fld, Int32 value)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from {0} as t where t.{1}={2}", typeof(T).Name, fld, value);
                return session.CreateQuery(SQL).List<T>();
            }
        }

        public virtual IList<T> GetAllRecordsByField(string fld, string value, bool bExactMatch)
        {
            using (ISession session = getSession())
            {
                string SQL = "";
                if (bExactMatch)
                    SQL = string.Format("from {0} as t where t.{1}={2}", typeof(T).Name, fld, value);
                else
                    SQL = string.Format("from {0} as t where t.{1} like '%{2}%'", typeof(T).Name, fld, value);

                return session.CreateQuery(SQL).List<T>();
            }
        }

        public virtual IList<T> GetAllRecordsByField(string fld, object value)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from {0} as t where t.{1}={2}", typeof(T).Name, fld, value.ToString());
                return session.CreateQuery(SQL).List<T>();
            }
        }

        public virtual bool isEntityExist(string Name, string Field)
        {
            bool bRet;
            ISession session = getSession();
            {
                ICriteria targetObjects = session.CreateCriteria(typeof(T))
                   .Add(Restrictions.Like(Field, string.Format("%{0}%", Name)));
                IList<T> itemList = targetObjects.List<T>();
                if (itemList.Count != 0)
                {
                    bRet = true;
                }
                else
                {
                    bRet = false;
                }
            }
            return bRet;
        }

        public virtual IList<T> getAllRecords()
        {
            ICriteria targetObjects = getSession().CreateCriteria(typeof(T));
            IList<T> itemList = targetObjects.List<T>();
            return itemList;
        }

        public virtual void Save(T item)
        {
            using (ISession session = getSession())
            {
                using (session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(item);
                        session.Transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        session.Transaction.Rollback();
                        SetErrorMessage(ex);
                        throw;
                    }
                }
            }
        }

        public virtual void SetErrorMessage(Exception ex)
        {
            if (ex.InnerException == null) ErrorMessage = ex.Message;
            else
            {
                ErrorMessage = string.Format("{0}\n\nInnerException:\n{1}", ex.Message, ex.InnerException.ToString());
            }
        }

        public virtual void Delete(T item)
        {
            using (ISession session = getSession())
            {
                using (session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(item);
                        session.Transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        session.Transaction.Rollback();
                        SetErrorMessage(ex);
                        throw;
                    }
                }
            }
        }

        public virtual IList<T> GetAllRecordsByDateRange(string DateField, DateTime start, DateTime end)
        {
            string datestart = start.ToString("yyyy-MM-dd 00:00:00");
            string dateend = end.ToString("yyyy-MM-dd 23:59:59");

            using (ISession session = getSession())
            {
                string SQL = string.Format("from {0} as tbl where tbl.{1} BETWEEN '{2}' AND '{3}'", typeof(T), DateField,
                                           datestart, dateend);
                return session.CreateQuery(SQL).List<T>();
            }
        }

        public int GetRecordCount(T item)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("select count(*) from {0}", typeof(T));
                return session.CreateSQLQuery(SQL).UniqueResult<int>();
            }
        }

        public int GetRecordCount(T item, ISession session)
        {
            string SQL = string.Format("select count(*) from {0}", typeof(T));
            return session.CreateSQLQuery(SQL).UniqueResult<int>();
        }
    }
}