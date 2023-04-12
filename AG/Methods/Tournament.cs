using AG.Estruturas;
using AG.Estruturas.Interfaces;
using AG.Methods.Interfaces;
using AG.Utilities;
using System;

namespace AG.Methods
{
    public class Tournament<T>: ISelectionMethod<T> where T : IChromosome
    {
        private Sorter _sorter;

        private bool _isMinimization;
        private bool _isAllowClonage;

        private List<Individual<T>> _population;
        private List<Individual<T>> _arena;

        public int _arenaSize;
        public int _populationSize;

        public bool IsMinimization { get => this._isMinimization; set => this._isMinimization = value; }
        public bool IsAllowClonage { get => this._isAllowClonage; set => this._isAllowClonage = value; }

        public Tournament(int arenaSize = 3, bool isMinimization = false, bool isAllowClonage = true) 
        {
            this._sorter = new Sorter();
            this._isMinimization = isMinimization;
            this._isAllowClonage = isAllowClonage;

            this._population = new List<Individual<T>>();
            this._arena = new List<Individual<T>>();

            this._arenaSize = arenaSize;
            this._populationSize = 0;
        }

        public void SetupPopulation(Individual<T>[] population)
        {
            this._population.Clear();
            this._populationSize = population.Length;

            foreach (Individual<T> individual in population)
                this._population.Add(individual);
        }

        public Individual<T>[] RunSelection(int SelectionSize)
        {
            Individual<T>[] individuals = new Individual<T>[SelectionSize];

            for (int i = 0; i < SelectionSize; i++)
                individuals[i] = (Individual<T>)this.Proced();

            return individuals;
        }

        public Individual<T> Proced()
        {
            Individual<T> individual;
            int index;
            for (int i = 0; i < this._arenaSize; i++)
            {
                index = this._sorter.SortBeforeLast(this._populationSize - 1);
                individual = this._population[index];
                //this._population.Remove(individual);

                this._arena.Add(individual);
            }

            individual = this._arena[0];
            for (int i = 1; i < this._arenaSize; i++)
            {
                if (individual.Fitness < this._arena[i].Fitness && !this.IsMinimization ||
                    this._arena[i].Fitness < individual.Fitness && this.IsMinimization)
                {
                    individual = this._arena[i];
                }
            }

            if (!this.IsAllowClonage)
            {
                this._population.Remove(individual);
                this._populationSize--;
            }

            this._arena.Clear();
            return (Individual<T>)individual.Clone();
        }

    }
}
