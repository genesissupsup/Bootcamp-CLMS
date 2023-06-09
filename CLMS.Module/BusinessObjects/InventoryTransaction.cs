using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

using System;

namespace CLMS.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class InventoryTransaction : BaseObject
    {
        public InventoryTransaction(Session session) : base(session)
        { }
        DateTime dueDate;
        Patron patron;
        decimal rentalFee;
        Patron borrower;
        DateTime dateReturned;
        DateTime dateBorrowed;
        Book book;

        public DateTime DateBorrowed
        {
            get => dateBorrowed;
            set => SetPropertyValue(nameof(DateBorrowed), ref dateBorrowed, value);
        }

        
        public DateTime DueDate
        {
            get => dueDate;
            set => SetPropertyValue(nameof(DueDate), ref dueDate, value);
        }

        public DateTime DateReturned
        {
            get => dateReturned;
            set => SetPropertyValue(nameof(DateReturned), ref dateReturned, value);
        }

        
        public Patron Borrower
        {
            get => borrower;
            set => SetPropertyValue(nameof(Borrower), ref borrower, value);
        }
        
        public Book Book
        {
            get => book;
            set => SetPropertyValue(nameof(Book), ref book, value);
        }

        public decimal RentalFee
        {
            get => rentalFee;
            set => SetPropertyValue(nameof(RentalFee), ref rentalFee, value);
        }


        [Association("Patron-Transactions")]
        public Patron Patron
        {
            get => patron;
            set => SetPropertyValue(nameof(Patron), ref patron, value);
        }
    }
}