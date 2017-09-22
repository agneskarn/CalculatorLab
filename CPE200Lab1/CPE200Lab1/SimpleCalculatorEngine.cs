using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class SimpleCalculatorEngine : CalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;

        public void setFirstOperand(string num)
        {
            firstOperand = Convert.ToDouble(num); // change num string to double and take value in num to firstOperand
        }

        public void setSecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }

        public String calculate(string oper)
        {
            switch (oper)
            {
                case "+":
                    return (firstOperand + secondOperand).ToString();
                case "-":
                    return (firstOperand - secondOperand).ToString();
                case "X":
                    return (firstOperand * secondOperand).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != 0)
                    {
                        double result;
                        
                        result = firstOperand /secondOperand;
                        if (Convert.ToDouble(firstOperand) % Convert.ToDouble(secondOperand) == 0)
                        {
                            result = Math.Round(result, 4);
                            return result.ToString();//("N" + remainLength);
                        }
                    }
                    break;
                case "%":
                    break;
            }
            return "E";
        }
    }
}
