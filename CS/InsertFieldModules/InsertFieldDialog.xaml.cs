using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1.InsertFieldModules {
    /// <summary>
    /// Interaction logic for InsertFieldDialog.xaml
    /// </summary>
    public partial class InsertFieldDialog : DXDialog {
        public ObservableCollection<DocFieldInfo> DocFieldCollection { get; private set; }
        public InsertFieldDialog() {
            InitializeComponent();
            DocFieldCollection = new ObservableCollection<DocFieldInfo>();
            DocFieldCollection.Add(new DocFieldInfo() { FieldName = "DOCVARIABLE", PropertiesControlName = "ucDOCVARIABLE" });
            DocFieldCollection.Add(new DocFieldInfo() { FieldName = "PAGE", PropertiesControlName = "ucPAGENUMBER" });
            DocFieldCollection.Add(new DocFieldInfo() { FieldName = "NUMPAGES", PropertiesControlName = "ucPAGENUMBER" });
            DocFieldCollection.Add(new DocFieldInfo() { FieldName = "CREATEDATE", PropertiesControlName = "ucCREATEDATE" });
            DocFieldCollection.Add(new DocFieldInfo() { FieldName = "DATE", PropertiesControlName = "ucCREATEDATE" });
            DocFieldCollection.Add(new DocFieldInfo() { FieldName = "TIME", PropertiesControlName = "ucCREATEDATE" });
            DocFieldCollection.Add(new DocFieldInfo() { FieldName = "IF", PropertiesControlName = "ucIFFIELD" });

            lbeFields.ItemsSource = DocFieldCollection;
            this.Closing += InsertFieldDialog_Closing;
            FieldsNavigationFrame.Navigated += FieldsNavigationFrame_Navigated;
        }

        void FieldsNavigationFrame_Navigated(object sender, DevExpress.Xpf.WindowsUI.Navigation.NavigationEventArgs e) {
            InsertFieldRichEditHelper.CurrentParametersDialog = FieldsNavigationFrame.Content as IFieldParametersDialog;
        }

        void InsertFieldDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void ListBoxEdit_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e) {            
            InsertFieldRichEditHelper.CurrentVariableType = e.NewValue.ToString();
            FieldsNavigationFrame.Navigate(((e.Source as DevExpress.Xpf.Editors.ListBoxEdit).SelectedItem as DocFieldInfo).PropertiesControlName);            
        }
    }

    public class DocFieldInfo {
        public string FieldName { get; set; }
        public string PropertiesControlName { get; set; }
    }
}
