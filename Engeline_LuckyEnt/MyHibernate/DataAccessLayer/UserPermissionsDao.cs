using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
   public class UserPermissionsDao : GenericDao<UserPermissions>
   {
      public UserPermissions GetByUserID(Int32 ID)
      {
         using (ISession session = getSession())
         {
            return
               session.CreateQuery("from UserPermissions as UP where UP.user.ID=" + ID).UniqueResult<UserPermissions>();
         }
      }
   }
}