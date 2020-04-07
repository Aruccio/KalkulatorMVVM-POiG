using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorMVVM.Model.Operations
{
    class Addition : IOperation
    {
        public string Name { get; private set; } = "Addition";
        public string Symbol { get; private set; } = "+";
        public decimal Execute(decimal first, decimal sec)
        {
            return  first + sec;
        }
    }
}
