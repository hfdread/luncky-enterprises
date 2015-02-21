using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Security.AccessControl;

namespace MyHibernate
{
    public class clsDBConnect
    {
        private const string PROJECTNAME = "SOFTWARE\\EngelineSoftware";

        public String DB_Server { get; set; }
        public String DB_User { get; set; }
        public String DB_Password { get; set; }

        private RegistrySecurity _rs;
        private RegistryKey _baseRK = Registry.LocalMachine.OpenSubKey("SOFTWARE");
        private RegistryKey _subRK;

        public clsDBConnect()
        {
            DB_Server = "";
            DB_User = "";
            DB_Password = "";

            string user = Environment.UserDomainName + "\\" + Environment.UserName;

            RegistrySecurity rs = new RegistrySecurity();

            // Allow the current user to read and delete the key.
            //
            rs.AddAccessRule(new RegistryAccessRule(user,
                                                    RegistryRights.ReadKey | RegistryRights.Delete,
                                                    InheritanceFlags.None,
                                                    PropagationFlags.None,
                                                    AccessControlType.Allow));

            // Prevent the current user from writing or changing the
            // permission set of the key. Note that if Delete permission
            // were not allowed in the previous access rule, denying
            // WriteKey permission would prevent the user from deleting the 
            // key.
            rs.AddAccessRule(new RegistryAccessRule(user,
                                                    RegistryRights.WriteKey | RegistryRights.ChangePermissions,
                                                    InheritanceFlags.None,
                                                    PropagationFlags.None,
                                                    AccessControlType.Allow));

            //read settings
            //_rs = SetAccessControl();
            _subRK = Registry.LocalMachine.OpenSubKey(PROJECTNAME, true);

            if (_subRK != null)
            {
                _subRK.SetAccessControl(rs);
                if (_subRK.GetValue("DB_Server") != null)
                    DB_Server = _subRK.GetValue("DB_Server").ToString();
                if (_subRK.GetValue("DB_User") != null)
                    DB_User = _subRK.GetValue("DB_User").ToString();
                if (_subRK.GetValue("DB_Password") != null)
                    DB_Password = _subRK.GetValue("DB_Password").ToString();
            }
            else
            {
                //_subRK.SetAccessControl(_rs);
                _subRK = Registry.LocalMachine.CreateSubKey(PROJECTNAME, RegistryKeyPermissionCheck.Default, rs);
            }
        }

        private RegistrySecurity SetAccessControl()
        {
            string user = Environment.UserDomainName + "\\" + Environment.UserName;
            RegistrySecurity rs = new RegistrySecurity();
            rs.AddAccessRule(new RegistryAccessRule(user, RegistryRights.FullControl, InheritanceFlags.None,
                                                    PropagationFlags.None, AccessControlType.Allow));
            return rs;
        }

        public void SaveSettings()
        {
            if (_subRK != null)
            {
                _subRK.SetValue("DB_Server", DB_Server);
                _subRK.SetValue("DB_User", DB_User);
                _subRK.SetValue("DB_Password", DB_Password);
            }
        }

        public bool IsValid()
        {
            if (DB_Server == "" || DB_User == "" || DB_Password == "")
                return false;
            else
            {
                return true;
            }
        }
    }
}
