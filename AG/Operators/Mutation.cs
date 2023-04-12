using System;

using AG.Utilities;
using AG.Operations.Interfaces;
using AG.Estruturas.Interfaces;
using AG.Estruturas;
using AG.Estruturas.Binary;

namespace AG.Operations
{
    public class Mutation<T> : IOperator<T> where T : IChromosome
    {
        protected Sorter _sorter;
        protected double _factor;

        public double Factor
        {
            get => this._factor;
            set => this._factor = value;
        }

        public Mutation(double factor)
        {
            this._sorter = new Sorter();
            this._factor = factor;
        }

        public T[] Apply(object[] parameters)
        {
            T[] mutations = new T[parameters.Length - 1];
            for (int i = 0; i < parameters.Length - 1; i++)
            {
                mutations[i] = this.Apply((T)parameters[i], (int)parameters[parameters.Length - 1]);
            }

            return mutations;
        }

        public virtual T Apply(T a, int individualSize)
        {
            if (this._factor > 0.01f * this._sorter.SortAfterFirst(100)) return a;

            int mutationPoint = this._sorter.SortBeforeLast(individualSize - 1);

            UtilChromosome.InvertValueInChromossome<T>(a, mutationPoint);

            return a;
        } 
    }
}
