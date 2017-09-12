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
        private double memory;
        private CalculatorEngine engine;

        private void resetAll()
        {
            lblDisplayy.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            firstOperand = null;
        }

      

        public MainForm()
        {
            InitializeComponent();
            memory = 0;
            engine = new CalculatorEngine();
            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplayy.Text = "0";
            }
            if(lblDisplayy.Text.Length == 8)
            {
                return;
            }                                       
            isAllowBack = true;
            string digit = ((Button)sender).Text; 
            if(lblDisplayy.Text == "0") //ไม่มีอะไรแล้วกด0 จะไม่มีอะไร
            {
                lblDisplayy.Text = "";
            }
            lblDisplayy.Text += digit; // 
            isAfterOperater = false;
        }

        private void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            operate = ((Button)sender).Text;
            firstOperand = lblDisplayy.Text;
            string result = engine.unaryCalculate(operate, firstOperand);
            if (result == "E" || result.Length > 8)
            {
                lblDisplayy.Text = "Error";
            }
            else
            {
                lblDisplayy.Text = result;
            }

        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            if(firstOperand != null)
            {
                string secondOperand = lblDisplayy.Text;
                string result = engine.calculate(operate, firstOperand, secondOperand);
                if (result == "E" || result.Length > 8)
                {
                    lblDisplayy.Text = "Error";
                }
                else
                {
                    lblDisplayy.Text = result;
                }
            }
            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "√":
                case "1/x":
                case "%":
                    firstOperand = lblDisplayy.Text;
                    isAfterOperater = true;
                    break;
                //case "%":
                    // your code here
                    //break;
            }
            isAllowBack = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            string secondOperand = lblDisplayy.Text;
            string result = engine.calculate(operate, firstOperand, secondOperand);
            if (result == "E" || result.Length > 8)
            {
                lblDisplayy.Text = "Error";
            }
            else
            {
                lblDisplayy.Text = result;
            }
            isAfterEqual = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplayy.Text.Length == 8)
            {
                return;
            }
            if (!hasDot)
            {
                lblDisplayy.Text += ".";
                hasDot = true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (lblDisplayy.Text.Length == 8)
            {
                return;
            }
            if(lblDisplayy.Text[0] == '-')
            {
                lblDisplayy.Text = lblDisplayy.Text.Substring(1, lblDisplayy.Text.Length - 1);
            } else
            {
                lblDisplayy.Text = "-" + lblDisplayy.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
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
            if(lblDisplayy.Text != "0")
            {
                string current = lblDisplayy.Text;
                char rightMost = current[current.Length - 1];
                if(rightMost == '.')
                {
                    hasDot = false;
                }
                lblDisplayy.Text = current.Substring(0, current.Length - 1);
                if(lblDisplayy.Text == "" || lblDisplayy.Text == "-")
                {
                    lblDisplayy.Text = "0";
                }
            }
        }

        private void btnMP_Click(object sender, EventArgs e)
        {
            if(lblDisplayy.Text == "Error")
            {
                return;
            }
            memory += Convert.ToDouble(lblDisplayy.Text);
            isAfterOperater = true;
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void btnMM_Click(object sender, EventArgs e)
        {
            if(lblDisplayy.Text == "Error")
            {
                return;
            }
            memory -= Convert.ToDouble(lblDisplayy.Text);
            isAfterOperater = true;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            if(lblDisplayy.Text == "error")
            {
                return;
            }
            lblDisplayy.Text = memory.ToString();
        }
    }
}
