using System;

using AG.Estruturas.Interfaces;

namespace AG.Estruturas.Extra
{
    public class PopSizeSlot<T> where T : IChromosome
    {   
        private double _probability;
        private double _cumulative;
        private bool _isEnable;

        Individual<T> _individual;

        public double Probability
        {
            get => this._probability;
            set => this._probability = value;
        }

        public double Cumulative
        {
            get => this._cumulative;
            set => this._cumulative = value;
        }

        public bool IsEnable
        {
            get => this._isEnable;
            set => this._isEnable = value;
        }

        public Individual<T> Individual => this._individual;

        public PopSizeSlot(Individual<T> chromosome)
        {
            this._probability = .0f;
            this._cumulative = .0f;
            this._isEnable = true;

            this._individual = chromosome;
        }

        public override string ToString()
        {
            return $"(({this._individual.ToString()}) P:{this.Probability}, C:{this.Cumulative})";
        }
    }
}
