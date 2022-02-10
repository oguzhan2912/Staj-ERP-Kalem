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
        private KartBaseObject typeKart;
        [DataSourceCriteria("Iif('@This.TypePrp'=='Malzeme',IsExactType(@This,'Staj_ERP_Kalem.Module.BusinessObjects.Product')," + //Tip malzeme seçilirse Producta ait bilgileri çağıracak değil ise Hesap dökümünü getiricek.
            "Iif('@This.TypePrp'=='HesapDokumu',IsExactType(@This,'Staj_ERP_Kalem.Module.BusinessObjects.BreakDown'),false))")]       
        public KartBaseObject TypeKart
        {
            get
            {
                return typeKart;
            }
            set
            {
                SetPropertyValue(nameof(TypeKart), ref typeKart, value);                
            }
        }
       
        private decimal unitAmount;
        public decimal UnitAmount
        {            
            get { return unitAmount; }
            set
            {
                if (SetPropertyValue(nameof(UnitAmount), ref unitAmount, value)&&!IsLoading)
                {
                    UpdateTotal();
                    UpdateDiscount();
                } 
            }
        }
        private decimal amount;
        public decimal Amount
        {
            get { return amount; }
            set { 
                if (SetPropertyValue(nameof(Amount), ref amount, value) && !IsLoading)
                {
                    UpdateTotal();
                    UpdateDiscount();
                }   
            }
        }

        private decimal unitPrice;
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set
            {
                if (SetPropertyValue(nameof(UnitPrice), ref unitPrice, value)&&!IsLoading)
                {
                    UpdateTotal();
                    UpdateDiscount();
                }
            }
        }
        private decimal discount;
        public decimal Discount
        {
            get { return discount; }
            set
            {
                if (SetPropertyValue(nameof(Discount), ref discount, value)&& !IsLoading)
                {
                    UpdateTotal();
                    UpdateDiscount();
                } 
            }
        }

        private decimal total;
        public decimal Total
        {
            get { return total; }
            set
            {
                if (SetPropertyValue(nameof(Total), ref total, value)&&!IsLoading)
                {
                    UpdateTotalSum();
                } 
                
            }
        }

        private decimal discountAmount;
        public decimal DiscountAmount
        {
            get { return discountAmount; }
            set
            {
                if (SetPropertyValue(nameof(DiscountAmount), ref discountAmount, value)&&!IsLoading)
                {
                    UpdateTotalDiscount();
                }
               
            }
        }

        private type typePrp;
        public type TypePrp
        {
            get { return typePrp; }
            set { SetPropertyValue(nameof(TypePrp), ref typePrp, value); }
        }

        [Indexed("BarCode", Unique = true)]
        private decimal barCode;
        [RuleUniqueValue]

        public decimal BarCode
        {
            get { return barCode; }
            set { SetPropertyValue(nameof(BarCode), ref barCode, value); }
        }
        private void UpdateTotal()
        {
            Total= (Amount * UnitPrice * UnitAmount) - (Amount * UnitPrice * UnitAmount) * Discount / 100;
        }
        private void UpdateDiscount()
        {
            DiscountAmount = (Amount * UnitPrice * UnitAmount) * Discount / 100;
        }
        private void UpdateTotalSum()
        {
            
            if (!IsLoading)
            {
                decimal temp=0;
                foreach (var item in SalesInvoice.SalesInvoicesItems)
                {
                    temp += item.Total;
                    SalesInvoice.TotalSum = temp;
                }               
            }            
        }
        private void UpdateTotalDiscount()
        {
            if (!IsLoading)
            {
                decimal temp =0;
                foreach (var item in SalesInvoice.SalesInvoicesItems)
                {
                    temp += item.DiscountAmount;
                    SalesInvoice.TotalDiscount = temp;
                }
            }
        }
    }
}