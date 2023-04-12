using System;
using AG.Estruturas.Binary;

namespace AG.Estruturas.Interfaces
{
    public interface IChromosome
    {
        public IGene[] Genes { get; set; }
        public double Value { get; }
        public double MaxValue { get; }

        public IChromosome Generate(int length);
    }
}
