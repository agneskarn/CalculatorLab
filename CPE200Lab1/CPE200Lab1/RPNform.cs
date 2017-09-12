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
    public partial class RPNForm : Form
    {
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private bool isSpaceAllowed = false;
        private bool isAfterOperater;
        private string operate;
        private double memory;
        private RPNCalculatorEngine engine;

        public RPNForm()
        {
            InitializeComponent();
            engine = new RPNCalculatorEngine();
        }


        private bool isOperator(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                case 'X':
                case '÷':
                case '√':
                case '%':
                    return true;
            }
            return false;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            if (lblDisplayy.Text == "0")
            {
                lblDisplayy.Text = "";
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                isContainDot = false;
            }
            lblDisplayy.Text += ((Button)sender).Text;
            isSpaceAllowed = true;
        }

        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;
            
          
                lblDisplayy.Text += " " + ((Button)sender).Text + " ";
                isSpaceAllowed = false;
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            // check if the last one == operator
            string current = lblDisplayy.Text;
            if (current[current.Length - 1] == ' ' && current.Length > 2 && isOperator(current[current.Length - 2]))
            {
                lblDisplayy.Text = current.Substring(0, current.Length - 3);
            }
            else
            {
                lblDisplayy.Text = current.Substring(0, current.Length - 1);
            }
            if (lblDisplayy.Text == "")
            {
                lblDisplayy.Text = "0";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplayy.Text = "0";
            isContainDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string result = engine.RpnProcess(lblDisplayy.Text);
            if (result == "E")
            {
                lblDisplayy.Text = "Error";
            }
            else
            {
                lblDisplayy.Text = result;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            if (isNumberPart)
            {
                return;
            }
            string current = lblDisplayy.Text;
            if (current == "0")
            {
                lblDisplayy.Text = "-";
            }
            else if (current[current.Length - 1] == '-')
            {
                lblDisplayy.Text = current.Substring(0, current.Length - 1);
                if (lblDisplayy.Text == "")
                {
                    lblDisplayy.Text = "0";
                }
            }
            else
            {
                lblDisplayy.Text = current + "-";
            }
            isSpaceAllowed = false;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            //if (!isContainDot)
            //{
                //isContainDot = true;
                //lblDisplayy.Text += ".";
                //isSpaceAllowed = false;
            //}
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            if (isSpaceAllowed)
            {
                lblDisplayy.Text += " ";
                isSpaceAllowed = false;
            }
        }
        private void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;

            lblDisplayy.Text += " " + ((Button)sender).Text + " ";
            isSpaceAllowed = false;

        }


        private void btnMP_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "Error")
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
            if (lblDisplayy.Text == "Error")
            {
                return;
            }
            memory -= Convert.ToDouble(lblDisplayy.Text);
            isAfterOperater = true;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            if (lblDisplayy.Text == "error")
            {
                return;
            }
            lblDisplayy.Text = memory.ToString();
        }
    }
}
    

