using System;

namespace MyHibernate.BusinessObjects
{
   public partial class UserPermissions
   {
      public virtual Int32 ID { get; set; }
      public virtual Users user { get; set; }
      public virtual Int32 ContactsAdd { get; set; }
      public virtual Int32 ContactsEdit { get; set; }
      public virtual Int32 ContactsDelete { get; set; }
      public virtual Int32 ContactsViewSuppliersManila { get; set; }
      public virtual Int32 PO_Add { get; set; }
      public virtual Int32 PO_AddSuppliersManila { get; set; }
      public virtual Int32 PO_Edit { get; set; }
      public virtual Int32 PO_Delete { get; set; }
      public virtual Int32 PO_ViewSuppliersManila { get; set; }
      public virtual Int32 PO_ChangeStatus { get; set; }
      public virtual Int32 SI_Add { get; set; }
      public virtual Int32 SI_Edit { get; set; }
      public virtual Int32 SI_Delete { get; set; }
      public virtual Int32 SI_AddSuppliersManila { get; set; }
      public virtual Int32 SI_ViewSuppliersManila { get; set; }
      public virtual Int32 SI_Freight { get; set; }
      public virtual Int32 Item_Add { get; set; }
      public virtual Int32 Item_Edit { get; set; }
      public virtual Int32 Item_Delete { get; set; }
      public virtual Int32 SIV_Add { get; set; }
      public virtual Int32 SIV_Edit { get; set; }
      public virtual Int32 SIV_Delete { get; set; }
      public virtual Int32 Voucher_Add { get; set; }
      public virtual Int32 Voucher_Edit { get; set; }
      public virtual Int32 Voucher_Delete { get; set; }
      public virtual Int32 Counter_Add { get; set; }
      public virtual Int32 Counter_Edit { get; set; }
      public virtual Int32 Counter_Delete { get; set; }
      public virtual Int32 Counter_SetPaid { get; set; }
      public virtual Int32 Counter_PaymentAdd { get; set; }
      public virtual Int32 Counter_PaymentDelete { get; set; }
      
      public virtual Int32 LoanedItems_Add { get; set; }
      public virtual Int32 LoanedItems_Edit { get; set; }
      public virtual Int32 LoanedItems_Delete { get; set; }

      public virtual Int32 Quotation_Add { get; set; }
      public virtual Int32 Quotation_Edit { get; set; }
      public virtual Int32 Quotation_Delete { get; set; }

      
      public virtual Int32 View_Contacts { get; set; }
      public virtual Int32 View_PO { get; set; }
      public virtual Int32 View_StockIn { get; set; }
      public virtual Int32 View_BO { get; set; }
      public virtual Int32 View_ReturnedItems { get; set; }
      public virtual Int32 View_Vouchers { get; set; }
      public virtual Int32 View_Inventory { get; set; }
      public virtual Int32 View_SalesInvoice { get; set; }
      public virtual Int32 View_Checks { get; set; }
      public virtual Int32 View_Payments { get; set; }
      public virtual Int32 View_Agents { get; set; }
      public virtual Int32 View_DailySummaryReport { get; set; }
      public virtual Int32 View_CustomerAccounting { get; set; }
      public virtual Int32 View_CustomerCommission { get; set; }
   }
}