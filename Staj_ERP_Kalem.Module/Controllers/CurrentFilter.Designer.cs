
namespace Staj_ERP_Kalem.Module.Controllers
{
    partial class CurrentFilter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.ExpressApp.Actions.SimpleAction FilterAction;
            FilterAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // FilterAction
            // 
            FilterAction.Caption = "Filter";
            FilterAction.Category = "FullTextSearch";
            FilterAction.ConfirmationMessage = null;
            FilterAction.Id = "CurrentFilter";
            FilterAction.TargetObjectType = typeof(Staj_ERP_Kalem.Module.BusinessObjects.Current);
            FilterAction.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            FilterAction.ToolTip = null;
            FilterAction.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            FilterAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.FilterAction_Execute);
            // 
            // CurrentFilter
            // 
            this.Actions.Add(FilterAction);
            this.TargetObjectType = typeof(Staj_ERP_Kalem.Module.BusinessObjects.Current);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion
    }
}
