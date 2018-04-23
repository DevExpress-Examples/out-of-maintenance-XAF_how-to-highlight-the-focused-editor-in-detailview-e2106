Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports DevExpress.Web.ASPxClasses
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Web.Editors
Imports DevExpress.ExpressApp.Web.Editors.ASPx

Namespace WinWebSolution.Module.Web
	Public Class HighlightFocusedLayoutItemDetailViewController
		Inherits HighlightFocusedLayoutItemDetailViewControllerBase
		Private Const ClientSideEventHandlerFunctionFormat As String = "function(s,e){{{0}}}"
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			If View.ViewEditMode = ViewEditMode.Edit Then
				For Each item As WebPropertyEditor In View.GetItems(Of WebPropertyEditor)()
					If item.Editor IsNot Nothing Then
						ApplyFocusedStyle(item)
					Else
						AddHandler item.ControlCreated, Function(s, e) AnonymousMethod1(s, e)
					End If
				Next item
			End If
		End Sub
		
		Private Function AnonymousMethod1(ByVal s As Object, ByVal e As Object) As Boolean
			ApplyFocusedStyle(s)
			Return True
		End Function
		Protected Overrides Sub ApplyFocusedStyle(ByVal element As Object)
			If TypeOf element Is ASPxLookupPropertyEditor Then
				ApplyFocusedStyleCore((CType(element, ASPxLookupPropertyEditor)).DropDownEdit.DropDown)
				ApplyFocusedStyleCore((CType(element, ASPxLookupPropertyEditor)).FindEdit.TextBox)
			ElseIf TypeOf element Is WebPropertyEditor Then
				ApplyFocusedStyleCore(TryCast((CType(element, WebPropertyEditor)).Editor, ASPxWebControl))
			End If
		End Sub
		Private Sub ApplyFocusedStyleCore(ByVal dxControl As ASPxWebControl)
			If dxControl IsNot Nothing Then
				Dim loadEventHandler As EventHandler = Function(s, e) AnonymousMethod2(s, e)
				Dim disposedEventHandler As EventHandler = Nothing
				disposedEventHandler = Function(s, e) AnonymousMethod3(s, e, disposedEventHandler, loadEventHandler)
				AddHandler dxControl.Disposed, disposedEventHandler
				AddHandler dxControl.Load, loadEventHandler
			End If
		End Sub
		
		Private Function AnonymousMethod2(ByVal s As Object, ByVal e As Object) As Boolean
			Dim control As ASPxWebControl = CType(s, ASPxWebControl)
			AddEventHandlerSafe(control, "Init", "window.initEditor(s,e);")
			AddEventHandlerSafe(control, "GotFocus", "window.gotFocusEditor(s,e);")
			Return True
		End Function
		
		Private Function AnonymousMethod3(ByVal s As Object, ByVal e As Object, ByVal disposedEventHandler As EventHandler, ByVal loadEventHandler As EventHandler) As EventHandler
			Dim control As ASPxWebControl = CType(s, ASPxWebControl)
			RemoveHandler control.Disposed, disposedEventHandler
			RemoveHandler control.Load, loadEventHandler
		End Function
		Private Shared Sub AddEventHandlerSafe(ByVal control As ASPxWebControl, ByVal eventName As String, ByVal handler As String)
			Dim existingHandler As String = control.GetClientSideEventHandler(eventName)
			If String.IsNullOrEmpty(existingHandler) Then
				control.SetClientSideEventHandler(eventName, String.Format(ClientSideEventHandlerFunctionFormat, handler))
			Else
				existingHandler = String.Format("{0}{1}" & Constants.vbCrLf & "}}", existingHandler.Substring(0, existingHandler.LastIndexOf("}"c)), handler)
				control.SetClientSideEventHandler(eventName, existingHandler)
			End If
		End Sub
	End Class
End Namespace