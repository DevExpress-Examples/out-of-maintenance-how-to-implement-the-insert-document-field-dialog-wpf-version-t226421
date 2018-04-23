Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.Ribbon
Imports DevExpress.Xpf.RichEdit
Imports DevExpress.XtraRichEdit.API.Native

Namespace WpfApplication1.InsertFieldModules
	Public Module InsertFieldRichEditHelper
		Private privateCurrentRichEditControl As RichEditControl
        Public Property CurrentRichEditControl() As RichEditControl
            Get
                Return privateCurrentRichEditControl
            End Get
            Set(ByVal value As RichEditControl)
                privateCurrentRichEditControl = value
            End Set
        End Property
		Private privateFieldDialog As InsertFieldDialog
        Public Property FieldDialog() As InsertFieldDialog
            Get
                Return privateFieldDialog
            End Get
            Set(ByVal value As InsertFieldDialog)
                privateFieldDialog = value
            End Set
        End Property
		Private privateCurrentVariableType As String
        Public Property CurrentVariableType() As String
            Get
                Return privateCurrentVariableType
            End Get
            Set(ByVal value As String)
                privateCurrentVariableType = value
            End Set
        End Property
		Private privateCurrentParametersDialog As IFieldParametersDialog
        Public Property CurrentParametersDialog() As IFieldParametersDialog
            Get
                Return privateCurrentParametersDialog
            End Get
            Set(ByVal value As IFieldParametersDialog)
                privateCurrentParametersDialog = value
            End Set
        End Property
		Public Const EmptyFieldCode As String = "EMPTYFIELD"

        <System.Runtime.CompilerServices.Extension> _
        Public Sub RegisterInsertFieldDialogCommand(ByVal richEdit As RichEditControl, ByVal pageGroup As RibbonPageGroup, ByVal commandImage As System.Windows.Media.ImageSource)
            Dim buttonInsertFieldDialog As New BarButtonItem()
            buttonInsertFieldDialog.Name = "buttonInsertFieldDialog"
            buttonInsertFieldDialog.Content = "Insert Field"
            If commandImage IsNot Nothing Then
                buttonInsertFieldDialog.LargeGlyph = commandImage
            End If
            pageGroup.Ribbon.Manager.Items.Add(buttonInsertFieldDialog)
            pageGroup.ItemLinks.Add(buttonInsertFieldDialog)

            AddHandler buttonInsertFieldDialog.ItemClick, AddressOf buttonInsertFieldDialog_ItemClick
            CurrentRichEditControl = richEdit
        End Sub

        Private Sub buttonInsertFieldDialog_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            If FieldDialog Is Nothing Then
                FieldDialog = New InsertFieldDialog()
                Dim curApp As Application = Application.Current
                Dim mainWindow As Window = curApp.MainWindow
                FieldDialog.Owner = mainWindow
                FieldDialog.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
            End If
            Dim result As MessageBoxResult = FieldDialog.ShowDialog(MessageBoxButton.OKCancel)
            If result = MessageBoxResult.OK Then
                Dim parametersDialog As IFieldParametersDialog = CurrentParametersDialog
                If parametersDialog IsNot Nothing Then
                    Dim fieldCode As String = InsertFieldRichEditHelper.CurrentVariableType

                    Dim parametersString As String = parametersDialog.GenerateFieldParametersString()
                    If parametersString = InsertFieldRichEditHelper.EmptyFieldCode Then
                        Return
                    End If

                    Dim currentDocument As SubDocument = CurrentRichEditControl.Document.CaretPosition.BeginUpdateDocument()

                    If TypeOf parametersDialog Is ucIFFIELD Then
                        Dim IFFieldInsertDialog As ucIFFIELD = TryCast(parametersDialog, ucIFFIELD)
                        If IFFieldInsertDialog.IsFieldParametersValid() Then

                            Dim newField As Field = currentDocument.Fields.Create(CurrentRichEditControl.Document.CaretPosition, fieldCode & " " & parametersString)

                            Dim nestedFiueldsList As List(Of String) = IFFieldInsertDialog.GetNestedFieldsList()

                            For Each nestedFieldCode As String In nestedFiueldsList
                                Dim ranges() As DocumentRange = currentDocument.FindAll(nestedFieldCode, SearchOptions.WholeWord)
                                For Each range As DocumentRange In ranges
                                    currentDocument.Fields.Create(range)
                                Next range
                            Next nestedFieldCode
                        End If
                    Else
                        If parametersString <> "" Then
                            currentDocument.Fields.Create(CurrentRichEditControl.Document.CaretPosition, fieldCode & " " & parametersString)
                        Else
                            currentDocument.Fields.Create(CurrentRichEditControl.Document.CaretPosition, fieldCode)
                        End If
                    End If

                    currentDocument.Fields.Update()
                    CurrentRichEditControl.Document.CaretPosition.EndUpdateDocument(currentDocument)
                End If
            End If
        End Sub
	End Module

	' Additional service classes
	Public Interface IFieldParametersDialog
		Function GenerateFieldParametersString() As String
	End Interface

	Public Class FieldAttributeItem
		Private privateDisplayName As String
		Public Property DisplayName() As String
			Get
				Return privateDisplayName
			End Get
			Set(ByVal value As String)
				privateDisplayName = value
			End Set
		End Property
		Private privateAttributeValue As String
		Public Property AttributeValue() As String
			Get
				Return privateAttributeValue
			End Get
			Set(ByVal value As String)
				privateAttributeValue = value
			End Set
		End Property
	End Class
End Namespace