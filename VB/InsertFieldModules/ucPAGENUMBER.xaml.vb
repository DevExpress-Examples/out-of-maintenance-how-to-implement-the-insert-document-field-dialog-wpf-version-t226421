Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace WpfApplication1.InsertFieldModules
	''' <summary>
	''' Interaction logic for ucPAGENUMBER.xaml
	''' </summary>
	Partial Public Class ucPAGENUMBER
		Inherits UserControl
		Implements IFieldParametersDialog
		Public Sub New()
			InitializeComponent()
			If InsertFieldRichEditHelper.CurrentVariableType = "PAGE" Then
				InitializeListBoxItemsPage()
				tbHyperlink1.Visibility = System.Windows.Visibility.Visible
				tbHyperlink2.Visibility = System.Windows.Visibility.Visible
			Else
				InitializeListBoxItemsNumPages()
				tbHyperlink1.Visibility = System.Windows.Visibility.Collapsed
				tbHyperlink2.Visibility = System.Windows.Visibility.Collapsed
			End If
		End Sub

		Private Sub InitializeListBoxItemsPage()
			Dim listSource As New List(Of FieldAttributeItem)()
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "1, 2, 3, ...", .AttributeValue = "\* Arabic"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "- 1 -, - 2- , - 3- , ...", .AttributeValue = "\* ArabicDash"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "a, b, c, ...", .AttributeValue = "\* alphabetic"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "A, B, C, ...", .AttributeValue = "\* ALPHABETIC"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "i, ii, iii, ...", .AttributeValue = "\* roman"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "I, II, III, ...", .AttributeValue = "\* ROMAN"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "Use Default Numbering", .AttributeValue = "EMPTY"})

			lbeFormats.ItemsSource = listSource
			lbeFormats.DisplayMember = "DisplayName"
			lbeFormats.ValueMember = "AttributeValue"
		End Sub

		Private Sub InitializeListBoxItemsNumPages()
			Dim listSource As New List(Of FieldAttributeItem)()
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "(none)", .AttributeValue = "EMPTY"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "1, 2, 3, ...", .AttributeValue = "\* Arabic"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "a, b, c, ...", .AttributeValue = "\* alphabetic"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "A, B, C, ...", .AttributeValue = "\* ALPHABETIC"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "i, ii, iii, ...", .AttributeValue = "\* roman"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "I, II, III, ...", .AttributeValue = "\* ROMAN"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "1st, 2nd, 3rd, ...", .AttributeValue = "\* Ordinal"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "One, Two, Three, ...", .AttributeValue = "\* CardText"})
			listSource.Add(New FieldAttributeItem() With {.DisplayName = "First, Second, Third, ...", .AttributeValue = "\* OrdText"})

			lbeFormats.ItemsSource = listSource
			lbeFormats.DisplayMember = "DisplayName"
			lbeFormats.ValueMember = "AttributeValue"
		End Sub

		#Region "IFieldParametersDialog Members"

		Public Function GenerateFieldParametersString() As String Implements IFieldParametersDialog.GenerateFieldParametersString
			Dim resultString As String = ""
			If lbeFormats.EditValue IsNot Nothing AndAlso lbeFormats.EditValue.ToString() <> "EMPTY" Then
				resultString = lbeFormats.EditValue.ToString()
			End If
			Return resultString
		End Function

		#End Region

		Private Sub Hyperlink_RequestNavigate_1(ByVal sender As Object, ByVal e As RequestNavigateEventArgs)
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri))
			e.Handled = True
		End Sub
	End Class
End Namespace
