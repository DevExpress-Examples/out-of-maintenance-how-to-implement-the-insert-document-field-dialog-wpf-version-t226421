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


