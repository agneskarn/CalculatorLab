﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; // to use Stack
namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    {
        public void testStackMethod()
        {
            Stack testStack = new Stack();
            testStack.Push("1st element");
            testStack.Push("2nd element");
            testStack.Pop();
            Console.Out.WriteLine(testStack.Pop());
        }
        

    }
}
