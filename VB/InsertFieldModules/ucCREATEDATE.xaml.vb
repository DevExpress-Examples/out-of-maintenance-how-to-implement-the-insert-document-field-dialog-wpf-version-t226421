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
	''' Interaction logic for ucCREATEDATE.xaml
	''' </summary>
	Partial Public Class ucCREATEDATE
		Inherits UserControl
		Implements IFieldParametersDialog
		Public Sub New()
			InitializeComponent()
			InitializeListBoxItemsDateFormats()
		End Sub

		Private Sub InitializeListBoxItemsDateFormats()
			Dim dateTimeFormats() As String = { "dd.MM.yyyy", "dddd, d. MMMM yyyy", "d. MMMM yyyy", "dd.MM.yy", "yyyy-MM-dd", "yy-MM-dd", "dd/MM/yyyy", "dd. MMM. yyyy", "dd/MM/yy", "MMMM yy", "MMM-yy", "dd.MM.yyyy HH:mm", "dd.MM.yyyy HH:mm:ss", "h:mm am/pm", "h:mm:ss am/pm", "HH:mm", "HH:mm:ss" }

			Dim listSource As New List(Of FieldAttributeItem)()
			For i As Integer = 0 To dateTimeFormats.Length - 1
				listSource.Add(New FieldAttributeItem() With {.DisplayName = DateTime.Now.ToString(dateTimeFormats(i).Replace("am/pm", "tt")), .AttributeValue = dateTimeFormats(i)})
			Next i

			lbeFormats.ItemsSource = listSource
			lbeFormats.DisplayMember = "DisplayName"
			lbeFormats.ValueMember = "AttributeValue"
		End Sub


		#Region "IFieldParametersDialog Members"

		Public Function GenerateFieldParametersString() As String Implements IFieldParametersDialog.GenerateFieldParametersString
			Dim resultString As String = ""
			If teCurrentFormat.Text.Trim() <> "" Then
				resultString = "\@ """ & teCurrentFormat.Text.Trim() & """"
			End If
			Return resultString
		End Function

		#End Region
	End Class

End Namespace
