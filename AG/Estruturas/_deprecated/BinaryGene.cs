using System;
using System.Runtime.CompilerServices;
using AG.Estruturas.Interfaces;

/*
namespace AG.Estruturas.Binary
{
    public static struct BinaryGene : IGene
    {
        private bool _value = false;

        public bool Value 
        {
            get => this._value;
            private set => this._value = value;
        }

        public BinaryGene(bool value)
        {
            this._value = value;
        }

        public BinaryGene(int value)
        {
            this._value = this.IntForBool(value);
        }

        public object GetValue()
        {
            return this.Value;
        }

        public void SetValue(object newValue)
        {
            this.Value = (bool)newValue;
        }

        public void SetValue(int newValue)
        {
            this.Value = this.IntForBool(newValue);
        }

        private bool IntForBool(int value)
        {
            return (value < 1 ? false : true);
        }

        private int BoolForInt(bool value)
        {
            return (value ? 1: 0);
        }

        public override string ToString()
        {
            return $"{this.BoolForInt(this.Value)}";
        }

    } // end : class (Gene : IGene)

} // end : namespace (.Binary)
*/