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
    /// Interaction logic for ucIFFIELD.xaml
    /// </summary>
    public partial class ucIFFIELD : UserControl, IFieldParametersDialog {
        public ucIFFIELD() {
            InitializeComponent();

            comboBoxOperation.Items.Clear();
            comboBoxOperation.Items.Add("=");
            comboBoxOperation.Items.Add("<>");
            comboBoxOperation.Items.Add(">");
            comboBoxOperation.Items.Add("<");
            comboBoxOperation.Items.Add(">=");
            comboBoxOperation.Items.Add("<=");

            comboBoxOperation.SelectedItem = "=";
        }

        #region IFieldParametersDialog Members

        public string GenerateFieldParametersString() {
            string resultString = "";
            resultString += tbLeftExpression.Text.Trim();
            resultString += " " + comboBoxOperation.SelectedItem.ToString() + " ";
            resultString += tbRightExpression.Text.Trim();
            resultString += " " + tbResultTrue.Text.Trim() + " ";
            resultString += tbResultFalse.Text.Trim();
            return resultString;
        }

        #endregion

        private void comboBoxOperation_SelectionChanged_1(object sender, SelectionChangedEventArgs e) {
            GenerateLayoutControlGroupsCaptions();    
        }

        void GenerateLayoutControlGroupsCaptions() {
            string leftTemplate = "A value isnerted when the LEFT expression";
            string rightTemplate = "the RIGHT expression";

            string trueText = "";
            string falseText = "";

            switch(comboBoxOperation.SelectedItem.ToString()) {
                case "=":
                    trueText = "EQUALS";
                    falseText = "DOESN'T EQUAL";
                    break;
                case "<>":
                    trueText = "DOESN'T EQUAL";
                    falseText = "EQUALS";
                    break;
                case ">":
                    trueText = "IS GREATER THAN";
                    falseText = "IS NOT GREATER THAN";
                    break;
                case "<":
                    trueText = "IS LESS THAN";
                    falseText = "IS NOT LESS THAN";
                    break;
                case ">=":
                    trueText = "IS GREATER THAN OR EQUALS";
                    falseText = "IS LESS THAN";
                    break;
                case "<=":
                    trueText = "IS LESS THAN OR EQUALS";
                    falseText = "IS GREATER THAN";
                    break;
                default:
                    break;
            }

            labelResultTrue.Content = leftTemplate + " " + trueText + " " + rightTemplate;
            labelResultFalse.Content = leftTemplate + " " + falseText + " " + rightTemplate;
        }

        public bool IsFieldParametersValid() {
            if(tbLeftExpression.Text.Trim() == "") return false;
            if(tbRightExpression.Text.Trim() == "") return false;
            if(tbResultTrue.Text.Trim() == "") return false;
            if(tbResultFalse.Text.Trim() == "") return false;
            return true;
        }

        public List<string> GetNestedFieldsList() {
            List<string> nestedFieldsList = new List<string>();
            if((bool)ceInsertLeftAsField.IsChecked) nestedFieldsList.Add(tbLeftExpression.Text.Trim());
            if((bool)ceInsertRightAsField.IsChecked) nestedFieldsList.Add(tbRightExpression.Text.Trim());
            if((bool)ceInsertResultTrueAsField.IsChecked) nestedFieldsList.Add(tbResultTrue.Text.Trim());
            if((bool)ceInsertResultFalsetAsField.IsChecked) nestedFieldsList.Add(tbResultFalse.Text.Trim());
            return nestedFieldsList;
        }
    }
}
