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
	''' Interaction logic for ucIFFIELD.xaml
	''' </summary>
	Partial Public Class ucIFFIELD
		Inherits UserControl
		Implements IFieldParametersDialog
		Public Sub New()
			InitializeComponent()

			comboBoxOperation.Items.Clear()
			comboBoxOperation.Items.Add("=")
			comboBoxOperation.Items.Add("<>")
			comboBoxOperation.Items.Add(">")
			comboBoxOperation.Items.Add("<")
			comboBoxOperation.Items.Add(">=")
			comboBoxOperation.Items.Add("<=")

			comboBoxOperation.SelectedItem = "="
		End Sub

		#Region "IFieldParametersDialog Members"

		Public Function GenerateFieldParametersString() As String Implements IFieldParametersDialog.GenerateFieldParametersString
			Dim resultString As String = ""
			resultString &= tbLeftExpression.Text.Trim()
			resultString &= " " & comboBoxOperation.SelectedItem.ToString() & " "
			resultString &= tbRightExpression.Text.Trim()
			resultString &= " " & tbResultTrue.Text.Trim() & " "
			resultString &= tbResultFalse.Text.Trim()
			Return resultString
		End Function

		#End Region

		Private Sub comboBoxOperation_SelectionChanged_1(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
			GenerateLayoutControlGroupsCaptions()
		End Sub

		Private Sub GenerateLayoutControlGroupsCaptions()
			Dim leftTemplate As String = "A value isnerted when the LEFT expression"
			Dim rightTemplate As String = "the RIGHT expression"

			Dim trueText As String = ""
			Dim falseText As String = ""

			Select Case comboBoxOperation.SelectedItem.ToString()
				Case "="
					trueText = "EQUALS"
					falseText = "DOESN'T EQUAL"
				Case "<>"
					trueText = "DOESN'T EQUAL"
					falseText = "EQUALS"
				Case ">"
					trueText = "IS GREATER THAN"
					falseText = "IS NOT GREATER THAN"
				Case "<"
					trueText = "IS LESS THAN"
					falseText = "IS NOT LESS THAN"
				Case ">="
					trueText = "IS GREATER THAN OR EQUALS"
					falseText = "IS LESS THAN"
				Case "<="
					trueText = "IS LESS THAN OR EQUALS"
					falseText = "IS GREATER THAN"
				Case Else
			End Select

			labelResultTrue.Content = leftTemplate & " " & trueText & " " & rightTemplate
			labelResultFalse.Content = leftTemplate & " " & falseText & " " & rightTemplate
		End Sub

		Public Function IsFieldParametersValid() As Boolean
			If tbLeftExpression.Text.Trim() = "" Then
				Return False
			End If
			If tbRightExpression.Text.Trim() = "" Then
				Return False
			End If
			If tbResultTrue.Text.Trim() = "" Then
				Return False
			End If
			If tbResultFalse.Text.Trim() = "" Then
				Return False
			End If
			Return True
		End Function

		Public Function GetNestedFieldsList() As List(Of String)
			Dim nestedFieldsList As New List(Of String)()
			If CBool(ceInsertLeftAsField.IsChecked) Then
				nestedFieldsList.Add(tbLeftExpression.Text.Trim())
			End If
			If CBool(ceInsertRightAsField.IsChecked) Then
				nestedFieldsList.Add(tbRightExpression.Text.Trim())
			End If
			If CBool(ceInsertResultTrueAsField.IsChecked) Then
				nestedFieldsList.Add(tbResultTrue.Text.Trim())
			End If
			If CBool(ceInsertResultFalsetAsField.IsChecked) Then
				nestedFieldsList.Add(tbResultFalse.Text.Trim())
			End If
			Return nestedFieldsList
		End Function
	End Class
End Namespace
