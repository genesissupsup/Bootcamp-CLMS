using DevExpress.Persistent.Base;
using DevExpress.Xpo;

using System;

namespace CLMS.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Librarian : ApplicationUser
    {
        public Librarian(Session session) : base(session)
        { }


        string name;

        [Size(64)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
    }
}