using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVVM.Model
{
    using Operations;
    class Calculator
    {
        public List<IOperation> Operations { get; } = new List<IOperation>();

        public void AddOperation(IOperation operation) 
        {
            if(!Operations.Contains(operation))
            {
                Operations.Add(operation);
            }
        }

        public string[] SymbolsOfOoperations {
            get {
                if (Operations.Count == 0) throw new Exception("Nie zdefiniowano, żednych operacji");
                string[] res =new string[Operations.Count];
                for (int i = 0; i < res.Length; i++)
                    res[i] = Operations[i].Symbol.ToString();
                return res;
            }
        }

        public decimal ExceuteOperationBySymbol(string symbol, decimal firstArg, decimal secondArg)
        {
            foreach (var op in Operations)
            {
                if (op.Symbol == symbol) return Calculate(op, firstArg, secondArg);       
            }
            throw new Exception("Brak operacji o podanym symbolu");
        }

        public decimal Calculate(Operations.IOperation operation, decimal firstArg, decimal secondArg)
        {
            return operation.Execute(firstArg, secondArg);
        }
    }
}
