using System;
using System.Text;
using AG.Estruturas.Binary;
using AG.Estruturas.Interfaces;

namespace AG.Estruturas
{
    public class Individual<T> : IIndividual where T : IChromosome 
    {
        private T _chromosome;
        private double _fitness;

        public double Fitness { get => this._fitness; set => this._fitness = value; }
        public IChromosome Chromosome 
        { get => this._chromosome as IChromosome; set => this._chromosome = (T)value; }
        public double Value => this._chromosome.Value;

        public Individual(T chromosome)
        {
            this._fitness = .0f;
            this._chromosome = chromosome;
        }

        public object Clone()
        {
            int iSize = this._chromosome.Genes.Length;

            T newChromosome = (T)this._chromosome.Generate(iSize);

            IGene gene;
            IGene newGene;
            for (int i = 0; i < iSize; i ++)
            {
                gene = this._chromosome.Genes[i];

                newGene = (IGene)gene.Generate();
                newGene.Value = gene.Value;

                newChromosome.Genes[i] = newGene; 
            }

            Individual<T> newIndividual = new Individual<T>(newChromosome);
            newIndividual.Fitness = this.Fitness;
            return newIndividual;
        }

        public override string ToString()
        {
            return $"{this.Chromosome.ToString()} .Fitness: {this.Fitness}";
        }
    }
}
