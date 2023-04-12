using System;
using AG.Estruturas;
using AG.Estruturas.Interfaces;

namespace AG.Algoritmos
{
    public class Elitismo<T> where T : IChromosome
    {
        public Elitismo() { }

        public Individual<T> Proced(Individual<T>[] population, bool isMinimization)
        {
            int populationSize = population.Length;
            Individual<T> bestIndividual;

            bestIndividual = population[0];
            for (int i = 1; i < populationSize; i++)
            {
                if (bestIndividual.Fitness < population[i].Fitness && !isMinimization ||
                    population[i].Fitness < bestIndividual.Fitness && isMinimization)
                    bestIndividual = population[i];
            }

            return (Individual<T>)bestIndividual.Clone();
        }

    }
}
