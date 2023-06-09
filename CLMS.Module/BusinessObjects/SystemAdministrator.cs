using DevExpress.Persistent.Base;
using DevExpress.Xpo;

using System;

namespace CLMS.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class SystemAdministrator : ApplicationUser
    {
        public SystemAdministrator(Session session) : base(session)
        { }


    }
}