Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Web.Editors
Imports DevExpress.ExpressApp.Web.Editors.ASPx
Imports DevExpress.Web

Namespace WinWebSolution.Module.Web
    Public Class WebHighlightFocusedLayoutItemDetailViewController
        Inherits HighlightFocusedLayoutItemDetailViewControllerBase

        Public Property HighlightParent() As Boolean
        Public Property BackColor() As String
        Public Sub New()
            HighlightParent = True
            BackColor = "#C9E4F0"
        End Sub
        'Access Web property editors and their controls in DetailView as per https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112729
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            For Each item As WebPropertyEditor In View.GetItems(Of WebPropertyEditor)()
                If item.Editor IsNot Nothing Then
                    ApplyFocusedStyle(item)
                Else
                    AddHandler item.ControlCreated, Sub(s, e) ApplyFocusedStyle(s)
                End If
            Next item
        End Sub
        'Access the underlying controls of each WebPropertyEditor. Special handling is required for look editors due to their complex inner structure.
        Protected Overrides Sub ApplyFocusedStyle(ByVal element As Object)
            If View.ViewEditMode = ViewEditMode.Edit Then
                If TypeOf element Is ASPxLookupPropertyEditor Then
                    ApplyFocusedStyleCore(DirectCast(element, ASPxLookupPropertyEditor).DropDownEdit.DropDown)
                    ApplyFocusedStyleCore(DirectCast(element, ASPxLookupPropertyEditor).FindEdit.Editor)
                ElseIf TypeOf element Is WebPropertyEditor Then
                    ApplyFocusedStyleCore(TryCast(DirectCast(element, WebPropertyEditor).Editor, ASPxWebControl))
                End If
            End If
        End Sub
        'Configure the client side event handlers for the control based on the scripts defined in the E2106.js file.
        Private Sub ApplyFocusedStyleCore(ByVal dxControl As ASPxWebControl)
            If dxControl IsNot Nothing Then
                dxControl.SetClientSideEventHandler("GotFocus", String.Format("function(s,e){{e.highlightParent = {0};e.backColor = '{1}';E2106.HighlightFocusedLayoutItem.onGotFocus(s,e);}}", HighlightParent.ToString().ToLower(), BackColor))
                dxControl.SetClientSideEventHandler("LostFocus", String.Format("function(s,e){{e.highlightParent = {0};E2106.HighlightFocusedLayoutItem.onLostFocus(s,e);}}", HighlightParent.ToString().ToLower()))
            End If
        End Sub
    End Class
End Namespace