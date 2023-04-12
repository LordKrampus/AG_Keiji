using System;
using AG.Estruturas.Binary;

namespace AG.Estruturas.Interfaces
{
    public interface ITargetChromosome : IChromosome
    {
        public int Target { get; }
        public double[] Values { get; }
        public double[] MaxValues { get; }

        public ITargetChromosome Generate(int length);
    }
}
