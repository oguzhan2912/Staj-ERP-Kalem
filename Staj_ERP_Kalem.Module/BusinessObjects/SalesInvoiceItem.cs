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
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Utils;

namespace Staj_ERP_Kalem.Module.BusinessObjects
{
    public enum type
    {
        Malzeme = 0,
        HesapDokumu = 1
    }
    [DefaultClassOptions]
   
    public class SalesInvoiceItem : BaseObject 
    { 
        public SalesInvoiceItem(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        public KartBaseObject KartBaseObject = new KartBaseObject(null);
        
        private SalesInvoice salesInvoice;
        [Association("SalesInvoice-SalesInvoiceItems")] //ONE KISMI
        public SalesInvoice SalesInvoice
        {
            get { return salesInvoice; }
            set { SetPropertyValue(nameof(SalesInvoice), ref salesInvoice, value); }
        }
        private Unit unit;
        [Association("Unit-SalesInvoiceItems")] //ONE KISMI
        public Unit Unit
        {
            get { return unit; }
            set { SetPropertyValue(nameof(Unit), ref unit, value); }
        }
        private Product product;
        [Association("Product-SalesInvoiceItems")]
        public Product Product
        {
            get
            {
                return product;
            }
            set
            {
                SetPropertyValue(nameof(Product), ref product, value);

            }
        }
        
        private int code;
        public int Code
        {
            get { return code; }
            set
            {
                SetPropertyValue(nameof(Code), ref code, KartBaseObject.Code);
            }
        }
        private decimal unitAmount;
        public decimal UnitAmount
        {
            get { return unitAmount; }
            set { SetPropertyValue(nameof(UnitAmount), ref unitAmount, value); }
        }
        private decimal amount;
        public decimal Amount
        {
            get { return amount; }
            set { SetPropertyValue(nameof(Amount), ref amount, value); }
        }

        private decimal unitPrice;
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { SetPropertyValue(nameof(UnitPrice), ref unitPrice, value); }
        }
        private decimal discount;
        public decimal Discount
        {
            get { return discount; }
            set { SetPropertyValue(nameof(Discount), ref discount, value); }
        }

        private decimal total;
        public decimal Total
        {
            get { return total; }
            set
            {
                bool changed = SetPropertyValue("Total", ref total, (Amount * UnitPrice * UnitAmount) - (Amount * UnitPrice * UnitAmount) * Discount / 100);
                if (!IsLoading && !IsSaving && changed)
                {
                    foreach (var item in SalesInvoice.SalesInvoicesItems)
                    {
                        SalesInvoice.TotalSum = item.Total;

                    }
                }
            }
        }

        private decimal discountAmount;
        public decimal DiscountAmount
        {
            get { return discountAmount; }
            set
            {
                if (SetPropertyValue(nameof(DiscountAmount), ref discountAmount, (Amount * UnitPrice * UnitAmount) * Discount / 100))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        decimal temp = 0;
                        foreach (var item in SalesInvoice.SalesInvoicesItems)
                        {
                            temp += item.DiscountAmount;
                        }
                        SalesInvoice.TotalDiscount = temp;
                    }
                }

            }
        }

        private type type;
        public type Type
        {
            get { return type; }
            set { SetPropertyValue(nameof(Type), ref type, value); }
        }

        [Indexed("BarCode", Unique = true)]
        private decimal barCode;
        [RuleUniqueValue]

        public decimal BarCode
        {
            get { return barCode; }
            set { SetPropertyValue(nameof(BarCode), ref barCode, value); }
        }
    }
}