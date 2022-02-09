using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Staj_ERP_Kalem.Module.BusinessObjects
{
    [DefaultClassOptions]
    
    public class Storage : BaseObject
    { 
        public Storage(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private Branch branch;
        [Association("Branch-Storages")]
        public Branch Branch
        {
            get { return branch; }
            set
            {
                SetPropertyValue(nameof(Branch), ref branch, value);
            }
        }
        [Association("Storage-SalesInvoices")]
        public XPCollection<SalesInvoice> SalesInvoices
        {
            get
            {
                return GetCollection<SalesInvoice>(nameof(SalesInvoices));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                SetPropertyValue(nameof(Name), ref name, value);
            }
        }
    }
}