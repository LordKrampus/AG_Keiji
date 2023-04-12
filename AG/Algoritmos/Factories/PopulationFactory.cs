using AG.Estruturas;
using AG.Estruturas.Binary;
using AG.Estruturas.Interfaces;
using AG.Utilities;
using System;
using System.Drawing;


namespace AG.Algoritmos.Factories
{
    public class PopulationFactory
    {
        private static PopulationFactory instance;

        private PopulationFactory() { }

        public static PopulationFactory Instance => instance ??= new PopulationFactory();

        public Individual<T>[] CreatePopulation<T>(Type type, int populationSize, int individualSize) where T : IChromosome
        {
            Sorter sorter = new Sorter();

            switch (type)
            {
                case Type t when t.Equals(typeof(TargetBinaryChromosome)):
                    TargetBinaryChromosome tchromosome;
                    BinaryGene[] tgenes;
                    Individual<TargetBinaryChromosome>[] tpopulation = new Individual<TargetBinaryChromosome>[populationSize];

                    for (int i = 0; i < populationSize; i++)
                    {
                        tgenes = new BinaryGene[individualSize];
                        for (int e = 0; e < individualSize; e++)
                        {
                            //gene = chromosome.Genes[e];
                            tgenes[e] = new BinaryGene();
                            tgenes[e].Value = sorter.SortBinary();
                        }

                        tchromosome = new TargetBinaryChromosome(5);
                        tchromosome.Genes = tgenes;

                        tpopulation[i] = new Individual<TargetBinaryChromosome>(tchromosome);
                    }

                    return tpopulation as Individual<T>[];

                case Type t when t.Equals(typeof(BinaryChromosome)):
                    BinaryChromosome chromosome;
                    BinaryGene[] genes;
                    Individual<BinaryChromosome>[] population = new Individual<BinaryChromosome>[populationSize];

                    for (int i = 0; i < populationSize; i++) 
                    {
                        genes = new BinaryGene[individualSize];
                        for (int e = 0; e < individualSize; e++)
                        {
                            //gene = chromosome.Genes[e];
                            genes[e] = new BinaryGene();
                            genes[e].Value = sorter.SortBinary();
                        }

                        chromosome = new BinaryChromosome();
                        chromosome.Genes = genes;

                        population[i] = new Individual<BinaryChromosome>(chromosome);
                    }

                    return population as Individual<T>[];

                default:
                    throw new ArgumentException("Specified type undefined.");
            }
        }

    }
}
