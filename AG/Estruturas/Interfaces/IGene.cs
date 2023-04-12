using System;

namespace AG.Estruturas.Interfaces
{
    public interface IGene
    {
        public object Value { get; set; }

        public IGene Generate();
    }
}
