Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp

Namespace WinWebSolution.Module
	Public MustInherit Class HighlightFocusedLayoutItemDetailViewControllerBase
		Inherits ViewController(Of DetailView)
		Public Const HighlightFocusedLayoutItemAttributeName As String = "HighlightFocusedLayoutItem"
		Public Const EnableHighlightFocusedLayoutItemAttributeName As String = "EnableHighlightFocusedLayoutItem"
		Public Const ActiveKeyHighlightFocusedEditor As String = "HighlightFocusedLayoutItem"
		Protected Overrides Sub OnViewChanging(ByVal view As View)
			MyBase.OnViewChanging(view)
			Dim dv As DetailView = TryCast(view, DetailView)
			If dv IsNot Nothing Then
				Active(ActiveKeyHighlightFocusedEditor) = (CType(dv.Model, IModelDetailViewHighlightFocusedLayoutItem)).HighlightFocusedLayoutItem
			End If
		End Sub
		Protected MustOverride Sub ApplyFocusedStyle(ByVal element As Object)
	End Class
End Namespace