using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVVM.Model.Operations
{
    class Subtraction : IOperation
    {
        public string Name { get; private set; } = "Subtraction";

        public string Symbol { get; private set; } = "-";

        public decimal Execute(decimal firstArg, decimal secondArg)
        {
           return firstArg-secondArg;
        }
    }
}
