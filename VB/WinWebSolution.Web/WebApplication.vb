Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp

Namespace DcDemo.Web
	Public Class WinWebSolutionAspNetApplication
		Inherits WebApplication
		Private systemModule1 As DevExpress.ExpressApp.SystemModule.SystemModule
		Private webSystemModule1 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
		Private validationModule1 As DevExpress.ExpressApp.Validation.ValidationModule
		Private module1 As WinWebSolution.Module.Web.WinWebSolutionAspNetModule
		Private module2 As WinWebSolution.Module.WinWebSolutionModule

		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub InitializeComponent()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(WinWebSolutionAspNetApplication))
			Me.systemModule1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
			Me.webSystemModule1 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
			Me.validationModule1 = New DevExpress.ExpressApp.Validation.ValidationModule()
			Me.module2 = New WinWebSolution.Module.WinWebSolutionModule()
			Me.module1 = New WinWebSolution.Module.Web.WinWebSolutionAspNetModule()
			CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.ApplicationName = "WinWebSolution"
			Me.Modules.Add(Me.systemModule1)
			Me.Modules.Add(Me.webSystemModule1)
			Me.Modules.Add(Me.validationModule1)
			Me.Modules.Add(Me.module2)
			Me.Modules.Add(Me.module1)
'			Me.DatabaseVersionMismatch += New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(Me.DcDemoWebApplication_DatabaseVersionMismatch)
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
		Private Sub DcDemoWebApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
			e.Updater.Update()
			e.Handled = True
		End Sub
	End Class
End Namespace
