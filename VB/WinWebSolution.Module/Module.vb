Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model


Namespace WinWebSolution.Module
	Public NotInheritable Partial Class WinWebSolutionModule
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Overrides Sub ExtendModelInterfaces(ByVal extenders As DevExpress.ExpressApp.Model.ModelInterfaceExtenders)
			MyBase.ExtendModelInterfaces(extenders)
			extenders.Add(Of IModelOptions, IModelOptionsHighlightFocusedLayoutItem)()
			extenders.Add(Of IModelDetailView, IModelDetailViewHighlightFocusedLayoutItem)()
		End Sub
	End Class
	Public Interface IModelOptionsHighlightFocusedLayoutItem
	Inherits IModelNode
		<DefaultValue(True), Category("Behavior")> _
		Property EnableHighlightFocusedLayoutItem() As Boolean
	End Interface
	Public Interface IModelDetailViewHighlightFocusedLayoutItem
	Inherits IModelNode
		<Category("Behavior")> _
		Property HighlightFocusedLayoutItem() As Boolean
	End Interface
	<DomainLogic(GetType(IModelDetailViewHighlightFocusedLayoutItem))> _
	Public Class ModelDetailViewHighlightFocusedLayoutItemLogic
		Public Shared Function Get_HighlightFocusedLayoutItem(ByVal model As IModelDetailViewHighlightFocusedLayoutItem) As Boolean
			If model IsNot Nothing Then
				Return (CType(model.Application.Options, IModelOptionsHighlightFocusedLayoutItem)).EnableHighlightFocusedLayoutItem
			End If
			Return False
		End Function
	End Class
End Namespace
