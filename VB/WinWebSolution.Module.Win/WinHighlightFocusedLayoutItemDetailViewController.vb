Imports DevExpress.XtraLayout

Namespace WinWebSolution.Module.Win
    Public Class WinHighlightFocusedLayoutItemDetailViewController
        Inherits HighlightFocusedLayoutItemDetailViewControllerBase

        Protected Overrides Sub OnViewControlsCreated()
            MyBase.OnViewControlsCreated()
            ApplyFocusedStyle(View.LayoutManager.Container)
        End Sub
        Protected Overrides Sub ApplyFocusedStyle(ByVal control As Object)
            Dim layoutControl As LayoutControl = TryCast(control, LayoutControl)
            If layoutControl IsNot Nothing Then
                layoutControl.BeginUpdate()
                layoutControl.OptionsView.HighlightFocusedItem = True
                layoutControl.OptionsView.AllowItemSkinning = True
                layoutControl.EndUpdate()
            End If
        End Sub
    End Class
End Namespace