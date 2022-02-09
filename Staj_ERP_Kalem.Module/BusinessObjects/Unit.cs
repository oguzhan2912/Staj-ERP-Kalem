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
   
    public class Unit : BaseObject
    {
        public Unit(Session session): base(session){ }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private UnitSet unitSet;
        [Association("UnitSet-Units")]
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

        [Association("Unit-SalesInvoiceItems")]
        public XPCollection<SalesInvoiceItem> SalesInvoiceItems
        {
            get
            {
                return GetCollection<SalesInvoiceItem>(nameof(SalesInvoiceItems));
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

        // Bool oluşturma.
        private bool basicUnits;
        [CaptionsForBoolValues("Evet", "Hayır")]
        public bool BasicUnits
        {
            get
            {
                return basicUnits;
            }
            set
            {

                if (SetPropertyValue(nameof(BasicUnits), ref basicUnits, value))
                { //Session bitmeden çalıştırmak için.
                    if (!IsLoading && !IsSaving)
                    {
                        foreach (var item in UnitSet.Units)
                        {
                            if (this != item)// Seçtiğimiz satırda ise içeri girer ve diğerlerini hayır yapar.
                            {
                                item.basicUnits = false;
                            }
                            UnitSet.BasicUnitName = this;

                            //Düz formül hesabı.
                            item.Formula = "1 " + item.Name + " = " + Convert.ToString(Math.Ceiling((item.BasicUnitRatios / this.BasicUnitRatios * 100) / 100)) + " " + this.Name;
                            item.TempFormula = Math.Ceiling((item.BasicUnitRatios / this.BasicUnitRatios * 100) / 100);
                        }
                    }
                }
            }
        }
        private decimal tempFormula;
        public decimal TempFormula
        {
            get { return tempFormula; }
            set { SetPropertyValue(nameof(TempFormula), ref tempFormula, value); }
        }

        private decimal basicUnitRatios;
        public decimal BasicUnitRatios
        {
            get
            {
                return basicUnitRatios;
            }
            set
            {
                SetPropertyValue(nameof(BasicUnitRatios), ref basicUnitRatios, value);
            }
        }
        private string formula;
        public string Formula
        {

            get
            {
                return formula;
            }
            set
            {

                SetPropertyValue(nameof(Formula), ref formula, value);
            }
        }

    }
}