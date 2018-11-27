using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPHAlgorithmProject.code
{
    public static class LevenshteinAlgorithm
    {
        public static int GetLevenshteinDistance(String s, String t)
        {    
            if (String.IsNullOrEmpty(s)) return (t ?? "").Length;
            if (String.IsNullOrEmpty(t)) return s.Length;

            // if strings of different lengths, ensure shorter string is in s. This can result in a little
            // faster speed by spending more time spinning just the inner loop during the main processing.
            if (s.Length > t.Length)
            {
                var temp = s; s = t; t = temp; // swap s and t
            }
            int sLen = s.Length; // this is also the minimun length of the two strings
            int tLen = t.Length;

            // suffix common to both strings can be ignored
            while ((sLen > 0) && (s[sLen - 1] == t[tLen - 1])) { sLen--; tLen--; }

            int start = 0;
            if ((s[0] == t[0]) || (sLen == 0))
            { // if there's a shared prefix, or all s matches t's suffix
              // prefix common to both strings can be ignored
                while ((start < sLen) && (s[start] == t[start])) start++;
                sLen -= start; // length of the part excluding common prefix and suffix
                tLen -= start;

                // if all of shorter string matches prefix and/or suffix of longer string, then
                // edit distance is just the delete of additional characters present in longer string
                if (sLen == 0) return tLen;

                t = t.Substring(start, tLen); // faster than t[start+j] in inner loop below
            }
            var v0 = new int[tLen];
            for (int j = 0; j < tLen; j++) v0[j] = j + 1;

            int current = 0;
            for (int i = 0; i < sLen; i++)
            {
                char sChar = s[start + i];
                int left = current = i;
                for (int j = 0; j < tLen; j++)
                {
                    int above = current;
                    current = left; // cost on diagonal (substitution)
                    left = v0[j];
                    if (sChar != t[j])
                    {
                        current++;              // substitution
                        int insDel = above + 1; // deletion
                        if (insDel < current) current = insDel;
                        insDel = left + 1;      // insertion
                        if (insDel < current) current = insDel;
                    }
                    v0[j] = current;
                }
            }
            return current;
        }
    }
}