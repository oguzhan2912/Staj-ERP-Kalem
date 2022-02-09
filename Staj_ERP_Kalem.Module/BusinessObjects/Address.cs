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
    [NavigationItem("Tanım")]
    public class Address : BaseObject
    { 
        public Address(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        [Association("Address-Currents")]
        // One to Many kısmının Many kısmı.
        public XPCollection<Current> Currents
        {
            get { return GetCollection<Current>(nameof(Currents)); }
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
        private string code;
        public string Code
        {
            get { return code; }
            set
            {
                SetPropertyValue(nameof(Code), ref code, value);
            }

        }

        private string openAdress;
        public string OpenAdress
        {
            get { return openAdress; }
            set
            {

                SetPropertyValue(nameof(OpenAdress), ref openAdress, value);
            }
        }

        private string phoneNum;
        public string PhoneNum
        {
            get { return phoneNum; }
            set
            {

                SetPropertyValue(nameof(PhoneNum), ref phoneNum, value);
            }
        }
    }
}