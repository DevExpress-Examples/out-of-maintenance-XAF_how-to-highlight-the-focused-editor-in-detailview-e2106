Imports System.ComponentModel
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace WinWebSolution.Module
	<DefaultClassOptions> _
	Public Class HighlightFocusedLayoutItemObject
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Public Property Name() As String
			Get
				Return GetPropertyValue(Of String)("Name")
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("Name", value)
			End Set
		End Property
		Public Property StringProperty() As String
			Get
				Return GetPropertyValue(Of String)("StringProperty")
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("StringProperty", value)
			End Set
		End Property
		Public Property IntegerProperty() As Integer
			Get
				Return GetPropertyValue(Of Integer)("IntegerProperty")
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("IntegerProperty", value)
			End Set
		End Property
		Public Property BooleanProperty() As Boolean
			Get
				Return GetPropertyValue(Of Boolean)("BooleanProperty")
			End Get
			Set(ByVal value As Boolean)
				SetPropertyValue(Of Boolean)("BooleanProperty", value)
			End Set
		End Property
		Public Property ReferencedProperty() As HighlightFocusedLayoutItemObject
			Get
				Return GetPropertyValue(Of HighlightFocusedLayoutItemObject)("ReferencedProperty")
			End Get
			Set(ByVal value As HighlightFocusedLayoutItemObject)
				SetPropertyValue(Of HighlightFocusedLayoutItemObject)("ReferencedProperty", value)
			End Set
		End Property
	End Class
End Namespace
