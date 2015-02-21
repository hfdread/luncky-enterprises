using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class ContactsDao : GenericDao<Contacts>
    {
        public IList<Contacts> getAllCustomers()
        {
            using (ISession session = getSession())
            {
                string Types = string.Format("{0},{1},{2},{3},{4}", (int)Contacts.eContactType.Customers,
                                             (int)Contacts.eContactType.CustomersCompany,
                                             (int)Contacts.eContactType.CustomersContractor,
                                             (int)Contacts.eContactType.CustomersDealer,
                                             (int)Contacts.eContactType.CustomersPersonal);
                string SQL = string.Format("from Contacts as c left join fetch c.BankRef1 left join fetch c.BankRef2 left join fetch c.BankRef3 where c.ContactType IN ({0})", Types);
                return session.CreateQuery(SQL).List<Contacts>();
            }
        }

        public IList<Contacts> getAllCustomersNoAgent()
        {
            using (ISession session = getSession())
            {
                string Types = string.Format("{0},{1},{2},{3},{4}", (int)Contacts.eContactType.Customers,
                                             (int)Contacts.eContactType.CustomersCompany,
                                             (int)Contacts.eContactType.CustomersContractor,
                                             (int)Contacts.eContactType.CustomersDealer,
                                             (int)Contacts.eContactType.CustomersPersonal);
                string SQL =
                   string.Format("from Contacts as c where c.ContactType IN ({0}) and (c.Agent.ID=0 or c.Agent is null)",
                                 Types);
                return session.CreateQuery(SQL).List<Contacts>();
            }
        }

        public IList<Contacts> getAllCustomersByAgent(Int32 AgentID)
        {
            using (ISession session = getSession())
            {
                string Types = string.Format("{0},{1},{2},{3},{4}", (int)Contacts.eContactType.Customers,
                                             (int)Contacts.eContactType.CustomersCompany,
                                             (int)Contacts.eContactType.CustomersContractor,
                                             (int)Contacts.eContactType.CustomersDealer,
                                             (int)Contacts.eContactType.CustomersPersonal);
                string SQL = string.Format("from Contacts as c where c.ContactType IN ({0}) and c.Agent.ID={1}", Types,
                                           AgentID);
                return session.CreateQuery(SQL).List<Contacts>();
            }
        }

        public IList<Contacts> getAllSuppliers(bool bExcludeManila)
        {
            using (ISession session = getSession())
            {
                string SQL;
                if (bExcludeManila)
                    SQL = string.Format("from Contacts as c where c.ContactType in ({0},{1})",
                                        (Int32)Contacts.eContactType.Suppliers, (Int32)Contacts.eContactType.SuppliersCebu);
                else
                    SQL = string.Format("from Contacts as c where c.ContactType in ({0},{1},{2})",
                                        (Int32)Contacts.eContactType.Suppliers, (Int32)Contacts.eContactType.SuppliersCebu,
                                        (Int32)Contacts.eContactType.SuppliersManila);
                return session.CreateQuery(SQL).List<Contacts>();
            }
        }

        public IList<Contacts> getAllAgents()
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from Contacts as c where c.ContactType in ({0},{1})",
                                           (Int32)Contacts.eContactType.AgentFreelance,
                                           (Int32)Contacts.eContactType.AgentInHouse);
                return session.CreateQuery(SQL).List<Contacts>();
            }
        }

        public IList<Contacts> getAllRecords(bool bExcludeManila)
        {
            using (ISession session = getSession())
            {
                if (bExcludeManila)
                {
                    return
                       session.CreateQuery("from Contacts as c where c.ContactType!=" +
                                           (int)Contacts.eContactType.SuppliersManila).List<Contacts>();
                }
                else
                {
                    return session.CreateQuery("from Contacts").List<Contacts>();
                }
            }
        }
    }
}