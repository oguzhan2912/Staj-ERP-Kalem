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
using DevExpress.ExpressApp.ConditionalAppearance;

namespace Staj_ERP_Kalem.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Tanım")]
    public class Current : BaseObject
    {
        public Current(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        [Association("Current-SalesInvoices")]
        //one kısmı
        public XPCollection<SalesInvoice> SalesInvoices
        {
            get
            {
                return GetCollection<SalesInvoice>(nameof(SalesInvoices));
            }
        }

        private Address address;
        [Association("Address-Currents")]
        // One to Many bağlantısının One kısmı.
        public Address Address
        {
            get { return address; }
            set
            {
                SetPropertyValue(nameof(Address), ref address, value);
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
        // geneler geçer bir property.
        private string code;
        public string Code
        {
            get { return code; }
            set
            {
                SetPropertyValue(nameof(Code), ref code, value);
            }
        }
        private string mail;
        public string Mail
        {
            get { return mail; }
            set
            {
                SetPropertyValue(nameof(Mail), ref mail, value);
            }
        }

        private string comment;
        public string Comment
        {
            get { return comment; }
            set
            {
                SetPropertyValue(nameof(Comment), ref comment, value);
            }
        }

        private decimal totalCredit;
        public decimal TotalCredit
        {
            get { return totalCredit; }
            set { SetPropertyValue(nameof(TotalCredit), ref totalCredit, value); }
        }

        //Enum Oluşturma.
        private Approval approvalPrp;
        public Approval ApprovalPrp
        {
            get { return approvalPrp; }
            set
            {
                SetPropertyValue(nameof(ApprovalPrp), ref approvalPrp, value);
            }
        }



        public enum Approval { Onaylandı = 0, Onaylanmadı = 1, Bloklandı = 2 }
        public enum ListviewCurrent { CariHareketleri = 0, CariHareketeriDetay = 1 }
    }
}