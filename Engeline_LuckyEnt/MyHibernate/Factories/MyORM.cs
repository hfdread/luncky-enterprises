using System;
using NHibernate;
using NHibernate.Cfg;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace MyHibernate.Factories
{
    /// <summary>
    /// Description of MyORM.
    /// </summary>
    public sealed class MyORM
    {
        private static bool m_Initialized = false;
        private static string m_ErrorMessage = "";
        private static ISessionFactory sessionFactory = null;
        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static MyORM()
        {
            //do initialization
            InitializeORM();
        }

        private static void InitializeORM()
        {
            try
            {
                //log.Info("---------------------------");
                //log.Info("Initializing MyORM");
                //log.Info("---------------------------");
                //log.Info("loading configuration...");
                Configuration cfg = new Configuration();
                //log.Info("configuration... loaded.");

                clsDBConnect dbcon = new clsDBConnect();
                if (!dbcon.IsValid())
                    throw new Exception("Invalid DB Connection!");

                SimpleAES aes = new SimpleAES();
                //string dbpwd = "adm1n";
                cfg.Properties["connection.connection_string"] =
                   string.Format("Server={0};Database=engeline_luckyent;uid={1};pwd={2};", dbcon.DB_Server, dbcon.DB_User,
                                 aes.DecryptString(dbcon.DB_Password));
                                
                cfg.AddAssembly("MyHibernate");

                //log.Info("Building SessionFactory...");
                sessionFactory = cfg.BuildSessionFactory();
                m_Initialized = true;
                //log.Info("Initialization done.");
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                m_Initialized = false;
                if (ex.InnerException == null)
                    m_ErrorMessage = ex.Message;
                else
                {
                    m_ErrorMessage = string.Format("{0}\n\nInnerException:\n{1}", ex.Message, ex.InnerException.ToString());
                }
            }
        }

        public static bool IsInitialized()
        {
            return m_Initialized;
        }

        public static string LastErrorMessage()
        {
            return m_ErrorMessage;
        }

        public static int BuilSessionFactory(string con)
        {
            return 0;
        }

        public static ISession GetCurrentSession()
        {
            if (sessionFactory != null)
                return sessionFactory.OpenSession();
            else
            {
                //try once more
                InitializeORM();
                if (sessionFactory != null)
                    return sessionFactory.OpenSession();
                else
                    return null;
            }
        }

        public static void CloseSession()
        {
            //ISession currentSession = (ISession)System.Runtime.Remoting.Messaging.CallContext.GetData(SESSIONKEY);
            //if (currentSession == null)
            //{
            //   // No current session
            //   return;
            //}
            //currentSession.Close();
        }

        public static void CloseSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }
    }
}