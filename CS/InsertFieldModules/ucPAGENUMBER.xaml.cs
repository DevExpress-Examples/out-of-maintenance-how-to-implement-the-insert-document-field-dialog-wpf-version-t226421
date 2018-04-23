using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1.InsertFieldModules {
    /// <summary>
    /// Interaction logic for ucPAGENUMBER.xaml
    /// </summary>
    public partial class ucPAGENUMBER : UserControl, IFieldParametersDialog {
        public ucPAGENUMBER() {
            InitializeComponent();
            if(InsertFieldRichEditHelper.CurrentVariableType == "PAGE") {
                InitializeListBoxItemsPage();
                tbHyperlink1.Visibility = System.Windows.Visibility.Visible;
                tbHyperlink2.Visibility = System.Windows.Visibility.Visible;
            }
            else {
                InitializeListBoxItemsNumPages();
                tbHyperlink1.Visibility = System.Windows.Visibility.Collapsed;
                tbHyperlink2.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void InitializeListBoxItemsPage() {
            List<FieldAttributeItem> listSource = new List<FieldAttributeItem>();
            listSource.Add(new FieldAttributeItem() { DisplayName = "1, 2, 3, ...", AttributeValue = @"\* Arabic" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "- 1 -, - 2- , - 3- , ...", AttributeValue = @"\* ArabicDash" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "a, b, c, ...", AttributeValue = @"\* alphabetic" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "A, B, C, ...", AttributeValue = @"\* ALPHABETIC" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "i, ii, iii, ...", AttributeValue = @"\* roman" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "I, II, III, ...", AttributeValue = @"\* ROMAN" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "Use Default Numbering", AttributeValue = @"EMPTY" });

            lbeFormats.ItemsSource = listSource;
            lbeFormats.DisplayMember = "DisplayName";
            lbeFormats.ValueMember = "AttributeValue";
        }

        void InitializeListBoxItemsNumPages() {
            List<FieldAttributeItem> listSource = new List<FieldAttributeItem>();
            listSource.Add(new FieldAttributeItem() { DisplayName = "(none)", AttributeValue = @"EMPTY" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "1, 2, 3, ...", AttributeValue = @"\* Arabic" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "a, b, c, ...", AttributeValue = @"\* alphabetic" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "A, B, C, ...", AttributeValue = @"\* ALPHABETIC" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "i, ii, iii, ...", AttributeValue = @"\* roman" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "I, II, III, ...", AttributeValue = @"\* ROMAN" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "1st, 2nd, 3rd, ...", AttributeValue = @"\* Ordinal" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "One, Two, Three, ...", AttributeValue = @"\* CardText" });
            listSource.Add(new FieldAttributeItem() { DisplayName = "First, Second, Third, ...", AttributeValue = @"\* OrdText" });

            lbeFormats.ItemsSource = listSource;
            lbeFormats.DisplayMember = "DisplayName";
            lbeFormats.ValueMember = "AttributeValue";
        }

        #region IFieldParametersDialog Members

        public string GenerateFieldParametersString() {
            string resultString = "";
            if(lbeFormats.EditValue != null && lbeFormats.EditValue.ToString() != "EMPTY") {
                resultString = lbeFormats.EditValue.ToString();
            }
            return resultString;            
        }

        #endregion

        private void Hyperlink_RequestNavigate_1(object sender, RequestNavigateEventArgs e) {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
