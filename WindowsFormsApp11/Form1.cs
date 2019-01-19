using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Calculator : Form
    {
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        string result;
        char operation;
        public bool Control { get; set; }

        public Calculator()
        {
            InitializeComponent();
        }

        private void allbtn_Click(object sender, EventArgs e)
        {            
            var senderbuttontname = (sender as Button).Text;
            var operands = labelbase.Text.Split('+', '-', '/', '*', '%');
            
            switch (senderbuttontname)
            {
                case "=":
                    if (labelbase.Text != String.Empty && (labelbase.Text.Contains("+") || labelbase.Text.Contains("-") || labelbase.Text.Contains("*") || labelbase.Text.Contains("/")) || (operand1 != String.Empty && operand2 == String.Empty))
                    {
                        Control = true;
                        operand2 = operands[1];

                        double opr1, opr2;
                        double.TryParse(operand1, out opr1);
                        double.TryParse(operand2, out opr2);

                        switch (operation)
                        {
                            case '+':
                                result = (opr1 + opr2).ToString();

                                break;
                            case '-':
                                result = (opr1 - opr2).ToString();

                                break;
                            case '*':
                                result = (opr1 * opr2).ToString();

                                break;
                            case '%':
                                if (opr2 <= 100)
                                    result = ((opr1 * opr2) / 100).ToString();
                                else
                                    result = (opr1 + (opr1 * (opr2 - 100) / 100)).ToString();

                                break;
                            case '/':
                                if (opr2 != 0)
                                    result = (opr1 / opr2).ToString();
                                else MessageBox.Show("Can't divide by zero", "Warning");

                                break;
                        }

                        operand1 = string.Empty;
                        operand2 = string.Empty;
                        labelbase.Text = result;
                    }
                    
                    else
                        MessageBox.Show("Something went wrong !", "Error");

                    break;
                case "+":
                    operation = '+';
                    operand1 = operands[0];
                    if (!labelbase.Text.Contains("+") && labelbase.Text != String.Empty)
                        labelbase.Text += (sender as Button).Text;

                    break;
                case "-":
                    operation = '-';
                    operand1 = operands[0];
                    if (!labelbase.Text.Contains("-") && labelbase.Text != String.Empty)
                        labelbase.Text += (sender as Button).Text;

                    break;
                case "*":
                    operation = '*';
                    operand1 = operands[0];
                    if (!labelbase.Text.Contains("*") && labelbase.Text != String.Empty)
                        labelbase.Text += (sender as Button).Text;

                    break;
                case "/":
                    operation = '/';
                    operand1 = operands[0];
                    if (!labelbase.Text.Contains("/") && labelbase.Text != String.Empty)
                        labelbase.Text += (sender as Button).Text;

                    break;
                case "%":
                    operation = '%';
                    operand1 = operands[0];
                    if (!labelbase.Text.Contains("%") && labelbase.Text != String.Empty)
                        labelbase.Text += (sender as Button).Text;

                    break;
                case "C":
                    labelbase.Text = "0";
                    operand1 = string.Empty;
                    operand2 = string.Empty;

                    break;
                case "DEL":
                    //labelbase.Text.Remove(labelbase.Text.LastOrDefault() - 2, 1);

                    break;
                case "CE":

                    break;
                case "- +":

                    break;
                default:

                    if (labelbase.Text == "0" || (operand1 == String.Empty && operand2 == String.Empty && Control == true))
                    {
                        if (operand1 == String.Empty && operand2 == String.Empty && Control == true)
                        {
                            Control = false;
                            labelbase.Text = String.Empty;
                            labelbase.Text += (sender as Button).Text;
                        }
                        
                        else if(labelbase.Text == "0")
                        {
                            labelbase.Text = String.Empty;
                            labelbase.Text += (sender as Button).Text;
                        }

                        else if (operand1 == String.Empty && operand2 == String.Empty)
                        {
                            labelbase.Text += (sender as Button).Text;
                        }                    

                    }

                    else labelbase.Text += (sender as Button).Text;

                    break;
            }
        }
    }
}
