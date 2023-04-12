using AG.Estruturas;
using AG.Estruturas.Interfaces;
using System;

namespace AG.Algoritmos
{
    public interface IGeneticAlgorithm
    {
        public int PopulationSize { get; }
        public int IndividualSize { get; }
        public int GenerationSize { get; }

        public double CrossoverRate { get; }
        public double MutationRate { get; }

        public IIndividual[] Population { get; }
        public int NGenerations { get; }
        public IIndividual? BestIndividual { get; }
        public bool HasFinished { get; }

        public double Mean { get; }

        public IIndividual[] CacheResultBests { get; }
        public double[] CacheResultMeans { get; }

        public void Run();
        public void RunStep(IIndividual[] individuals);
        
    }
}
