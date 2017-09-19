using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {       string result;
        public new string Process(string str)
        {
            if (str == null || str == "")
            { return "E"; }
            if (str == "0")
            {
                return "0";
            }
            

            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            
            string firstOperand, secondOperand;

            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    int i;
                    for (i = 0; i < token.Length; i++)
                    {
                        if (token[i] == '+')
                        {
                            return "E";
                        }
                    }

                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there ==only one left in stack?
                    try
                    {
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        result = calculate(token, firstOperand, secondOperand, 4);
                        if (result == "E")
                        {
                            return result;
                        }
                        rpnStack.Push(result);
                    }
                    catch
                    {
                        return "E";
                    }
                }

                else if (token != "")
                {
                    return "E";
                }
                   // rpnStack.Push(result);
                
            }
            //FIXME, what if there ==more than one, or zero, items in the stack?
            if (rpnStack.Count() == 0 || rpnStack.Count() > 1)
            {
                return "E";
            }
            else
            {
                result = rpnStack.Pop();
                return result;
            }
                 //result = rpnStack.Pop();
            
        }
    }
}
