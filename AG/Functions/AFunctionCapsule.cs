using System;
using AG.Estruturas;
using AG.Estruturas.Interfaces;
using AG.Functions.Interfaces;

namespace AG.Functions
{
    public abstract class AFunctionCapsule: IFunction
    {
        private IFunction _function;

        protected IFunction Function => this._function;

        public double[] Factor { get => this._function.Factor; set => this._function.Factor = value; }

        public AFunctionCapsule(IFunction function) 
        {
            this._function = function;
        }

        public void ApplyFactor(double[] a, out double[] b)
        {
            b = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = a[i] * this.Factor[i];
            }
        }

        public abstract double Calc(object[] variables, bool applyFactor = true);

        public double Calc(object individual)
        {
            throw new NotImplementedException();
        }

        public double Calc<T>(Individual<T> individual) where T : IChromosome
        {
            return this.Calc(individual);
        }

        //public abstract void Calc(double x, out double y, bool applyFactor = true);

        //public abstract void Calc(double x, double y, out double z, bool applyFactor = true);

    } // end : class

} // end : namespace
