using System;
using MyHibernate.BusinessObjects;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
   public class UsersDao : GenericDao<Users>
   {
      public override void Save(Users user)
      {
         using (ISession session = getSession())
         {
            using (ITransaction transaction = session.BeginTransaction())
            {
               try
               {
                  session.SaveOrUpdate(user);

                  //save permissions
                  UserPermissions P =
                     session.CreateQuery("from UserPermissions as UP where UP.user.ID=" + user.ID).UniqueResult
                        <UserPermissions>();

                  if (P == null)
                  {
                     //no permissions yet, save default permissions
                     P = new UserPermissions();
                     P.user = user;
                     SetPermissions(P);
                     session.Save("UserPermissions", P);
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

      private void SetPermissions(UserPermissions P)
      {
         switch (P.user.UserType)
         {
            case Users.eUserType.Admin:
               P.ContactsAdd = 1;
               P.ContactsEdit = 1;
               P.ContactsDelete = 1;
               P.ContactsViewSuppliersManila = 1;
               P.Counter_Add = 1;
               P.Counter_Edit = 1;
               P.Counter_Delete = 1;
               P.Counter_PaymentAdd = 1;
               P.Counter_PaymentDelete = 1;
               P.Counter_SetPaid = 1;
               P.Item_Add = 1;
               P.Item_Edit = 1;
               P.Item_Delete = 1;
               P.PO_Add = 1;
               P.PO_Edit = 1;
               P.PO_Delete = 1;
               P.PO_ViewSuppliersManila = 1;
               P.SI_Add = 1;
               P.SI_Edit = 1;
               P.SI_Delete = 1;
               P.SI_AddSuppliersManila = 1;
               P.SI_ViewSuppliersManila = 1;
               P.SI_Freight = 1;
               P.SIV_Add = 1;
               P.SIV_Edit = 1;
               P.SIV_Delete = 1;
               P.View_Agents = 1;
               P.View_BO = 1;
               P.View_Checks = 1;
               P.View_Contacts = 1;
               P.View_CustomerAccounting = 1;
               P.View_CustomerCommission = 1;
               P.View_DailySummaryReport = 1;
               P.View_Inventory = 1;
               P.View_Payments = 1;
               P.View_PO = 1;
               P.View_ReturnedItems = 1;
               P.View_SalesInvoice = 1;
               P.View_StockIn = 1;
               P.View_Vouchers = 1;
               P.Voucher_Add = 1;
               P.Voucher_Edit = 1;
               P.Voucher_Delete = 1;
               P.LoanedItems_Add = 1;
               P.LoanedItems_Edit = 1;
               P.LoanedItems_Delete = 1;
               P.Quotation_Add = 1;
               P.Quotation_Edit = 1;
               P.Quotation_Delete = 1;
               break;
            case Users.eUserType.Accounting:
               P.PO_Add = 1;
               P.PO_Edit = 1;
               P.SI_Add = 1;
               P.SI_Freight = 1;
               P.View_DailySummaryReport = 1;
               P.View_BO = 1;
               P.View_Checks = 1;
               P.View_Contacts = 1;
               P.View_CustomerCommission = 1;
               P.View_Inventory = 1;
               P.View_Payments = 1;
               P.View_PO = 1;
               P.View_ReturnedItems = 1;
               P.View_SalesInvoice = 1;
               P.View_StockIn = 1;
               P.View_Vouchers = 1;
               P.Counter_Add = 1;
               P.Counter_Edit = 2;
               P.Counter_Delete = 2;
               P.Counter_SetPaid = 2;
               P.Counter_PaymentAdd = 1;
               P.Counter_PaymentDelete = 2;
               P.Voucher_Add = 1;
               P.Voucher_Edit = 1;
               P.Voucher_Delete = 2;
               P.LoanedItems_Add = 1;
               P.LoanedItems_Edit = 1;
               P.LoanedItems_Delete = 2;
               P.Quotation_Add = 1;
               P.Quotation_Edit = 1;
               P.Quotation_Delete = 2;
               break;
            case Users.eUserType.Encoder:
               P.PO_Add = 1;
               P.PO_Edit = 1;
               P.SI_Add = 1;
               P.SI_Freight = 1;
               P.View_BO = 1;
               P.View_Checks = 1;
               P.View_Contacts = 1;
               P.View_Inventory = 1;
               P.View_Payments = 1;
               P.View_PO = 1;
               P.View_ReturnedItems = 1;
               P.View_SalesInvoice = 1;
               P.View_StockIn = 1;
               P.View_Vouchers = 1;
               P.Voucher_Add = 1;
               P.Voucher_Edit = 1;
               P.Voucher_Delete = 2;
               P.LoanedItems_Add = 1;
               P.LoanedItems_Edit = 1;
               P.LoanedItems_Delete = 2;
               P.Quotation_Add = 1;
               P.Quotation_Edit = 1;
               P.Quotation_Delete = 2;
               break;
            case Users.eUserType.Sales:
               P.PO_Add = 1;
               P.PO_Edit = 1;
               P.SI_Add = 1;
               P.SI_Edit = 1;
               P.SI_Freight = 1;
               P.View_BO = 1;
               P.View_Checks = 1;
               P.View_Contacts = 1;
               P.View_Inventory = 1;
               P.View_Payments = 1;
               P.View_PO = 1;
               P.View_ReturnedItems = 1;
               P.View_SalesInvoice = 1;
               P.View_StockIn = 1;
               P.SIV_Add = 1;
               P.SIV_Edit = 2;
               P.SIV_Delete = 2;
               P.LoanedItems_Add = 1;
               P.LoanedItems_Edit = 1;
               P.LoanedItems_Delete = 2;
               P.Quotation_Add = 1;
               P.Quotation_Edit = 1;
               P.Quotation_Delete = 2;
               break;
         }
      }

      public void CreateAdminUser()
      {
         using (ISession session = getSession())
         {
            using (ITransaction transaction = session.BeginTransaction())
            {
               try
               {
                  //check if admin
                  Users user = session.CreateQuery("from Users u where u.UserName='Admin'").UniqueResult<Users>();
                  if (user==null)
                  {
                     SimpleAES aes = new SimpleAES();
                     //no registered users, create default
                     user = new Users();
                     user.UserName = "Admin";
                     user.UserPassword = aes.EncryptToString("password");
                     user.UserType = Users.eUserType.Admin;
                     session.Save("Users", user);

                     //set permissions
                     UserPermissions P = new UserPermissions();
                     P.user = user;
                     SetPermissions(P);
                     session.Save("UserPermissions", P);
                  }
                  transaction.Commit();
               }
               catch(Exception ex)
               {
                  transaction.Rollback();
               }
            }
         }
      }

      public override void Delete(Users user)
      {
         using (ISession session = getSession())
         {
            using (ITransaction transaction = session.BeginTransaction())
            {
               try
               {
                  session.Delete("from UserPermissions as UP where UP.ID=" + user.ID);
                  session.Delete(user);
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
   }
}