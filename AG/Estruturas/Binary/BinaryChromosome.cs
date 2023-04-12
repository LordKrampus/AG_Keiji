using System;
using System.Text;

using AG.Estruturas.Interfaces;

namespace AG.Estruturas.Binary
{
    public class BinaryChromosome : IChromosome
    {
        private BinaryGene[] _genes;
        private double _value;

        public IGene[] Genes { get => (IGene[])_genes; set => _genes = (BinaryGene[])value; }

        public double Value
        {
            get
            {
                int value = 0;
                int size = Genes.Length - 1;

                for (int i = 0; i <= size; i++)
                    if ((bool)Genes[i].Value)
                        value += (int)Math.Pow(2, size - i);

                return value;
            }
        }

        public double MaxValue
        {
            get
            {
                int value = 0;
                int size = Genes.Length - 1;

                for (int i = 0; i <= size; i++)
                    value += (int)Math.Pow(2, size - i);

                return value;
            }
        }

        public virtual IChromosome Generate(int length) 
        {
            BinaryChromosome b = new BinaryChromosome();
            b.Genes = new BinaryGene[length];

            return b;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (BinaryGene gene in this.Genes)
                sb.Append(" " + gene.ToString());

            return $".String:{sb.ToString()} .Value: {this.Value}";
        }
    } // end : struct
} // end : namespace
