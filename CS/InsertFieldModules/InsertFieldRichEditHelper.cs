using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.RichEdit;
using DevExpress.XtraRichEdit.API.Native;

namespace WpfApplication1.InsertFieldModules {
    public static class InsertFieldRichEditHelper {
        public static RichEditControl CurrentRichEditControl { get; set; }
        public static InsertFieldDialog FieldDialog { get; set; }
        public static string CurrentVariableType { get; set; }
        public static IFieldParametersDialog CurrentParametersDialog { get; set; }
        public const string EmptyFieldCode = "EMPTYFIELD";

        public static void RegisterInsertFieldDialogCommand(this RichEditControl richEdit, RibbonPageGroup pageGroup, System.Windows.Media.ImageSource commandImage) {
            BarButtonItem buttonInsertFieldDialog = new BarButtonItem();
            buttonInsertFieldDialog.Name = "buttonInsertFieldDialog";
            buttonInsertFieldDialog.Content = "Insert Field";
            if (commandImage != null) buttonInsertFieldDialog.LargeGlyph = commandImage;
            pageGroup.Ribbon.Manager.Items.Add(buttonInsertFieldDialog);
            pageGroup.ItemLinks.Add(buttonInsertFieldDialog);

            buttonInsertFieldDialog.ItemClick += buttonInsertFieldDialog_ItemClick;
            CurrentRichEditControl = richEdit;
        }

        static void buttonInsertFieldDialog_ItemClick(object sender, ItemClickEventArgs e) {
            if (FieldDialog == null) {
                FieldDialog = new InsertFieldDialog();
                Application curApp = Application.Current;
                Window mainWindow = curApp.MainWindow;
                FieldDialog.Owner = mainWindow;
                FieldDialog.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            }
            MessageBoxResult result = FieldDialog.ShowDialog(MessageBoxButton.OKCancel);
            if(result == MessageBoxResult.OK) {
                IFieldParametersDialog parametersDialog = CurrentParametersDialog;
                if(parametersDialog != null) {
                    string fieldCode = InsertFieldRichEditHelper.CurrentVariableType;

                    string parametersString = parametersDialog.GenerateFieldParametersString();
                    if(parametersString == InsertFieldRichEditHelper.EmptyFieldCode) return;

                    SubDocument currentDocument = CurrentRichEditControl.Document.CaretPosition.BeginUpdateDocument();

                    if(parametersDialog is ucIFFIELD) {
                        ucIFFIELD IFFieldInsertDialog = parametersDialog as ucIFFIELD;
                        if(IFFieldInsertDialog.IsFieldParametersValid()) {

                            Field newField = currentDocument.Fields.Create(CurrentRichEditControl.Document.CaretPosition, fieldCode + " " + parametersString);

                            List<string> nestedFiueldsList = IFFieldInsertDialog.GetNestedFieldsList();

                            foreach(string nestedFieldCode in nestedFiueldsList) {
                                DocumentRange[] ranges = currentDocument.FindAll(nestedFieldCode, SearchOptions.WholeWord);
                                foreach(DocumentRange range in ranges) {
                                    currentDocument.Fields.Create(range);
                                }
                            }
                        }
                    }
                    else {
                        if(parametersString != "")
                            currentDocument.Fields.Create(CurrentRichEditControl.Document.CaretPosition, fieldCode + " " + parametersString);
                        else
                            currentDocument.Fields.Create(CurrentRichEditControl.Document.CaretPosition, fieldCode);
                    }

                    currentDocument.Fields.Update();
                    CurrentRichEditControl.Document.CaretPosition.EndUpdateDocument(currentDocument);
                }
            }
        }
    }

    // Additional service classes
    public interface IFieldParametersDialog {
        string GenerateFieldParametersString();
    }

    public class FieldAttributeItem {
        public string DisplayName { get; set; }
        public string AttributeValue { get; set; }
    }
}