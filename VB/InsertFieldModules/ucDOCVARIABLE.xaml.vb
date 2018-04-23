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
	''' Interaction logic for ucDOCVARIABLE.xaml
	''' </summary>
	Partial Public Class ucDOCVARIABLE
		Inherits UserControl
		Implements IFieldParametersDialog
		Public Sub New()
			InitializeComponent()
		End Sub

		#Region "IFieldParametersDialog Members"

		Public Function GenerateFieldParametersString() As String Implements IFieldParametersDialog.GenerateFieldParametersString
			Dim resultString As String = ""
			If tbVariableName.Text.Trim() = "" Then
				Return InsertFieldRichEditHelper.EmptyFieldCode
			End If

			resultString &= tbVariableName.Text.Trim()
			If tbArgument1.Text.Trim() <> "" Then
				resultString &= " " & tbArgument1.Text.Trim()
			End If
			If tbArgument2.Text.Trim() <> "" Then
				resultString &= " " & tbArgument2.Text.Trim()
			End If
			If tbArgument3.Text.Trim() <> "" Then
				resultString &= " " & tbArgument3.Text.Trim()
			End If
			If tbArgument4.Text.Trim() <> "" Then
				resultString &= " " & tbArgument4.Text.Trim()
			End If
			Return resultString
		End Function
		#End Region
	End Class
End Namespace
