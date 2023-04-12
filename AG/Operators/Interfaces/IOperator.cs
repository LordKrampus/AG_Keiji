using AG.Estruturas;
using AG.Estruturas.Interfaces;

namespace AG.Operations.Interfaces
{
    public interface IOperator<T> where T : IChromosome
    {
        public T[] Apply(object[] paramameters);
    }
}
