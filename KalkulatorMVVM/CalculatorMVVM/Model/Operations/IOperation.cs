using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVVM.Model.Operations
{
    interface IOperation
    {
        string Name { get; }
        string Symbol { get; }
        decimal Execute(decimal firstArg, decimal secondArg);
    }
}
