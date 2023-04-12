using System;

using AG.Estruturas.Interfaces;

namespace AG.Estruturas.Binary
{
    public class BinaryGene : IGene
    {
        private bool _value;

        public object Value { get => this._value; set => this._value = (bool)value; }

        public IGene Generate() {
            return new BinaryGene();
        }

        public override string ToString()
        {
            int b;
            UtilBinaryGene.BoolForInt((bool)this.Value, out b);
            return $"{b}";
        }
    }
}
