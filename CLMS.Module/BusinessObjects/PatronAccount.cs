using DevExpress.Persistent.Base;
using DevExpress.Xpo;

using System;

namespace CLMS.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(false)]
    public class PatronAccount : ApplicationUser
    {
        public PatronAccount(Session session) : base(session)
        { }


    }
}