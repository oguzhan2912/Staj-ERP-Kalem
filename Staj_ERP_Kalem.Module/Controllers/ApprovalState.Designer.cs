
namespace Staj_ERP_Kalem.Module.Controllers
{
    partial class ApprovalState
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
            this.ApprovalAction = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // ApprovalAction
            // 
            this.ApprovalAction.ActionMeaning = DevExpress.ExpressApp.Actions.ActionMeaning.Accept;
            this.ApprovalAction.Caption = "Onaylama";
            this.ApprovalAction.ConfirmationMessage = null;
            this.ApprovalAction.EmptyItemsBehavior = DevExpress.ExpressApp.Actions.EmptyItemsBehavior.None;
            this.ApprovalAction.Id = "ApprovalAction";
            this.ApprovalAction.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.ApprovalAction.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.ApprovalAction.ShowItemsOnClick = true;
            this.ApprovalAction.TargetObjectType = typeof(Staj_ERP_Kalem.Module.BusinessObjects.Current);
            this.ApprovalAction.ToolTip = null;
            this.ApprovalAction.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.ApprovalAction_Execute);
            // 
            // ApprovalState
            // 
            this.Actions.Add(this.ApprovalAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction ApprovalAction;
    }
}
