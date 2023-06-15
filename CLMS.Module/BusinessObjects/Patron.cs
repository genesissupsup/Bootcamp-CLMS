using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;

using System;

namespace CLMS.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Patron : BaseObject
    {
        public Patron(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
            
            // --- Create a Patron User Account
            loginAccount = new PatronAccount(Session);

            // --- By default, UserName is the Patron Name
            loginAccount.UserName = Guid.NewGuid().ToString();
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (Session.IsNewObject(this) == true)
            {
                // --- By default, UserName is the Patron Name
                loginAccount.UserName = this.name;

                // --- Add `Default` Role, using LINQ with XPO data Session
                loginAccount.Roles.Add(Session.Query<PermissionPolicyRole>().Where(x=>x.Name == "Default").FirstOrDefault());

                // --- Add `Patrons` Role
                loginAccount.Roles.Add(Session.Query<PermissionPolicyRole>().Where(x => x.Name == "Patrons").FirstOrDefault());

                // --- Add Login Info
                // NOTE: When adidng a new `ApplicationUser` via code, it's important to add its inti`ApplicationUserLoginInfo`
                var loginInfo = new ApplicationUserLoginInfo(Session);
                loginInfo.LoginProviderName = SecurityDefaults.PasswordAuthentication;
                loginInfo.ProviderUserKey = Guid.NewGuid().ToString();
                loginInfo.User = loginAccount;
                loginAccount.LoginInfo.Add(loginInfo);
            }
        }

        decimal accountBalance;
        PatronAccount loginAccount;
        DateTime birthDate;
        string name;

        [Size(80)]
        [ImmediatePostData]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        public DateTime BirthDate
        {
            get => birthDate;
            set => SetPropertyValue(nameof(BirthDate), ref birthDate, value);
        }

        [ImmediatePostData]
        [Appearance("DisableLoginAccount", Enabled = false)]
        public PatronAccount LoginAccount
        {
            get => loginAccount;
            set => SetPropertyValue(nameof(LoginAccount), ref loginAccount, value);
        }
        
        public decimal AccountBalance
        {
            get => accountBalance;
            set => SetPropertyValue(nameof(AccountBalance), ref accountBalance, value);
        }

        [Association("Patron-Transactions")]
        public XPCollection<InventoryTransaction> Transactions
        {
            get
            {
                return GetCollection<InventoryTransaction>(nameof(Transactions));
            }
        }
    }
}