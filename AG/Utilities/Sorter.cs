using System;

namespace AG.Utilities
{
    public class Sorter
    {
        private Random _generator;

        public Sorter()
        {
            this._generator = new Random();
        }

        public bool SortBinary()
        {
            return (this._generator.Next(2) < 1? false : true);
        }

        // inclusivo
        public int SortBeforeLast(int last)
        {
            return this._generator.Next(last + 1);
        }

        public int SortAfterFirst(int first)
        {
            return this._generator.Next() + first;
        }

        public int SortBetween(int first, int last)
        {
            return this._generator.Next(last - first + 1) + first;
        }

    } // end : Sorter

} // end : namespace (.Utilities)
