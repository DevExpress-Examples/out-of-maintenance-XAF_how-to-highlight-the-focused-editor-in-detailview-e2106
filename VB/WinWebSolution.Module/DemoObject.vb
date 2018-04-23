Imports System
Imports System.ComponentModel
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace WinWebSolution.Module
    <DefaultClassOptions> _
    Public Class DemoObject
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Property Name() As String
        Public Property StringProperty() As String
        Public Property IntegerProperty() As Integer
        Public Property BooleanProperty() As Boolean
        Public Property LookupReferenceProperty() As DemoObject
        <Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)> _
        Public Property AggregatedReferenceProperty() As DemoObject
    End Class
End Namespace
