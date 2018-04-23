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
Imports WpfApplication1.InsertFieldModules

Namespace WpfApplication1
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			MainRichEditControl.ApplyTemplate()
			MainRichEditControl.RegisterInsertFieldDialogCommand(grpCustomAction, New BitmapImage(New Uri("pack://application:,,,/InsertFieldModules/insertFieldIcon.png")))
		End Sub
	End Class
End Namespace
