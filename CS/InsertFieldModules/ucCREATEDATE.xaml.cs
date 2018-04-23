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
    /// Interaction logic for ucCREATEDATE.xaml
    /// </summary>
    public partial class ucCREATEDATE : UserControl, IFieldParametersDialog {
        public ucCREATEDATE() {
            InitializeComponent();
            InitializeListBoxItemsDateFormats();
        }

        void InitializeListBoxItemsDateFormats() {
            string[] dateTimeFormats = new string[] { 
                "dd.MM.yyyy",
                "dddd, d. MMMM yyyy",
                "d. MMMM yyyy",
                "dd.MM.yy",
                "yyyy-MM-dd",
                "yy-MM-dd",
                "dd/MM/yyyy",
                "dd. MMM. yyyy",
                "dd/MM/yy",
                "MMMM yy",
                "MMM-yy",
                "dd.MM.yyyy HH:mm",
                "dd.MM.yyyy HH:mm:ss",
                "h:mm am/pm",
                "h:mm:ss am/pm",
                "HH:mm",
                "HH:mm:ss",                           
            };

            List<FieldAttributeItem> listSource = new List<FieldAttributeItem>();
            for(int i = 0; i < dateTimeFormats.Length; i++) {
                listSource.Add(new FieldAttributeItem() { DisplayName = DateTime.Now.ToString(dateTimeFormats[i].Replace("am/pm", "tt")), AttributeValue = dateTimeFormats[i] });
            }

            lbeFormats.ItemsSource = listSource;
            lbeFormats.DisplayMember = "DisplayName";
            lbeFormats.ValueMember = "AttributeValue";
        }


        #region IFieldParametersDialog Members

        public string GenerateFieldParametersString() {
            string resultString = "";
            if(teCurrentFormat.Text.Trim() != "") {
                resultString = "\\@ \"" + teCurrentFormat.Text.Trim() + "\"";
            }
            return resultString;
        }

        #endregion
    }

}
