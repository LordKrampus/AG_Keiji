using AG.Functions.Interfaces;
using System;

namespace AG.Functions
{
    /*
    public class InverseFunctionCapsule : AFunctionCapsule
    {
        public InverseFunctionCapsule(IFunction function) : base(function) { }

        public override double Calc(object[] variables, bool applyFactor = true)
        {
            return base.Function.Calc(variables, applyFactor) * (-1); 
                // escopo reduzido (subestima uma única variável : x)
        }

        /*
        public override void Calc(double x, out double y, bool applyFactor = true)
        {
            base.Function.Calc(x, out y, applyFactor);
            y *= -1;
        }

        public override void Calc(double x, double y, out double z, bool applyFactor = true)
        {
            throw new NotImplementedException();
        }

    } 
        */
}
