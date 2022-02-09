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
    
    public class Branch : BaseObject
    { 
        public Branch(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        [Association("Branch-Storages")]

        public XPCollection<Storage> Storages
        {
            get
            {
                return GetCollection<Storage>(nameof(Storages));
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