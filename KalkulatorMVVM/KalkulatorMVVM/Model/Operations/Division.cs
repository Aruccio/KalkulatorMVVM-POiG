using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorMVVM.Model.Operations
{
    class Division : IOperation
    {
        public string Name { get; private set; } = "Division";
        public string Symbol { get; private set; } = "/";
        public decimal Execute(decimal first, decimal sec)
        {
            return (sec == 0.0M) ?
                throw new DivideByZeroException("Nie można dzielić przez zero") :
            first / sec;
        }
    }
}
