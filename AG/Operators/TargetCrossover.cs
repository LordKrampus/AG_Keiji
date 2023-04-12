using System;
using AG.Estruturas;
using AG.Estruturas.Interfaces;
using AG.Operations.Interfaces;
using AG.Utilities;

namespace AG.Operations
{
    public class TargetCrossover<T> : Crossover<T> where T : ITargetChromosome
    {
        public TargetCrossover(double factor) : base(factor) { }


        /*
        double[] values = new double[2];
        values[0] = 0;

        int size = Target - 1;
        for (int e = 0; e <= size; e++)
            values[0] += (int)Math.Pow(2, size - e);

        values[1] = 0;
        size = base.Genes.Length - Target - 1;
        for (int e = 0; e < size; e++)
            values[1] += (int)Math.Pow(2, size - e);

        return values;
         */

        public override T[] Apply(T a, T b, int individualSize)
        {
            if (this._factor > 0.01f * this._sorter.SortAfterFirst(100)) return new T[] { a, b };

            IGene[][] aSections = new IGene[4][];
            IGene[][] bSections = new IGene[4][];

            int[] slicePoints = new int[] 
                { this._sorter.SortBeforeLast(a.Target), a.Target, this._sorter.SortBetween(a.Target, individualSize)};
            UtilChromosome.SplitSectionsInChromosome<T>(a, individualSize, slicePoints, 3, out aSections);
            UtilChromosome.SplitSectionsInChromosome<T>(b, individualSize, slicePoints, 3, out bSections);

            UtilChromosome.SwapSectionInChromosome<T>(a, slicePoints[0], bSections[1], a.Target - slicePoints[0]);
            UtilChromosome.SwapSectionInChromosome<T>(a, slicePoints[2], bSections[3], individualSize - slicePoints[2]);

            UtilChromosome.SwapSectionInChromosome<T>(b, slicePoints[0], aSections[1], a.Target - slicePoints[0]);
            UtilChromosome.SwapSectionInChromosome<T>(b, slicePoints[2], aSections[3], individualSize - slicePoints[2]);

            return new T[] { a, b };
        }

    } // end : class (Crossover<>:IOperation<>)
} // end : namespace (*.Operacoes)
