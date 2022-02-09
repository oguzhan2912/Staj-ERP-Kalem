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

namespace Staj_ERP_Kalem.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ProductPopUpFilter : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public ProductPopUpFilter()
        {
            InitializeComponent();
            PopupWindowShowAction popupWindowShowAction = new PopupWindowShowAction(this, "Yeni Sekmede Aç", PredefinedCategory.Edit);
            popupWindowShowAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            popupWindowShowAction.TargetObjectsCriteria = "Not IsNewObject(This)";
            popupWindowShowAction.CustomizePopupWindowParams += popupWindowShowAction_CustomizePopupWindowParams;
        }
        void popupWindowShowAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {

            IObjectSpace newObjectSpace = Application.CreateObjectSpace(View.ObjectTypeInfo.Type);
            Object objectToShow = newObjectSpace.GetObject(View.CurrentObject);
            if (objectToShow != null)
            {
                DetailView createdView = Application.CreateDetailView(newObjectSpace, objectToShow);
                createdView.ViewEditMode = ViewEditMode.Edit;
                e.View = createdView;
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
        DetailView dv = null;
        private void proPopFilter_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

        }
    }
}
