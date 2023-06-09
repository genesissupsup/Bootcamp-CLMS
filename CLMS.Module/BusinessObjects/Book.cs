using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

using System;

namespace CLMS.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Book : BaseObject
    {
        public Book(Session session) : base(session)
        { }

        bool isCheckedOut;
        Author author;
        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [Association("Author-Books")]
        public Author Author
        {
            get => author;
            set => SetPropertyValue(nameof(Author), ref author, value);
        }

        public bool IsCheckedOut
        {
            get => isCheckedOut;
            set => SetPropertyValue(nameof(IsCheckedOut), ref isCheckedOut, value);
        }
    }
}