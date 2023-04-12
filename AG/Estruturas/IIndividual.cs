using AG.Estruturas.Interfaces;
using System;

namespace AG.Estruturas
{
    public interface IIndividual : ICloneable
    {
        public double Fitness { get; }
        public IChromosome Chromosome { get; }
        public double Value => this.Chromosome.Value;

        public object Clone();
    }
}
