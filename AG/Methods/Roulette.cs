using System;
using System.Collections.Generic;

using AG.Utilities;
using AG.Estruturas.Extra;
using AG.Estruturas.Interfaces;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using AG.Estruturas.Binary;
using AG.Methods.Interfaces;
using AG.Estruturas;

namespace AG.Methods
{
    public class Roulette<T>: ISelectionMethod<T> where T : IChromosome
    {
        private Sorter _sorter;

        private bool _isMinimization;
        private bool _isAllowClonage;

        private double _S; // somatório dos fitness
        private double _C; // cumulado na roleta (cumulativo)
        private double _R; // ersultado da roleta

        private List<PopSizeSlot<T>> _slots;
        private int _populationSize;
        private int _nSlots;

        public bool IsMinimization { get => this._isMinimization; set => this._isMinimization = value; }
        public bool IsAllowClonage { get => this._isAllowClonage; set => this._isAllowClonage = value; }

        public Roulette(bool isMinimization, bool isAllowClonage)
        {
            this._sorter = new Sorter();
            this._isMinimization = isMinimization;
            this._isAllowClonage = isAllowClonage;
        }

        public void SetupPopulation(Individual<T>[] population)
        {
            this._nSlots = population.Length;
            this._populationSize = population.Length;

            this._slots = new List<PopSizeSlot<T>>(this._nSlots);
            for (int i = 0; i < this._nSlots; i++)
                this._slots.Add(new PopSizeSlot<T>(population[i]));

            this.PortionSlots();
        }

        // distribui porções da roleta aos slots
        private void PortionSlots()
        {
            // calcula o somatório das aptidões
            this._S = 0;
            foreach(PopSizeSlot<T> slot in this._slots)
                this._S += slot.Individual.Fitness;

            // calcula probabilidade do slot
            foreach (PopSizeSlot<T> slot in this._slots)
                slot.Probability = slot.Individual.Fitness / this._S;

            // inverte a proporção
            if (this.IsMinimization)
            {
                double sumCheck = 0;
                foreach (PopSizeSlot<T> slot in this._slots)
                {
                    slot.Probability = (1 - slot.Probability) / (this._nSlots - 1);
                    sumCheck += slot.Probability;
                }
            }

            // calcula porção cumulativa da roleta para os slots na proporção de 0 a 1
            this._C = 0;
            foreach (PopSizeSlot<T> slot in this._slots)
            {
                this._C += slot.Probability;
                slot.Cumulative = this._C;
            }
        }

        public Individual<T>[] RunSelection(int selectCount)
        {
            Individual<T>[] individuals = new Individual<T>[selectCount];

            for (int i = 0; i < selectCount; i++)
                individuals[i] = (Individual<T>)this.Spin();

            return individuals;
        }

        protected void SelectSlotAt(int index, out PopSizeSlot<T> slot)
        {
            slot = this._slots.ElementAt(index);
        }

        protected void RemoveSlotAt(int index, bool portion = true)
        {
            this._slots.RemoveAt(index);
            this._nSlots--;

            if (portion)
                this.PortionSlots();
        }

        private Individual<T>? Spin()
        {
            this._R = 0.01f * this._sorter.SortBeforeLast(100);
            //return this.LocateSlot() ?? this.LocateFirstEnableSlot();

            PopSizeSlot<T> slot;
            for (int i = 0; i < this._nSlots; i++)
            {
                this.SelectSlotAt(i, out slot);
                if (slot.Cumulative >= this._R)
                {
                    if (!this.IsAllowClonage)
                        this.RemoveSlotAt(i);
                    return (Individual<T>)slot.Individual.Clone();
                }
            }

            this.SelectSlotAt(this._nSlots - 1, out slot);
            if (!this.IsAllowClonage)
                this.RemoveSlotAt(this._nSlots - 1);

            return (Individual<T>)slot.Individual.Clone();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            double pSum = 0;
            double cSum = 0;

            foreach (PopSizeSlot<T> slot in this._slots) {
                sb.AppendLine(slot.ToString());

                pSum += slot.Probability;
                cSum += slot.Cumulative;
            }

            return $"#Atributos:\n\tS: {this._S}\tC: {this._C}\tR: {this._R}" +
                    $"\tsum. of P: {pSum}\t mean of Fitness: {this._S / this._populationSize}\n" +
                    "#Porções Cumuladas na Roleta:\n" + sb.ToString();
        }

    } // end : class (Roulette<IChromosome,IGene>)

} // end : namespace (AlgoritmosGeneticos.Metodos)


// deprecated:
/*
/// <summary>Localiza o slot na roleta correspondente ao spin.</summary>
private T? LocateSlot()
{
    foreach (PopSizeSlot<T, E> slot in this._slots)
    {
        if (slot.IsEnable && slot.Cumulative >= this._R)
        {
            slot.IsEnable = false;
            return slot.Chromosome;
        }
    }

    return default(T);
}

// Localizar imediatamente o primeiro slot habilitado
private T? LocateFirstEnableSlot()
{
    foreach (PopSizeSlot<T, E> slot in this._slots)
    {
        if (slot.IsEnable)
        {
            slot.IsEnable = false;
            return slot.Chromosome;
        }
    }

    return default(T);
}
*/