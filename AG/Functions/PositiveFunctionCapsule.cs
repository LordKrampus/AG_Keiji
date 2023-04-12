using AG.Functions.Interfaces;
using System;

namespace AG.Functions
{
    /*
    public class PositiveFunctionCapsule : AFunctionCapsule
    {
        public PositiveFunctionCapsule(IFunction function) : base(function) { }

        public override double Calc(object[] variables, bool applyFactor = true)
        {
            return Function.Calc(variables, applyFactor); 
                // escopo reduzido (subestima uma única variável : x)
        }

        /*
        public override void Calc(double x, out double y, bool applyFactor = true)
        {
            this.Function.Calc(x, out y, applyFactor);
            y += x * base.Factor;
        }

        public override void Calc(double x, double y, out double z, bool applyFactor = true)
        {
            throw new NotImplementedException();
        }
        
    } 
    */
}
