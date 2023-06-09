using CLMS.Module.BusinessObjects;

using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLMS.Module.Controllers
{
    [DomainComponent]
    public class InventoryTransactionViewModel : NonPersistentBaseObject
    {
        public InventoryTransactionViewModel() 
        { }


        DateTime dueDate;
        object book;

        public object Book
        {
            get => book;
            set
            {
                if (book == value)
                    return;
                book = value;
                OnPropertyChanged(nameof(Book));
            }
        }


        
        public DateTime DueDate
        {
            get => dueDate;
            set
            {
                if (dueDate == value)
                    return;
                dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }
        

    }

    public class InventoryTransactionViewController : ViewController
    {
        SimpleAction BorrowAction;
        public InventoryTransactionViewController()
        {
            TargetViewType = ViewType.ListView;
            TargetViewNesting = Nesting.Nested;
            TargetObjectType = typeof(InventoryTransaction);

            BorrowAction = new SimpleAction(this, "BorrowAction", PredefinedCategory.ObjectsCreation);
            BorrowAction.Execute += BorrowAction_Execute;
            
        }
        private void BorrowAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
    }
}
