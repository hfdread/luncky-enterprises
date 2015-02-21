using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class CompanyProfileDao : GenericDao<CompanyProfile>
    {
        public CompanyProfile GetCompanyProfile()
        {
            using (ISession session = getSession())
            {
                IList<CompanyProfile> lst = getAllRecords();
                if (lst != null && lst.Count > 0)
                {
                    return lst[0];
                }
                else
                    return null;
            }
        }
    }
}