using AG.Estruturas.Interfaces;
using System;

namespace AG.Estruturas
{
    public static class UtilChromosome
    {
        public static void InvertValueInChromossome<T>(T chromosome, int point)
            where T : IChromosome
        {
            IGene gene = chromosome.Genes[point];
            gene.Value = !(bool)gene.Value;
            //return chromosome;
        }

        public static void SwapSectionInChromosome<T>(T chromosome, int slicePoint, IGene[] genes,
            int genesCount) where T : IChromosome
        {
            for (int i = 0; i < genesCount; i++)
            {
                chromosome.Genes[slicePoint + i] = genes[i];
            }

            //return chromosome;
        }

        public static void SwapInverseSectionInChromosome<T>(T chromosome, int slicePoint, IGene[] genes,
            int genesCount) where T : IChromosome
        {
            for (int i = 0; i < slicePoint; i++)
            {
                chromosome.Genes[i] = genes[i];
            }

            //return chromosome;
        }

        public static void SplitSectionsInChromosome<T>(T chromosome, int chromosomeSize, int slicePoint, out IGene[][] sections)
            where T : IChromosome
        {
            sections = new IGene[2][];

            sections[0] = new IGene[slicePoint];
            sections[1] = new IGene[chromosomeSize - slicePoint];

            int i = 0;
            for (; i < sections[0].Length; i++)
                sections[0][i] = chromosome.Genes[i];

            for (i = 0; i < sections[1].Length; i++)
            {
                sections[1][i] = chromosome.Genes[i + slicePoint];
            }
        }

        public static void SplitSectionsInChromosome<T>(T chromosome, int chromosomeSize, int[] slicePoints, int slicePointCount, out IGene[][] sections)
            where T : IChromosome
        {
            sections = new IGene[slicePointCount + 1][];

            int i = 0, e = 0;
            int lastSlicePoint = 0;
            for (i = 0; i < slicePointCount; i++)
            {
                sections[i] = new IGene[slicePoints[i] - lastSlicePoint];

                for (e = 0; e < sections[i].Length; e++)
                    sections[i][e] = chromosome.Genes[e + lastSlicePoint];

                lastSlicePoint = slicePoints[i];
            }

            sections[i] = new IGene[chromosomeSize - lastSlicePoint];
            for (e = 0; e < sections[i].Length; e++)
                sections[i][e] = chromosome.Genes[e + lastSlicePoint];
        }

        /*
        public static void SplitSectionsInChromosome(IChromosome<IGene> chromosome, int[] slicePoints, int spCount, out IGene[][] sections)
        {  
            sections = new IGene[spCount + 1][];

            for(int i = 0; i < sections.Length; i++)
            {
                IGene[] section = new IGene[slicePoints[i]];
                for(int e = 0; e < slicePoints[i]; e++)
                    section[e] = chromosome.Genes[slicePoints[i] + e]

                sections[i] = section;

                e = slicePoints[i];
            }
        }
        */

    }
}
