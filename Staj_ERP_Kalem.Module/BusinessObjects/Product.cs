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
    [MapInheritance(MapInheritanceType.ParentTable)]
    
    public class Product : KartBaseObject
    { 
        public Product(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }
        private UnitSet unitSet;
        [Association("UnitSet-Products")]
        public UnitSet UnitSet
        {
            get
            {
                return unitSet;
            }
            set
            {
                SetPropertyValue(nameof(UnitSet), ref unitSet, value);
            }
        }
        /*
        [Association("Product-SalesInvoiceItems")]
        public XPCollection<SalesInvoiceItem> SalesInvoiceItems
        {
            get
            {
                return GetCollection<SalesInvoiceItem>(nameof(SalesInvoiceItems));
            }
        }*/
    }
}