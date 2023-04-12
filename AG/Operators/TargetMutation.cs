using System;

using AG.Utilities;
using AG.Operations.Interfaces;
using AG.Estruturas.Interfaces;
using AG.Estruturas;
using AG.Estruturas.Binary;

namespace AG.Operations
{
    public class TargetMutation<T>: Mutation<T> where T : ITargetChromosome
    {
        public TargetMutation(double factor) : base(factor) { }

        public override T Apply(T a, int individualSize)
        {
            if (this._factor > 0.01f * base._sorter.SortAfterFirst(100)) return a;

            int[] mutationPoints = new int[] { this._sorter.SortBeforeLast(a.Target - 1), this._sorter.SortBetween(a.Target, individualSize - 1)};

            UtilChromosome.InvertValueInChromossome<T>(a, mutationPoints[0]);
            UtilChromosome.InvertValueInChromossome<T>(a, mutationPoints[1]);

            return a;
        } 
    }
}
