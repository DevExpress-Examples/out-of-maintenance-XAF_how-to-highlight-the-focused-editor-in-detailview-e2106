using System;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp;

namespace DcDemo.Web {
    public class WinWebSolutionAspNetApplication : WebApplication {
		private DevExpress.ExpressApp.SystemModule.SystemModule systemModule1;
		private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule webSystemModule1;
		private DevExpress.ExpressApp.Validation.ValidationModule validationModule1;
		private WinWebSolution.Module.Web.WinWebSolutionAspNetModule module1;
        private WinWebSolution.Module.WinWebSolutionModule module2;
    
		public WinWebSolutionAspNetApplication() {
			InitializeComponent();
		}
        private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinWebSolutionAspNetApplication));
			this.systemModule1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
			this.webSystemModule1 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
			this.validationModule1 = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.module2 = new WinWebSolution.Module.WinWebSolutionModule();
            this.module1 = new WinWebSolution.Module.Web.WinWebSolutionAspNetModule();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.ApplicationName = "WinWebSolution";
			this.Modules.Add(this.systemModule1);
			this.Modules.Add(this.webSystemModule1);
			this.Modules.Add(this.validationModule1);
			this.Modules.Add(this.module2);
			this.Modules.Add(this.module1);
			this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.DcDemoWebApplication_DatabaseVersionMismatch);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        private void DcDemoWebApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        }
	}
}
