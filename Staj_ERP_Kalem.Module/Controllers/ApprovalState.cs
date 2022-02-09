using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Staj_ERP_Kalem.Module.BusinessObjects;
using DevExpress.Persistent.Base.General;
using System.Collections;

namespace Staj_ERP_Kalem.Module.Controllers
{
    
    public partial class ApprovalState : ViewController
    {
        private ChoiceActionItem setApprovalItem;
        public ApprovalState()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            //Approvaldan item ürettik.
            setApprovalItem = new ChoiceActionItem(CaptionHelper.GetMemberCaption(typeof(Current), "Approval"), null);
            //Action kısmı itemlerini ekliyor.
            ApprovalAction.Items.Add(setApprovalItem);
            //Enum'daki değerler ile dolduruyoruz.
            FillItemWithEnumValues(setApprovalItem, typeof(Current.Approval));
        }
        private void FillItemWithEnumValues(ChoiceActionItem parentItem, System.Type enumType)
        {
            foreach (object current in Enum.GetValues(enumType))
            {
                EnumDescriptor ed = new EnumDescriptor(enumType);
                ChoiceActionItem item = new ChoiceActionItem(ed.GetCaption(current), current);
                //item.ImageName = ImageLoader.Instance.GetEnumValueImageName(current);
                parentItem.Items.Add(item);
            }
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
           

        private void ApprovalAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = View is ListView ?
              Application.CreateObjectSpace(typeof(Current)) : View.ObjectSpace; // Bu kısmı sor.
            ArrayList objectsToProcess = new ArrayList(e.SelectedObjects); // Görünen viewdeki objelere ulaşım sağladık.
            if (e.SelectedChoiceActionItem.ParentItem == setApprovalItem)
            {
                foreach (Object obj in objectsToProcess)
                {
                    Current objInNewObjectSpace = (Current)objectSpace.GetObject(obj);
                    objInNewObjectSpace.ApprovalPrp = (Current.Approval)e.SelectedChoiceActionItem.Data;
                }
            }
            if (View is DetailView && ((DetailView)View).ViewEditMode == ViewEditMode.View)
            {
                objectSpace.CommitChanges();
            }
            if (View is ListView)
            {
                objectSpace.CommitChanges();
                View.ObjectSpace.Refresh();
            }
        }
    }
}
