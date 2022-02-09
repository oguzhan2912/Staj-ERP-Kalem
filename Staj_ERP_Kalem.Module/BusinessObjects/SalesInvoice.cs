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
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using Staj_ERP_Kalem.Module.BusinessObjects;
using DevExpress.Persistent.Base.General;
using System.Collections;

namespace Staj_ERP_Kalem.Module.BusinessObjects
{
    public enum currencyType
    {
        turkishLira = 0,
        dollar = 1,
        euro = 2
    }
    [DefaultClassOptions]
    
    [NavigationItem("Tanım")]
    public class SalesInvoice : BaseObject
    { 
        public SalesInvoice(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();            
        }
        private Current current;
        [Association("Current-SalesInvoices")]
        public Current Current
        {
            get { return current; }
            set
            {
                {
                    SetPropertyValue(nameof(Current), ref current, value);
                }
            }
        }
        private Storage storage;

        [Association("Storage-SalesInvoices")]
        public Storage Storage
        {
            get { return storage; }
            set { SetPropertyValue(nameof(Storage), ref storage, value); }
        }

        [Association("SalesInvoice-SalesInvoiceItems")]

        public XPCollection<SalesInvoiceItem> SalesInvoicesItems
        {
            get
            {
                return GetCollection<SalesInvoiceItem>(nameof(SalesInvoicesItems));
            }
        }
        private DateTime documentTime;
        public DateTime DocumentTime
        {
            get { return documentTime; }
            set { SetPropertyValue(nameof(DocumentTime), ref documentTime, value); }
        }

        private currencyType currencyTypePrp;
        public currencyType CurrencyTypePrp
        {
            get { return currencyTypePrp; }
            set { SetPropertyValue(nameof(CurrencyTypePrp), ref currencyTypePrp, value); }
        }
        private decimal totalSum;
        public decimal TotalSum
        {
            get { return totalSum; }
            set
            {
                if (SetPropertyValue(nameof(TotalSum), ref totalSum, value))
                {
                    if (!IsSaving && !IsLoading)
                    {
                        foreach (var item in Current.SalesInvoices)
                        {
                            Current.TotalCredit += item.TotalSum;
                        }
                    }
                }
            }
        }
        private decimal totalDiscount;
        public decimal TotalDiscount
        {
            get { return totalDiscount; }
            set
            {
                SetPropertyValue(nameof(TotalDiscount), ref totalDiscount, value);
            }
        }

        [Indexed("DocumentNumber", Unique = true)]
        private int documentNumber;
        [RuleUniqueValue]
        public int DocumentNumber
        {
            get { return documentNumber; }
            set { SetPropertyValue(nameof(DocumentNumber), ref documentNumber, value); }
        }
    }
}