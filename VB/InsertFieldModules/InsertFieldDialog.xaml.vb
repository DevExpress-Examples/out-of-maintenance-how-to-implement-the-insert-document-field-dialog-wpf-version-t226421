Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Core
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes

Namespace WpfApplication1.InsertFieldModules
	''' <summary>
	''' Interaction logic for InsertFieldDialog.xaml
	''' </summary>
	Partial Public Class InsertFieldDialog
		Inherits DXDialog
		Private privateDocFieldCollection As ObservableCollection(Of DocFieldInfo)
		Public Property DocFieldCollection() As ObservableCollection(Of DocFieldInfo)
			Get
				Return privateDocFieldCollection
			End Get
			Private Set(ByVal value As ObservableCollection(Of DocFieldInfo))
				privateDocFieldCollection = value
			End Set
		End Property
		Public Sub New()
			InitializeComponent()
			DocFieldCollection = New ObservableCollection(Of DocFieldInfo)()
			DocFieldCollection.Add(New DocFieldInfo() With {.FieldName = "DOCVARIABLE", .PropertiesControlName = "ucDOCVARIABLE"})
			DocFieldCollection.Add(New DocFieldInfo() With {.FieldName = "PAGE", .PropertiesControlName = "ucPAGENUMBER"})
			DocFieldCollection.Add(New DocFieldInfo() With {.FieldName = "NUMPAGES", .PropertiesControlName = "ucPAGENUMBER"})
			DocFieldCollection.Add(New DocFieldInfo() With {.FieldName = "CREATEDATE", .PropertiesControlName = "ucCREATEDATE"})
			DocFieldCollection.Add(New DocFieldInfo() With {.FieldName = "DATE", .PropertiesControlName = "ucCREATEDATE"})
			DocFieldCollection.Add(New DocFieldInfo() With {.FieldName = "TIME", .PropertiesControlName = "ucCREATEDATE"})
			DocFieldCollection.Add(New DocFieldInfo() With {.FieldName = "IF", .PropertiesControlName = "ucIFFIELD"})

			lbeFields.ItemsSource = DocFieldCollection
			AddHandler Me.Closing, AddressOf InsertFieldDialog_Closing
			AddHandler FieldsNavigationFrame.Navigated, AddressOf FieldsNavigationFrame_Navigated
		End Sub

		Private Sub FieldsNavigationFrame_Navigated(ByVal sender As Object, ByVal e As DevExpress.Xpf.WindowsUI.Navigation.NavigationEventArgs)
			InsertFieldRichEditHelper.CurrentParametersDialog = TryCast(FieldsNavigationFrame.Content, IFieldParametersDialog)
		End Sub

		Private Sub InsertFieldDialog_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
			e.Cancel = True
			Me.Visibility = Visibility.Hidden
		End Sub

		Private Sub ListBoxEdit_EditValueChanged(ByVal sender As Object, ByVal e As DevExpress.Xpf.Editors.EditValueChangedEventArgs)
			InsertFieldRichEditHelper.CurrentVariableType = e.NewValue.ToString()
			FieldsNavigationFrame.Navigate((TryCast((TryCast(e.Source, DevExpress.Xpf.Editors.ListBoxEdit)).SelectedItem, DocFieldInfo)).PropertiesControlName)
		End Sub
	End Class

	Public Class DocFieldInfo
		Private privateFieldName As String
		Public Property FieldName() As String
			Get
				Return privateFieldName
			End Get
			Set(ByVal value As String)
				privateFieldName = value
			End Set
		End Property
		Private privatePropertiesControlName As String
		Public Property PropertiesControlName() As String
			Get
				Return privatePropertiesControlName
			End Get
			Set(ByVal value As String)
				privatePropertiesControlName = value
			End Set
		End Property
	End Class
End Namespace
