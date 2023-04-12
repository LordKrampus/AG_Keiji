/*
using System;
using System.Text;
using AG.Estruturas.Interfaces;

namespace AG.Estruturas.Binary
{
    public class BinaryGene : IChromosome<BinaryGene>
    {
        // atributos
        private BinaryGene[] _genes;
        private double _fitness;

        // propriedades
        public BinaryGene[] Genes 
        {
            get => this._genes;
            set => this._genes = value;
        }

        public double Fitness
        {
            get => this._fitness;
            set => this._fitness = value;
        }

        public double Value
        {
            get
            {
                int value = 0;
                int size = this.Genes.Length - 1;
                
                for (int i = 0; i <= size; i++)
                {
                    if (Genes[i].Value)
                        value += (int)Math.Pow(2, size - i); 
                }

                return value;
            }
        }

        public BinaryGene(int size)
        {
            this._genes = new BinaryGene[size];

            bool value;
            Utilities.Sorter rand;

            // inicializar genees com valores aleatórios
            rand = new Utilities.Sorter();
            for (int i = 0; i < size; i++)
            {
                value = rand.SortBinary();
                this.Genes[i] = new BinaryGene(value);
            }

            //this.CalcFitness();
        }

        public BinaryGene(BinaryGene[] genes)
        {
            this._genes = genes;

            //this.CalcFitness();
        }

        public void CalcFitness() 
        {  
            this._fitness = 0;
        }

        public void RightSwap(int first, IChromosome<BinaryGene> pair)
        {
            int size = this.Genes.Length;
            if ((pair.Genes.Length + first) < size) 
                throw new ArgumentOutOfRangeException("values of swapping is lesser than the block size enable");

            BinaryGene aux;
            for (int i = first; i < size; i++)
            {
                aux = this.Genes[i];
                this.Genes[i] = pair.Genes[i];
                pair.Genes[i] = aux;
            }
        }

        public void LeftSwap(int last, IChromosome<BinaryGene> pair)
        {
            if(this.Genes.Length < last) 
                throw new ArgumentOutOfRangeException("values of swapping is better than the block size enable");

            BinaryGene aux;
            for (int i = 0; i < last; i++)
            {
                aux = this.Genes[i];
                this.Genes[i] = pair.Genes[i];
                pair.Genes[i] = aux;
            }
        }

        public void ValueSwap(int inGene, BinaryGene newValue)
        {
            this._genes[inGene] = newValue;
            this._fitness = 0;
        }

        public BinaryGene GenerateGene(object value)
        {
            return new BinaryGene((bool)value);
        }

        public IChromosome<BinaryGene> Clone()
        {
            return (IChromosome<BinaryGene>)this.MemberwiseClone();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (BinaryGene gene in this.Genes)
                sb.Append(" " + gene.ToString());

            return $".String:{sb.ToString()} .Value: {this.Value} .Fitness: {this.Fitness}";
        }
    }
}

*/
