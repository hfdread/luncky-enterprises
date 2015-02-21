#region

using System;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using Engeline_LuckyEnt.UI_Controls.Utilities;
using Engeline_LuckyEnt.Forms;
using DevExpress.XtraEditors;

#endregion

namespace Engeline_LuckyEnt.Classes
{
    public static class clsUtil
    {
        public const string FMT_AMOUNT = "#,##0.00";
        public const string FMT_ID = "000000";
        public const string FMT_DATE1 = "MMM dd, yyyy";
        public const string FMT_DATE2 = "MM/dd/yy";
        public const string FMT_DATE3 = "MM/dd/yyyy";
        public const string FMT_DATE_MYSQL = "yyyy-MM-dd";
        public const string FMT_DATE_MYSQL2 = "yyyy-MM-dd hh:";

        public const string MSG_OPERATIONNOTALLOWED = "Operation Not Allowed";
        public const string MSG_NO_PERMISSION = "You do not have enough privileges to use this function!";
        public const string MSG_APPROVAL_REQUEST = "Approval Request";
        public const string MSG_REQUEST_DENIED = "Approval request was declined!";

        private static frmMain2 m_frmMain = null;

        public static DialogResult ShowMessage(string msg, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(msg, title, buttons, icon);
        }
        public static DialogResult ShowMessageInformation(string msg, string title)
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowMessageExclamation(string msg, string title)
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static DialogResult ShowMessageError(string ErrorMessage)
        {
            return MessageBox.Show(string.Format("Error: {0}", ErrorMessage), "Error", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
        }

        public static DialogResult ShowMessageError(string msg, string title)
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowMessageError(Exception ex, string title)
        {
            string msg = "";

            if (ex.InnerException != null)
                msg = string.Format("{0}\n\nInner Exception:\n{1}", ex.Message, ex.InnerException.Message);
            else
                msg = ex.Message;

            return MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static frmMain2 getMainForm()
        {
            return frmMain2.m_frmMainInstance;
            //foreach (Form frm in Application.OpenForms)
            //{
            //    if (frm.Name == "frmMain")
            //    {
            //        return (frmMain2)frm;
            //    }
            //}
            //return null;
        }


       

        public static double ParseDouble(string value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }

        public static double ParseDouble(object value)
        {
            try
            {
                return (double)(value);
            }
            catch
            {
                return 0;
            }
        }

        public static bool ParseBoolean(object value)
        {
            try
            {
                return (bool)value;
            }
            catch
            {
                return false;
            }
        }

        public static Int32 ParseInt32(string value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }

        public static Int32 ParseInt32(object value)
        {
            try
            {
                return (Int32)value;
            }
            catch
            {
                return 0;
            }
        }

        public static String ParseString(object value)
        {
            if (value != null)
            {
                return value.ToString();
            }
            else
            {
                return "";
            }
        }

        public static String ParseString(String value, int start, int length)
        {
            if (value.Length > 0 && value.Length > length)
            {
                return value.Substring(start, length);
            }
            else if (value.Length > 0 && value.Length <= length)
            {
                return value;
            }
            else
            {
                return "";
            }
        }

        public static String CleanStringFromGarbage(String value)
        {
            if (value.Length > 0)
            {
                string newStr = value, temp="";
                temp = value.Substring(value.Length - 1);
                if(temp == "\\" || temp == "'")
                {
                    value = value.Remove(value.Length-1);
                    newStr = value;
                }

                if (value.IndexOf("'") > -1)
                {
                    value = value.Replace("'", "");
                    newStr = value;
                }

                return newStr;
            }
            else
            {
                return "";
            }
        }

        public static DialogResult ShowMessageYesNo(string msg, string title)
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void ShowMessagePermissionNotAllowed()
        {
            MessageBox.Show(MSG_NO_PERMISSION, MSG_OPERATIONNOTALLOWED, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void ShowMessageRequestDeclined()
        {
            MessageBox.Show(MSG_REQUEST_DENIED, MSG_APPROVAL_REQUEST, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void setMainForm(frmMain2 frm)
        {
            m_frmMain = frm;
        }

        public static double CheckValue(TextBox obj)
        {
            double ret = 0;

            if (string.IsNullOrEmpty(Strings.Trim(obj.Text)))
            {
                obj.Text = "0";
                ret = 0;
            }
            else
            {
                if (!Information.IsNumeric(obj.Text))
                {
                    obj.Text = "0";
                    ret = 0;
                }
                else
                {
                    ret = Convert.ToDouble(obj.Text);
                }
            }
            if (ret == 0)
            {
                obj.SelectAll();
            }
            return ret;
        }

        public static double CheckValue(DevExpress.XtraEditors.TextEdit obj)
        {
            double ret = 0;

            if (string.IsNullOrEmpty(Strings.Trim(obj.Text)))
            {
                obj.Text = "0";
                ret = 0;
            }
            else
            {
                if (!Information.IsNumeric(obj.Text))
                {
                    obj.Text = "0";
                    ret = 0;
                }
                else
                {
                    ret = Convert.ToDouble(obj.Text);
                }
            }
            if (ret == 0)
            {
                obj.SelectAll();
            }
            return ret;
        }

        public static string GenerateFilterCondition(string sFilter)
        {
            string[] tokens = null;
            StringBuilder ret = new StringBuilder();
            tokens = sFilter.Split(' ');
            ret.Append("%");
            for (int i = 0; i < tokens.Length; i++)
            {
                ret.Append(tokens[i]);
                ret.Append("%");
            }
            return ret.ToString();
        }

      public struct myFormula
      {
         public int iSign;
         public double iPercent;
         public int iLoop;
      }

      public static double DiscountAmt(double Amt, string sFormula)
      {
          double ret = 0;
          string[] sOperations = null;
          int i = 0;
          myFormula tOP = default(myFormula);
          double dblAmount = 0;
          int ii = 0;

          //check for valid formula
          if (!CheckFormula(sFormula))
          {
              ret = Amt;
              return ret;
          }

          if (Information.IsNumeric(sFormula))
          {
              if (sFormula.Substring(0, 1) == "+")
              {
                  dblAmount = Amt + (Amt * Convert.ToDouble(sFormula) / 100);
              }
              else
              {
                  dblAmount = Amt - (Amt * Convert.ToDouble(sFormula) / 100);
              }

              //Begin 10/1/2009 Guy Jasper
              //Limit result to 2 decimal places
              dblAmount = Double.Parse(Convert.ToDouble(dblAmount).ToString("#,##0.00"));
              return dblAmount;
              //End 10/1/2009 Guy Jasper
          }

          sOperations = sFormula.Split('/');

          dblAmount = Amt;
          for (i = 0; i < sOperations.Length; i++)
          {
              if (StringToFormula(sOperations[i], ref tOP) == 0)
              {
                  for (ii = 1; ii <= tOP.iLoop; ii++)
                  {
                      if (tOP.iSign == 1)
                      {
                          dblAmount = dblAmount + (dblAmount * (tOP.iPercent / 100));
                      }
                      else
                      {
                          dblAmount = dblAmount - (dblAmount * (tOP.iPercent / 100));
                      }
                  }
              }
          }

          //Begin 10/1/2009 Guy Jasper
          //Limit result to 2 decimal places
          ret = Convert.ToDouble(Strings.Format(dblAmount, "#,##0.00"));
          return ret;
          //End 10/1/2009 Guy Jasper
          //DiscountAmt = dblAmount
      }

        public static int StringToFormula(string sOperand, ref myFormula tOperand)
        {
            int ret = 0;
            int iIndex = 0;

            ret = -1;
            if (CheckFormula2(sOperand) == 0)
            {
                if (Information.IsNumeric(sOperand))
                {
                    if (Strings.Left(sOperand, 1) == "+")
                    {
                        tOperand.iSign = 1;
                        tOperand.iPercent = (int)Conversion.Val(sOperand);
                    }
                    else if (Strings.Left(sOperand, 1) == "-")
                    {
                        tOperand.iSign = -1;
                        tOperand.iPercent = (int)Conversion.Val(sOperand) * -1;
                    }
                    else
                    {
                        tOperand.iSign = -1;
                        tOperand.iPercent = (int)Conversion.Val(sOperand);
                    }
                    tOperand.iLoop = 1;
                    return 0;
                }


                if (Strings.Left(sOperand, 1) == "+")
                {
                    tOperand.iSign = 1;
                }
                else if (Strings.Left(sOperand, 1) == "-" | Information.IsNumeric(Strings.Left(sOperand, 1)))
                {
                    tOperand.iSign = -1;
                }
                else
                {
                    return -1;
                }

                iIndex = Strings.InStr(1, sOperand, "*", Constants.vbTextCompare);

                if (iIndex == 0)
                {
                    //No "*" found
                    if (Strings.Left(sOperand, 1) == "+" | Strings.Left(sOperand, 1) == "-")
                    {
                        if (!Information.IsNumeric(Strings.Mid(sOperand, 2)))
                        {
                            return -1;
                        }
                        else
                        {
                            tOperand.iPercent = (int)Conversion.Val(Strings.Mid(sOperand, 2));
                        }
                    }
                    else if (Information.IsNumeric(Strings.Left(sOperand, 1)))
                    {
                        if (Information.IsNumeric(sOperand))
                        {
                            tOperand.iPercent = (int)Conversion.Val(sOperand);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        //Invalid formula
                        return -1;
                    }
                    tOperand.iLoop = 1;
                    return 0;
                }
                else
                {
                    //"*" found
                    if (Information.IsNumeric(Strings.Mid(sOperand, iIndex + 1)))
                    {
                        if (Strings.Left(sOperand, 1) == "+" | Strings.Left(sOperand, 1) == "-")
                        {
                            if (Information.IsNumeric(Strings.Mid(sOperand, 2, iIndex - 2)))
                            {
                                tOperand.iPercent = (int)Conversion.Val(Strings.Mid(sOperand, 2, iIndex - 2));
                                tOperand.iLoop = (int)Conversion.Val(Strings.Mid(sOperand, iIndex + 1));
                            }
                            else
                            {
                                return -1;
                            }
                        }
                        else
                        {
                            if (Information.IsNumeric(Strings.Mid(sOperand, 1, iIndex - 1)))
                            {
                                tOperand.iPercent = (int)Conversion.Val(Strings.Mid(sOperand, 1, iIndex - 1));
                                tOperand.iLoop = (int)Conversion.Val(Strings.Mid(sOperand, iIndex + 1));
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                }
                ret = 0;
            }
            return ret;
        }

        public static bool CheckFormula(string sFormula)
        {
            string[] sOperations = null;
            int i = 0;

            if (Information.IsNumeric(sFormula))
            {
                return true;
            }

            //Begin 2010/03/19 [Guy]
            if (string.IsNullOrEmpty(sFormula))
            {
                return false;
            }
            //End 2010/03/19 [Guy]

            sOperations = sFormula.Split('/');

            //check for valid formula
            for (i = 0; i < sOperations.Length; i++)
            {
                if (CheckFormula2(sOperations[i]) != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int CheckFormula2(string sFormula)
        {
            int ret = 0;
            int iIndex = 0;

            ret = -1;
            if (Information.IsNumeric(sFormula))
            {
                return 0;
            }

            if (Strings.Left(sFormula, 1) != "+")
            {
                if (Strings.Left(sFormula, 1) != "-")
                {
                    if (!Information.IsNumeric(Strings.Left(sFormula, 1)))
                    {
                        return ret;
                    }
                }
            }

            iIndex = Strings.InStr(2, sFormula, "*", Constants.vbTextCompare);
            if (iIndex == 0)
            {
                if (!Information.IsNumeric(Strings.Mid(sFormula, 2)))
                {
                    return ret;
                }
                else
                {
                    return 0;
                }
            }

            if (iIndex == Strings.Len(sFormula))
                return ret;

            if (!Information.IsNumeric(Strings.Mid(sFormula, iIndex + 1)))
                return ret;

            ret = 0;
            return ret;
        }

        public static string GenerateSQLCondition(string sFld, string sSearch, string sSep)
        {
            string sTemp, sTemp3;
            string[] sTemp2;

            sTemp = sTemp3 = "";
            if (sSearch.Trim() != "")
            {
                sTemp2 = sSearch.Split(sSep.ToCharArray());
                if (sTemp2.Length >= 0)
                {
                    sTemp3 = "%";
                    for (int i = 0; i < sTemp2.Length; i++)
                    {
                        sTemp3 += sTemp2[i] + "%";
                    }
                }

                return sFld + " LIKE '" + sTemp3 + "'";
            }
            return "";
        }

        public static Users GetLoggedInUser()
        {
            return getMainForm().g_LoggedInUser;
        }

        public static UserPermissions GetUserPermissions()
        {
            return getMainForm().g_Permissions;
        }

        /*public static bool ProcessApprovalRequest(string msg, RequestApproval.eRequestType type)
        {
            RequestApproval ra = new RequestApproval();
            ra.RequestDate = DateTime.Now;
            ra.RequestType = type;
            ra.Sender = getMainForm().g_LoggedInUser;
            ra.Terminal = System.Environment.MachineName;
            ra.Message = msg;

            ctlRequestSend ctl = new ctlRequestSend(ra);
            frmGenericPopup frm = new frmGenericPopup();
            frm.ShowRequestAprroval(ctl);

            if (ctl.m_Request.Status == RequestApproval.eStatus.Approved)
            {
                return true;
            }
            else
            {
                if (ctl.m_Request.Status == RequestApproval.eStatus.Declined)
                    ShowMessageRequestDeclined();
                return false;
            }
        }*/

        public static string GenerateRegexCondition(string sFilter)
        {
            string[] tokens = null;
            StringBuilder ret = new StringBuilder();
            tokens = sFilter.Split(' ');
            ret.Append(tokens[0]);
            for (int i = 1; i < tokens.Length; i++)
            {
                ret.Append(".*[a-z0-9]*");
                ret.Append(tokens[i]);
            }
            return ret.ToString();
        }

        public static Double CalculateWithholdingAmount(Double amount)
        {
            return Math.Round(amount / 1.12 * 0.01, 2);
        }

        public static int GetComboItemIndexBanks(ComboBoxEdit cbo, Banks bank)
        {
            for (int i = 0; i < cbo.Properties.Items.Count; i++)
            {
                Banks b = (Banks)cbo.Properties.Items[i];
                if (b.ID == bank.ID)
                    return i;
            }
            return -1;
        }

        public static int GetComboItemIndexContacts(ComboBoxEdit cbo, Contacts item)
        {
            for (int i = 0; i < cbo.Properties.Items.Count; i++)
            {
                Contacts c = (Contacts)cbo.Properties.Items[i];
                if (c.ID == item.ID)
                    return i;
            }
            return -1;
        }

        public static bool ProcessApprovalRequest(string msg, RequestApproval.eRequestType type, int format = 0)
        {
            RequestApproval ra = new RequestApproval();
            ra.RequestDate = DateTime.Now;
            ra.RequestType = type;
            ra.Sender = getMainForm().g_LoggedInUser;
            ra.Terminal = System.Environment.MachineName;
            ra.Message = msg;
            //ra.MessageFormat = format;

            ctlRequestSend ctl = new ctlRequestSend(ra);
            frmGenericPopup frm = new frmGenericPopup();
            frm.ShowRequestAprroval(ctl);

            if (ctl.m_Request.Status == RequestApproval.eStatus.Approved)
            {
                return true;
            }
            else
            {
                if (ctl.m_Request.Status == RequestApproval.eStatus.Declined)
                    ShowMessageRequestDeclined();
                return false;
            }
        }
    }//end of class
}//end of file
