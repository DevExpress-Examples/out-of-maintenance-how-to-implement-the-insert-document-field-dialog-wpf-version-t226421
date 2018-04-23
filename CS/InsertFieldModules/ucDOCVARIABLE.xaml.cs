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
    /// Interaction logic for ucDOCVARIABLE.xaml
    /// </summary>
    public partial class ucDOCVARIABLE : UserControl, IFieldParametersDialog {
        public ucDOCVARIABLE() {
            InitializeComponent();
        }

        #region IFieldParametersDialog Members

        public string GenerateFieldParametersString() {
            string resultString = "";
            if(tbVariableName.Text.Trim() == "") return InsertFieldRichEditHelper.EmptyFieldCode;

            resultString += tbVariableName.Text.Trim();
            if(tbArgument1.Text.Trim() != "")
                resultString += " " + tbArgument1.Text.Trim();
            if(tbArgument2.Text.Trim() != "")
                resultString += " " + tbArgument2.Text.Trim();
            if(tbArgument3.Text.Trim() != "")
                resultString += " " + tbArgument3.Text.Trim();
            if(tbArgument4.Text.Trim() != "")
                resultString += " " + tbArgument4.Text.Trim();
            return resultString;
        }
        #endregion
    }
}
