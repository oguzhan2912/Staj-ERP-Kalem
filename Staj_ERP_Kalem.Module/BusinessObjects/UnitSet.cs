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

    public class UnitSet : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public UnitSet(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        [Association("UnitSet-Units")]

        public XPCollection<Unit> Units
        {
            get
            {
                return GetCollection<Unit>(nameof(Units));
            }
        }
        [Association("UnitSet-Products")]
        public XPCollection<Product> Products
        {
            get
            {
                return GetCollection<Product>(nameof(Products));
            }
        }

        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {

                SetPropertyValue(nameof(Name), ref name, value);

            }
        }
        string code;
        public string Code
        {
            get
            {
                return code;
            }
            set
            {

                SetPropertyValue(nameof(Code), ref code, value);

            }
        }
        private Unit basicUnitName;
        public Unit BasicUnitName
        {
            get
            {
                return basicUnitName;
            }
            set
            {
                SetPropertyValue(nameof(BasicUnitName), ref basicUnitName, value);
            }
        }
    }
}