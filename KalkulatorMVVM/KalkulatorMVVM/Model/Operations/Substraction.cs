using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorMVVM.Model.Operation
{
    class Substraction : IOperation
    {
        public string Name { get; private set; } = "Substraction";
        public string Symbol { get; private set; } = "-";
        public decimal Execute(decimal first, decimal sec)
        {
            return first - sec;
        }
    }
}
