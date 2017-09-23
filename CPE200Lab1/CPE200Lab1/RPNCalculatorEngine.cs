using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {   string result;
        protected Stack<string> myStack ;

        public string calculate(string str)
        {
            if (str == null || str == "")
            { return "E"; }
            if (str == "0")
            {
                return "0";
            }

            myStack = new Stack<string>();
            //Stack<string> rpnStack = new Stack<string>();
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

                    myStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there ==only one left in stack?
                    try
                    {
                        secondOperand = myStack.Pop();
                        firstOperand = myStack.Pop();
                        result = calculate(token, firstOperand, secondOperand, 4);
                        if (result == "E")
                        {
                            return result;
                        }
                        myStack.Push(result);
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
                   // myStack.Push(result);
                
            }
            //FIXME, what if there ==more than one, or zero, items in the stack?
            if (myStack.Count() == 0 || myStack.Count() > 1)
            {
                return "E";
            }
            else
            {
                result = myStack.Pop();
                return result;
            }
                 //result = myStack.Pop();
            
        }
    }
}
