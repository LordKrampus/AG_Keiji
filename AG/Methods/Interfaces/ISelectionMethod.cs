using System;
using AG.Estruturas;
using AG.Estruturas.Interfaces;

namespace AG.Methods.Interfaces
{
    public interface ISelectionMethod<T> where T : IChromosome
    {
        public bool IsMinimization { get; set; }
        public bool IsAllowClonage { get; set; }

        public Individual<T>[] RunSelection(int SelectionSize);
        public void SetupPopulation(Individual<T>[] population);
    }
}
