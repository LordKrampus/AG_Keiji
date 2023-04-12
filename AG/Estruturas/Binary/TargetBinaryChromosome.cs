using System;
using System.Text;

using AG.Estruturas.Interfaces;

namespace AG.Estruturas.Binary
{
    public class TargetBinaryChromosome : BinaryChromosome, ITargetChromosome
    {
        private int _target = -1;

        public int Target => this._target;

        public double[] Values
        {
            get
            {
                double[] values = new double[2];
                values[0] = 0;

                int size = Target - 1;
                for (int e = 0; e <= size; e++)
                    if ((bool)Genes[e].Value)
                        values[0] += (int)Math.Pow(2, size - e);

                values[1] = 0;
                size = base.Genes.Length - Target - 1;
                for (int e = 0; e <= size; e++)
                    if ((bool)Genes[e + Target].Value)
                        values[1] += (int)Math.Pow(2, size - e);

                return values;
            }
        }

        public double[] MaxValues
        {
            get
            {
                double[] values = new double[2];
                values[0] = 0;

                int size = Target - 1;
                for (int e = 0; e <= size; e++)
                    values[0] += (int)Math.Pow(2, size - e);

                values[1] = 0;
                size = base.Genes.Length - Target - 1;
                for (int e = 0; e <= size; e++)
                    values[1] += (int)Math.Pow(2, size - e);

                return values;
            }
        }

        public TargetBinaryChromosome(int target) : base()
        {
            this._target = target;
        }

        public override ITargetChromosome Generate(int length)
        {
            TargetBinaryChromosome b = new TargetBinaryChromosome(this._target);
            b.Genes = new BinaryGene[length];

            return b;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int length = base.Genes.Length;
            for (int i = 0; i < length; i++)
            {
                if (i == this.Target)
                    sb.Append("| ");
                sb.Append(base.Genes[i].ToString() + " ");
            }

            double[] values = this.Values;
            return $".String:{sb.ToString()} .Value x: {values[0]} .Values y: {values[1]}";
        }
    } // end : struct
} // end : namespace
