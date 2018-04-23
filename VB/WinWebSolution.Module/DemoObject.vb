Imports Microsoft.VisualBasic
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
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateStringProperty As String
		Public Property StringProperty() As String
			Get
				Return privateStringProperty
			End Get
			Set(ByVal value As String)
				privateStringProperty = value
			End Set
		End Property
		Private privateIntegerProperty As Integer
		Public Property IntegerProperty() As Integer
			Get
				Return privateIntegerProperty
			End Get
			Set(ByVal value As Integer)
				privateIntegerProperty = value
			End Set
		End Property
		Private privateBooleanProperty As Boolean
		Public Property BooleanProperty() As Boolean
			Get
				Return privateBooleanProperty
			End Get
			Set(ByVal value As Boolean)
				privateBooleanProperty = value
			End Set
		End Property
		Private privateLookupReferenceProperty As DemoObject
		Public Property LookupReferenceProperty() As DemoObject
			Get
				Return privateLookupReferenceProperty
			End Get
			Set(ByVal value As DemoObject)
				privateLookupReferenceProperty = value
			End Set
		End Property
		Private privateAggregatedReferenceProperty As DemoObject
		<Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)> _
		Public Property AggregatedReferenceProperty() As DemoObject
			Get
				Return privateAggregatedReferenceProperty
			End Get
			Set(ByVal value As DemoObject)
				privateAggregatedReferenceProperty = value
			End Set
		End Property
	End Class
End Namespace
