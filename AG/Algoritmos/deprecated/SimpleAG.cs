/*
using AG.Estruturas.Binary;
using AG.Estruturas.Interfaces;
using AG.Methods;
using AG.Operations;
using AG.Utilities;
using System;
using System.Numerics;
using System.Text;

namespace AG.Algoritmos.deprecate
{
    public class SimpleAG : AG<BinaryChromosome, BinaryGene>
    {
        private Sorter _sorter;
        private int _convergenceLimit;
        private int _convergenceCount;

        private float _cacheBestFitness;
        private int _bestGenerationIndex;
        private float _fitnessFactor;

        private Stack<string> _cacheBestIndividual;
        private Stack<float> _cacheMeasure;

        public string BestIndividual
        {
            get { return _cacheBestIndividual.ElementAt(_bestGenerationIndex); }
        }

        public SimpleAG(int populationSize, int individualSize, int nGenerations, float crossoverRate, float mutationRate, float fitnessFactor, int convergenceLimit = 50)
            : base(populationSize, individualSize, nGenerations, crossoverRate, mutationRate)
        {
            _sorter = new Sorter();
            _convergenceLimit = convergenceLimit;
            _convergenceCount = 0;

            _cacheBestFitness = float.MaxValue;
            _bestGenerationIndex = -1;
            _fitnessFactor = fitnessFactor;

            _cacheBestIndividual = new Stack<string>();
            _cacheMeasure = new Stack<float>();
            _cacheMeasure.Push(-1);

            StartPopulation(typeof(BinaryChromosome));
        }

        /*
        public override float CalcFitness(BinaryChromosome individual)
        {
            float x = (individual.Value) * this._fitnessFactor;
            return (float)Math.Abs(x * Math.Sin(Math.Sqrt(x)));
        }


        public override bool EvaluatePopulation()
        {
            // atualiza valor e avalia melhor fitness
            float bestFitness = float.MaxValue;
            BinaryChromosome bestIndividual = null;

            foreach (BinaryChromosome individual in Population)
            {
                individual.Fitness = base.CalcFitness(individual);

                if (individual.Fitness < bestFitness)
                {
                    bestFitness = individual.Fitness;
                    bestIndividual = individual;
                }
            }

            // avalia uma estagnação do algoritmo
            if (bestFitness >= _cacheBestFitness)
            {
                _cacheBestFitness = bestFitness; // index
                _bestGenerationIndex = NGenerations - 1;
                _convergenceCount++;
            }

            int i = NGenerations - 1;
            //.FITNESS: 6,552288 	.X: 361 	.GENERATION: 0 	.MEASURE: 156,87743
            _cacheMeasure.Push(base.Measure);
            _cacheBestIndividual.Push($".FITNESS:{bestIndividual.Fitness} \t.X: {bestIndividual.Value * _fitnessFactor} \t.Generation: {NGenerations} \t.Measure: {base.Measure}");

            return NGenerations < GenerationSize && _convergenceCount < _convergenceLimit;
        }

        public override void Run()
        {
            if (Population == null) throw new ArgumentException("População não inicializada corretamente.");

            Roulette<BinaryChromosome, BinaryGene> sMethod = new Roulette<BinaryChromosome, BinaryGene>();
            Crossover<BinaryChromosome, BinaryGene> opCrossover = new Crossover<BinaryChromosome, BinaryGene>(CrossoverRate);
            Mutation<BinaryChromosome, BinaryGene> opMutation = new Mutation<BinaryChromosome, BinaryGene>(MutationRate);

            int SpinTimes = PopulationSize / 2;
            BinaryChromosome[] individuals = new BinaryChromosome[2];

            while (EvaluatePopulation())
            {
                _nGenerations++;

                sMethod.SetUp(Population);
                for (int i = 0; i < SpinTimes; i++)
                {
                    individuals = sMethod.RunSelection(2);

                    individuals = opCrossover.Apply(IndividualSize, individuals[0], individuals[1]);

                    individuals[0] = opMutation.Apply(IndividualSize, individuals[0]);
                    individuals[1] = opMutation.Apply(IndividualSize, individuals[1]);

                    _population[i] = individuals[0];
                    _population[i + SpinTimes] = individuals[1];
                }
            }
        }

        public void RunStep()
        {
            if (Population == null) throw new ArgumentException("População não inicializada corretamente.");

            Roulette<BinaryChromosome, BinaryGene> sMethod = new Roulette<BinaryChromosome, BinaryGene>();
            Crossover<BinaryChromosome, BinaryGene> opCrossover = new Crossover<BinaryChromosome, BinaryGene>(CrossoverRate);
            Mutation<BinaryChromosome, BinaryGene> opMutation = new Mutation<BinaryChromosome, BinaryGene>(MutationRate);

            int SpinTimes = PopulationSize / 2;
            BinaryChromosome[] individuals = new BinaryChromosome[2];

            EvaluatePopulation();
            _nGenerations++;

            sMethod.SetUp(Population);
            for (int i = 0; i < SpinTimes; i++)
            {
                individuals = sMethod.RunSelection(2);

                individuals = opCrossover.Apply(IndividualSize, individuals[0], individuals[1]);

                individuals[0] = opMutation.Apply(IndividualSize, individuals[0]);
                individuals[1] = opMutation.Apply(IndividualSize, individuals[1]);

                _population[i] = individuals[0];
                _population[i + SpinTimes] = individuals[1];
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string item in _cacheBestIndividual)
                sb.Append(item + "\n");

            return sb.ToString();
        }

        public string ToStringStep()
        {
            return _cacheBestIndividual.Peek();
        }

    } // end : class

} // end : namespace
*/