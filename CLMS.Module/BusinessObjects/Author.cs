using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

using System;

namespace CLMS.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Author : BaseObject
    {
        public Author(Session session) : base(session)
        { }


        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
        [Association("Author-Books")]
        public XPCollection<Book> Books
        {
            get
            {
                return GetCollection<Book>(nameof(Books));
            }
        }
    }
}