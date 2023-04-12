using System;

using AG.Functions.Interfaces;
using AG.Estruturas.Interfaces;
using AG.Algoritmos.Factories;
using AG.Estruturas.Binary;
using AG.Methods;
using AG.Operations;
using AG.Methods.Interfaces;
using AG.Operations.Interfaces;
using System.Text;
using AG.Estruturas;

namespace AG.Algoritmos
{
    public class GeneticAlgorithm<T>: IGeneticAlgorithm where T : IChromosome
    {
        protected int _populationSize;
        protected int _individualSize;
        protected int _generationSize;

        protected double _crossoverRate;
        protected double _mutationRate;
        protected IFunction _function;

        private ISelectionMethod<T> _sMethod;
        private IOperator<T>[] _operators;
        private Elitismo<T> _elitismo;

        private bool _hasElitismo;

        protected Individual<T>[] _population;
        protected int _nGenerations;
        private Individual<T>? _bestIndividual;
        private bool _hasFinished;

        private List<IIndividual> _cacheResultBests;
        private List<double> _cacheResultMeans;
        private List<int> _cacheResultGeneration;

        public int PopulationSize => this._populationSize;
        public int IndividualSize => this._individualSize;
        public int GenerationSize => this._generationSize;

        public double CrossoverRate => this._crossoverRate;
        public double MutationRate => this._mutationRate;

        public IIndividual[] Population => this._population;
        public int NGenerations => this._nGenerations;
        public IIndividual? BestIndividual => this._bestIndividual;
        public bool HasFinished => this._hasFinished;

        public double Mean
        {
            get
            {
                double mean = 0;
                double dp = 0;

                foreach (Individual<T> individual in this._population)
                    mean += individual.Fitness;
                mean /= this._populationSize;

                return mean;

                /*
                foreach (Individual<T> individual in this._population)
                    dp += Math.Pow(individual.Fitness - mean, 2);

                return Math.Sqrt(dp / this._populationSize);
                */
            }
        }

        public IIndividual[] CacheResultBests => this._cacheResultBests.ToArray();
        public double[] CacheResultMeans => this._cacheResultMeans.ToArray();

        public GeneticAlgorithm(int populationSize, int individualSize, int generationSize, double crossoverRate, double mutationRate,
            IFunction function, ISelectionMethod<T> selectionMethods, IOperator<T>[] operators, bool hasElitismo = false)
        {
            this._populationSize = populationSize;
            this._individualSize = individualSize;
            this._generationSize = generationSize;

            this._crossoverRate = crossoverRate;
            this._mutationRate = mutationRate;

            this._function = function;

            this._sMethod = selectionMethods;
            this._operators = operators;

            this._hasElitismo = hasElitismo;
            this._elitismo = new Elitismo<T>();

            this._nGenerations = 0;
            this._bestIndividual = null;
            this._hasFinished = false;

            this._cacheResultBests = new List<IIndividual>();
            this._cacheResultMeans = new List<double>();
            this._cacheResultGeneration = new List<int>();

            this.StartPopulation(typeof(T));
            this.EvaluatePopulation();
        }

        public void StartPopulation(Type t)
        {
            PopulationFactory fAG = PopulationFactory.Instance;
            this._population = fAG.CreatePopulation<T>(t, this.PopulationSize, this.IndividualSize);
        }

        public virtual double CalcFitness(Individual<T> individual)
        {
            return this._function.Calc(individual);
        }

        public virtual bool EvaluatePopulation()
        {
            Individual<T> individual;
            Individual<T> bestIndividual;

            bestIndividual = this._population[0];
            bestIndividual.Fitness = this.CalcFitness(bestIndividual);
            for (int i = 1; i < this.PopulationSize; i++)
            {
                individual = this._population[i];

                individual.Fitness = this.CalcFitness(individual);
                if (bestIndividual.Fitness < individual.Fitness && !this._sMethod.IsMinimization ||
                    individual.Fitness < bestIndividual.Fitness && this._sMethod.IsMinimization )
                    bestIndividual = individual;
            }

            this._cacheResultBests.Add((Individual<T>)bestIndividual.Clone());
            this._cacheResultMeans.Add(this.Mean);
            this._cacheResultGeneration.Add(this.NGenerations);

            if (this._bestIndividual == null ||
                this._bestIndividual.Fitness < bestIndividual.Fitness && !this._sMethod.IsMinimization ||
                bestIndividual.Fitness < this._bestIndividual.Fitness && this._sMethod.IsMinimization)
            {
                this._bestIndividual = bestIndividual;
            }

            return this.NGenerations < this.GenerationSize;
        }

        public void Run()
        {
            if (Population == null) throw new ArgumentException("População não inicializada corretamente.");
            this._hasFinished = false;

            this.EvaluatePopulation();
            this._nGenerations++;

            Individual<T>[] individuals = new Individual<T>[2];
            while (!HasFinished)
            {
                this.RunStep(individuals);
                this._nGenerations++;
            }
        }

        public void RunStep(IIndividual[] individuals)
        {
            this.RunStep((Individual<T>[])individuals);
        }

        public void RunStep(Individual<T>[] individuals)
        {
            int eLimit;
            T[] chromosomes = new T[2];

            this._sMethod.SetupPopulation(this._population.ToArray());

            int i = 0;
            if (this._hasElitismo)
            {
                for(; i < 2; i++)
                    this._population[i] = this._elitismo.Proced(this._population, this._sMethod.IsMinimization);   
            }

            for (; i < this.PopulationSize; i += 2)
            {
                individuals = this._sMethod.RunSelection(2); //!!! 2

                eLimit = this._operators.Length;
                for (int e = 0; e < eLimit; e++)
                {
                    chromosomes = this._operators[e].Apply(new object[] { individuals[0].Chromosome, individuals[1].Chromosome, this.IndividualSize });
                }

                this._population[i] = individuals[0];
                this._population[i + 1] = individuals[1];
            }

            if (!this.EvaluatePopulation())
                this._hasFinished = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i =0; i < this._nGenerations; i++)
                sb.Append($"# Generation ({this._cacheResultGeneration[i]}): "+ this._cacheResultBests[i].ToString() + " .Mean: " + this._cacheResultMeans[i] + "\n");

            return sb.ToString();
        }

    } // end : abstract class (AG)

} // end : namespace(*.Algoritmos)
