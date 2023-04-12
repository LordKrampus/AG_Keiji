using System;
using AG.Estruturas;
using AG.Estruturas.Interfaces;
using AG.Operations.Interfaces;
using AG.Utilities;

namespace AG.Operations
{
    public class Crossover<T> : IOperator<T> where T : IChromosome
    {
        protected Sorter _sorter;
        protected double _factor;

        public Crossover(double factor)
        {
            this._sorter = new Sorter();
            this._factor = factor;
        }

        public T[] Apply(object[] parameters)
        {
            return this.Apply((T)parameters[0], (T)parameters[1], (int)parameters[2]);
        }

        public virtual T[] Apply(T a, T b, int individualSize)
        {
            if (this._factor > 0.01f * this._sorter.SortAfterFirst(100)) return new T[] { a, b };

            int slicePoint = this._sorter.SortBeforeLast(individualSize - 1);

            IGene[][] aSections;
            IGene[][] bSections;

            UtilChromosome.SplitSectionsInChromosome<T>(a, individualSize, slicePoint, out aSections);
            UtilChromosome.SplitSectionsInChromosome<T>(b, individualSize, slicePoint, out bSections);

            UtilChromosome.SwapSectionInChromosome<T>(a, slicePoint, bSections[1], individualSize - slicePoint);
            UtilChromosome.SwapSectionInChromosome<T>(b, slicePoint, aSections[1], individualSize - slicePoint);

            return new T[] { a, b };
        }

    } // end : class (Crossover<>:IOperation<>)
} // end : namespace (*.Operacoes)
