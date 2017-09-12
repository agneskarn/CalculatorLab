using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; // to use Stack

namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    {   
        public string RpnProcess(string stringInput)
        {
            string[] parts = stringInput.Split(' ');
            string result = null;
            Stack rpnStack = new Stack();

            //loop
            foreach (string input in parts)
            {
                //for (int i = 0; i < parts.Length; i++;)
                //string input = parts[i]; // each part one-by-one
                if (isNumber(input))
                {
                    rpnStack.Push(input);
                }
                else if (isOperator(input))
                {
                    /*string rpnOperate = input;
                     string secondRpnOperand = rpnStack.Pop().ToString();
                     string firstRpnOperand = rpnStack.Pop().ToString();
                     result = calculate(rpnOperate, firstRpnOperand, secondRpnOperand, 4);
                     rpnStack.Push(result);*/


                    if (input == "+" || input == "-" || input == "X" || input == "÷")
                    {
                        string rpnOperate = input;
                        string secondRpnOperand = rpnStack.Pop().ToString();
                        string firstRpnOperand = rpnStack.Pop().ToString();
                        result = calculate(rpnOperate, firstRpnOperand, secondRpnOperand, 4);
                        rpnStack.Push(result);
                    }
                    if (input == "%")
                    {
                        string rpnOperate = input;
                        string secondRpnOperand = rpnStack.Pop().ToString();
                        string firstRpnOperand = rpnStack.Pop().ToString();
                        result = calculate(rpnOperate, firstRpnOperand, secondRpnOperand, 4);
                        rpnStack.Push(firstRpnOperand);
                        rpnStack.Push(result);
                    }
                    else if (input == "√" || input == "1/x")
                    {
                    string rpnOperate = input;
                    string firstRpnOperand = rpnStack.Pop().ToString();

                        result = unaryCalculate(rpnOperate, firstRpnOperand);
                    if (result == "E" || result.Length > 8)
                    {
                        result = "Error";
                    }
                    else
                    {
                        rpnStack.Push(result);
                    }
                }

                }
            }
                return result;
        }
        

    }
}
