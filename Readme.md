<!-- default file list -->
*Files to look at*:

* [InsertFieldDialog.xaml](./CS/InsertFieldModules/InsertFieldDialog.xaml) (VB: [InsertFieldDialog.xaml](./VB/InsertFieldModules/InsertFieldDialog.xaml))
* [InsertFieldDialog.xaml.cs](./CS/InsertFieldModules/InsertFieldDialog.xaml.cs) (VB: [InsertFieldDialog.xaml.vb](./VB/InsertFieldModules/InsertFieldDialog.xaml.vb))
* [InsertFieldRichEditHelper.cs](./CS/InsertFieldModules/InsertFieldRichEditHelper.cs) (VB: [InsertFieldRichEditHelper.vb](./VB/InsertFieldModules/InsertFieldRichEditHelper.vb))
* [ucCREATEDATE.xaml](./CS/InsertFieldModules/ucCREATEDATE.xaml) (VB: [ucCREATEDATE.xaml](./VB/InsertFieldModules/ucCREATEDATE.xaml))
* [ucCREATEDATE.xaml.cs](./CS/InsertFieldModules/ucCREATEDATE.xaml.cs) (VB: [ucCREATEDATE.xaml.vb](./VB/InsertFieldModules/ucCREATEDATE.xaml.vb))
* [ucDOCVARIABLE.xaml](./CS/InsertFieldModules/ucDOCVARIABLE.xaml) (VB: [ucDOCVARIABLE.xaml](./VB/InsertFieldModules/ucDOCVARIABLE.xaml))
* [ucDOCVARIABLE.xaml.cs](./CS/InsertFieldModules/ucDOCVARIABLE.xaml.cs) (VB: [ucDOCVARIABLE.xaml.vb](./VB/InsertFieldModules/ucDOCVARIABLE.xaml.vb))
* [ucIFFIELD.xaml](./CS/InsertFieldModules/ucIFFIELD.xaml) (VB: [ucIFFIELD.xaml](./VB/InsertFieldModules/ucIFFIELD.xaml))
* [ucIFFIELD.xaml.cs](./CS/InsertFieldModules/ucIFFIELD.xaml.cs) (VB: [ucIFFIELD.xaml.vb](./VB/InsertFieldModules/ucIFFIELD.xaml.vb))
* [ucPAGENUMBER.xaml](./CS/InsertFieldModules/ucPAGENUMBER.xaml) (VB: [ucPAGENUMBER.xaml](./VB/InsertFieldModules/ucPAGENUMBER.xaml))
* [ucPAGENUMBER.xaml.cs](./CS/InsertFieldModules/ucPAGENUMBER.xaml.cs) (VB: [ucPAGENUMBER.xaml.vb](./VB/InsertFieldModules/ucPAGENUMBER.xaml.vb))
* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
<!-- default file list end -->
# How to implement the "Insert Document Field" dialog (WPF version)


<p>This example demonstrates how to implement a custom "Insert Document Field" dialog to insert fields with corresponding formatting attributes into a WPF RichEditControl document.<br />The main idea of this approach was described in the following example:<br /><a href="https://www.devexpress.com/Support/Center/p/T223036">How to implement the "Insert Document Field" dialog (WinForms version)</a><br /><br />To build a solution demonstrated in this sample into an existing application, copy all modules and the "insertFieldIcon.png" image located in the <strong>InsertFieldModules </strong>folder and use a corresponding <strong>RegisterInsertFieldDialogCommand</strong> extension method to add the "Insert Field" command onto a current Ribbon control:</p>
<br /><strong>CS</strong><br />


```cs
MainRichEditControl.RegisterInsertFieldDialogCommand(grpCustomAction, new BitmapImage(new Uri("pack://application:,,,/InsertFieldModules/insertFieldIcon.png")));
```


<strong><strong>VB<br /></strong></strong>


```vb
MainRichEditControl.RegisterInsertFieldDialogCommand(grpCustomAction, New BitmapImage(New Uri("pack://application:,,,/InsertFieldModules/insertFieldIcon.png")))
```



<br/>


