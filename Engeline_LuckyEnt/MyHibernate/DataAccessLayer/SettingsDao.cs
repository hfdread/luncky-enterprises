using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyHibernate.BusinessObjects;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class SettingsDao : GenericDao<Settings>
    {
        public Settings GetSetting(String name)
        {
            using (ISession session = getSession())
            {
                String SQL = String.Format("from Settings s where s.Name='{0}'", name);
                return session.CreateQuery(SQL).UniqueResult<Settings>();
            }
        }

        public int SetSetting(string name, string value)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        //check if setting already exists
                        string SQL = string.Format("from Settings s where s.Name='{0}'", name);
                        Settings s = session.CreateQuery(SQL).UniqueResult<Settings>();
                        if (s == null)
                        {
                            s = new Settings();
                        }
                        s.Name = name;
                        s.Value = value;
                        //save new setting
                        session.SaveOrUpdate("Settings", s);

                        transaction.Commit();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        SetErrorMessage(ex);
                        return -1;
                    }
                }
            }
        }
    }
}
