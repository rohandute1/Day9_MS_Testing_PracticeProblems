using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_MS_Testing_PracticeProblems
{
    public class SwapChecker
    {
        public static bool IsEligible(string word1, string word2)
        {
            char[] charArray1 = word1.ToCharArray();
            char[] charArray2 = word2.ToCharArray();
            Array.Sort(charArray1);
            Array.Sort(charArray2);
            return new string(charArray1) == new string(charArray2);
        }
    }
}
