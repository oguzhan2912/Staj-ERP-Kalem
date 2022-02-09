
namespace Staj_ERP_Kalem.Module.Controllers
{
    partial class ProductPopUpFilter
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
            this.proPopFilter = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // proPopFilter
            // 
            this.proPopFilter.AcceptButtonCaption = null;
            this.proPopFilter.CancelButtonCaption = null;
            this.proPopFilter.Caption = "Filtre";
            this.proPopFilter.ConfirmationMessage = null;
            this.proPopFilter.Id = "PopUpProductFilter";
            this.proPopFilter.TargetObjectType = typeof(Staj_ERP_Kalem.Module.BusinessObjects.Product);
            this.proPopFilter.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.proPopFilter.ToolTip = null;
            this.proPopFilter.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.proPopFilter.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.proPopFilter_Execute);
            // 
            // ProductPopUpFilter
            // 
            this.Actions.Add(this.proPopFilter);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction proPopFilter;
    }
}
