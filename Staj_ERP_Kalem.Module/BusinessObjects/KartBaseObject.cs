using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Staj_ERP_Kalem.Module.BusinessObjects
{
    [DefaultClassOptions]
    
    public class KartBaseObject : BaseObject
    { 
        public KartBaseObject(Session session): base(session)
        {
            
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private bool isDefaultPropertyAttributeInit;
        private XPMemberInfo defaultPropertyMemberInfo;
        public override string ToString()
        {
            if (!isDefaultPropertyAttributeInit)
            {
                DefaultPropertyAttribute attrib = XafTypesInfo.Instance.FindTypeInfo(
                    GetType()).FindAttribute<DefaultPropertyAttribute>();
                if (attrib != null)
                    defaultPropertyMemberInfo = ClassInfo.FindMember(attrib.Name);
                isDefaultPropertyAttributeInit = true;
            }
            if (defaultPropertyMemberInfo != null)
            {
                object obj = defaultPropertyMemberInfo.GetValue(this);
                if (obj != null)
                    return obj.ToString();
            }
            return base.ToString();
        }

        private int code;
        public int Code
        {
            get { return code; }
            set
            {
                SetPropertyValue(nameof(Code), ref code, value);
                
            }
        }
        private string name = " ";
        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }

    }
}