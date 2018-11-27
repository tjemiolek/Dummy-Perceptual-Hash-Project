using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPHAlgorithmProject.code
{
    public static class DPHGenerator
    {
        public static byte GenerateDPH()
        {
            byte[] generatedByteArray = new byte[1];
            Random Rand = new Random();
            Rand.NextBytes(generatedByteArray);
            return generatedByteArray[0];
        }
    }
}