using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DPHAlgorithmProject.code
{
    public static class ByteConverter
    {
        public static string ByteToBinaryString(byte byteIn)
        {
            StringBuilder out_string = new StringBuilder();
            byte mask = 128;
            for (int i = 7; i >= 0; --i)
            {
                out_string.Append((byteIn & mask) != 0 ? "1" : "0");
                mask >>= 1;
            }
            return out_string.ToString();
        }
    }
}