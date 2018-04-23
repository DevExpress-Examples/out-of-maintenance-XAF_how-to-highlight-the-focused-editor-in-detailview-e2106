Imports System.Web.UI
Imports DevExpress.Web.ASPxClasses
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Web

Namespace WinWebSolution.Module.Web
	Public Class HighlightFocusedLayoutItemDetailViewController
		Inherits HighlightFocusedLayoutItemDetailViewControllerBase
		Private Const ScriptKey As String = "assignStyleScriptKey"
		Private Const ScriptFunction As String = "" & ControlChars.CrLf & "                    window.lastFocusedElement = undefined;" & ControlChars.CrLf & "                    window.isLayoutItemRow = function(obj) {" & ControlChars.CrLf & "                        return obj.className == ""Item"" && obj.tagName == ""DIV"";" & ControlChars.CrLf & "                    };" & ControlChars.CrLf & "                    window.isValid = function (obj) {" & ControlChars.CrLf & "                        return obj != null && obj != undefined; " & ControlChars.CrLf & "                    };" & ControlChars.CrLf & "                    window.assignStyle = function (element, color){" & ControlChars.CrLf & "                        var curr = element;" & ControlChars.CrLf & "                        while (isValid(curr) && !isLayoutItemRow(curr)){" & ControlChars.CrLf & "                            curr = curr.parentNode;" & ControlChars.CrLf & "                        };" & ControlChars.CrLf & "                        if (isValid(curr)) " & ControlChars.CrLf & "                            curr.style.backgroundColor = color;" & ControlChars.CrLf & "                    };"
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			If View.ViewEditMode = ViewEditMode.Edit Then
				For Each item As ViewItem In View.Items
                    AddHandler item.ControlCreated, AddressOf OnItemControlCreated
				Next item
			End If
			WebWindow.CurrentRequestWindow.RegisterClientScript(ScriptKey, ScriptFunction)
        End Sub
        Private Sub OnItemControlCreated(ByVal sender As Object, ByVal e As EventArgs)
            AssignStyle((CType(sender, ViewItem)).Control)
        End Sub
		Protected Overrides Sub AssignStyle(ByVal control As Object)
			For Each dxEditor As ASPxWebControl In FindNestedControls(Of ASPxWebControl)(TryCast(control, Control))
				Dim functionInit As String = "" & ControlChars.CrLf & "                function (s, e){" & ControlChars.CrLf & "                    if (s.focused) {" & ControlChars.CrLf & "                        window.assignStyle(window.lastFocusedElement = s.GetMainElement(), ""#C9E4F0"");" & ControlChars.CrLf & "                    }" & ControlChars.CrLf & "                }"
				Dim functionGotFocus As String = "" & ControlChars.CrLf & "                function (s, e){" & ControlChars.CrLf & "                    window.assignStyle(window.lastFocusedElement, """");" & ControlChars.CrLf & "                    window.assignStyle(window.lastFocusedElement = s.GetMainElement(), ""#C9E4F0"");" & ControlChars.CrLf & "                }"
				If String.IsNullOrEmpty(dxEditor.GetClientSideEventHandler("Init")) Then
					dxEditor.SetClientSideEventHandler("Init", functionInit)
				End If
				If String.IsNullOrEmpty(dxEditor.GetClientSideEventHandler("GotFocus")) Then
					dxEditor.SetClientSideEventHandler("GotFocus", functionGotFocus)
				End If
			Next dxEditor
        End Sub
        Private Shared Function FindNestedControls(Of TNestedControl As Control)(ByVal container As Control) As IEnumerable(Of TNestedControl)
            Dim list As New List(Of TNestedControl)()
            If container IsNot Nothing AndAlso container.Controls IsNot Nothing Then
                For Each item As Control In container.Controls
                    If TypeOf item Is TNestedControl Then
                        list.Add(CType(item, TNestedControl))
                    End If
                    For Each child As TNestedControl In FindNestedControls(Of TNestedControl)(item)
                        list.Add(child)
                    Next child
                Next item
            End If
            Return list
        End Function
    End Class
End Namespace