using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Staj_ERP_Kalem.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Staj_ERP_Kalem.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CurrentFilter : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public CurrentFilter()
        {
            InitializeComponent();
           
        }
       
        protected override void OnActivated()
        {
            base.OnActivated();
            
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
       
        private void FilterAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
             
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(Current));
            string detailViewId = Application.FindDetailViewId(typeof(Current));
            e.ShowViewParameters.CreatedView = Application.CreateDetailView(objectSpace, "Current_Filter_DetailView", true);
            e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
            e.ShowViewParameters.Context = TemplateContext.PopupWindow;
            e.ShowViewParameters.Controllers.Add(Application.CreateController<DialogController>());
            DialogController dialogController = new DialogController();
            //dialogController.AcceptAction.ActionMeaning = AcceptAction_Execute(sender,e);


        }
        private void AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

        }
    }
}

