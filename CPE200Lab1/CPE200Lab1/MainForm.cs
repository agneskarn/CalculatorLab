using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;
        string input = string.Empty;        //string storing user input
        string operand1 = string.Empty;     //string storing first operand
        string operand2 = string.Empty;     //string storing second operand
        double result = 0.0;                //calculated result
        char operation;                     //char for operation
        string oparate;  

        // This is an attribute of MainForm class
        CalculatorEngine calEngine = new CalculatorEngine();

        public MainForm()
        {
            InitializeComponent();

            resetAll();
        }

        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
        }

        // ui
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";
            }
            if(lblDisplay.Text.Length == 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if(lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    break;
            }
            isAllowBack = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            string secondOperand = lblDisplay.Text;

            // This is a var in method in MainForm class
            //CalculatorEngine calEngine = new CalculatorEngine();

            string result = calEngine.calculate(operate, firstOperand, secondOperand);
            if (result == "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            isAfterEqual = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length == 8)
            {
                return;
            }
            if (!hasDot)
            {
                lblDisplay.Text += ".";
                hasDot = true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (lblDisplay.Text.Length == 8)
            {
                return;
            }
            if(lblDisplay.Text[0] == '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            } else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if(lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if(rightMost == '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if(lblDisplay.Text == "" || lblDisplay.Text == "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void divinex_Click(object sender, EventArgs e)
        {
            if (operate == "0")
            {
                firstOperand = lblDisplay.Text;
                double x = Convert.ToDouble(firstOperand);
                x = 1 / x;
                firstOperand = Convert.ToString(x);
                lblDisplay.Text = firstOperand;
                isAfterEqual = true;

            }
            else
            {
                result = Convert.ToDouble(1.0 / Convert.ToDouble(lblDisplay.Text));
                lblDisplay.Text = Convert.ToString(result);
            }
        }

        private void butoonSqrt_Click(object sender, EventArgs e)
        {
            result = (System.Math.Sqrt(Convert.ToDouble(lblDisplay.Text)));
            lblDisplay.Text = Convert.ToString(result);
        }
    }
}
