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

        public Calculator()
        {
            InitializeComponent();
        }

        private void allbtn_Click(object sender, EventArgs e)
        {
            var senderbuttontname = (sender as Button).Text;
            switch (senderbuttontname)
            {
                case "=":
                    var a = labelbase.Text.Split('+', '-', '/', '*');
                    operand1 = a[0];
                    operand2 = a[1];

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
                        case '/':
                            if (opr2 != 0)
                            {
                                result = (opr1 / opr2).ToString();
                            }
                            else
                            {
                                MessageBox.Show("Can't divide by zero", "Warning");
                            }
                            break;
                    }

                    labelbase.Text = result;
                    break;

                case "+":
                    operation = '+';
                    labelbase.Text += (sender as Button).Text;
                    break;

                case "-":
                    operation = '-';
                    labelbase.Text += (sender as Button).Text;
                    break;

                case "*":
                    operation = '*';
                    labelbase.Text += (sender as Button).Text;
                    break;

                case "/":
                    operation = '/';
                    labelbase.Text += (sender as Button).Text;
                    break;

                case "C":
                    labelbase.Text = "0";
                    operand1 = string.Empty;
                    operand2 = string.Empty;
                    break;

                case "DEL":
                    //labelbase.Text;

                    break;
                default:
                    if (labelbase.Text == "0" && labelbase.Text != null || labelbase.Text != null)
                    {
                        labelbase.Text += (sender as Button).Text;
                    }
                    break;
            }
        }
    }
}
