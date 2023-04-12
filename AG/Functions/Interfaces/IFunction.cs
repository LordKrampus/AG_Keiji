using AG.Estruturas;
using AG.Estruturas.Interfaces;

namespace AG.Functions.Interfaces
{
    public interface IFunction
    {
        public double[] Factor { get; set;  }

        public void ApplyFactor(double[] a, out double[] b);

        public double Calc(object[] variables, bool applyFactor = true);

        public double Calc(object individual);

        public double Calc<T>(Individual<T> individual) where T : IChromosome;

        // f(x) : y
        //public void Calc(double x, out double y, bool applyFactor = true);

        // f(x, y) : z
        //public void Calc(double x, double y, out double z, bool applyFactor = true);
    }
}
