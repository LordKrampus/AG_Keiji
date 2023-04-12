using System;
using System.Runtime.CompilerServices;
using AG.Estruturas.Interfaces;

namespace AG.Estruturas.Binary
{
    public static class UtilBinaryGene
    {
        public static void IntForBool(int a, out bool b)
        {
            b = (a < 1 ? false : true);
        }

        public static void BoolForInt(bool a, out int b)
        {
            b = ( a ? 1: 0);
        }

    } // end : class (Gene : IGene)

} // end : namespace (.Binary)
