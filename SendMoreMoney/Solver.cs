using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SendMoreMoney
{
    class Solver
    {
        List<char[]> permutations = new List<char[]>();
        string equation;

        public Solver(string equation)
        {
            this.equation = equation;
        }

        public List<char[]> DeriveAllPermutations(List<char> beginning, List<char> end)
        {
            if (end.Count() == 0)
            {
                permutations.Add(beginning.ToArray());
            }
            else
            {
                for(int i = 0; i < end.Count(); i++)
                {
                    List<char> newBeginning = new List<char>(beginning);
                    List<char> newEnd = new List<char>(end);
                    newBeginning.Add(end[i]);
                    newEnd.RemoveAt(i);
                    DeriveAllPermutations(newBeginning, newEnd);
                }
            }

            return permutations;
        }

        public void TestPermutation(List<char[]> permutations)
        {
            string equationToTest = "";
            foreach (char[] c in permutations)
            {
                Dictionary<char, int> permutationDictionary = new Dictionary<char, int>();
                for (int i = 0; i < c.Length; i++)
                {
                    permutationDictionary.Add(c[i], c.Length - i - 1);         
                }
                equationToTest = ReplaceLettersWithNumbers(permutationDictionary);
                if (TestEquation(equationToTest)) break;
            }

            Console.WriteLine(equationToTest);
        }

        public bool TestEquation(string numberfiedEquation)
        {
            DataTable dt = new DataTable();
            int lefths = Convert.ToInt32(dt.Compute(numberfiedEquation.Split('=')[0], ""));
            int righths = Convert.ToInt32(dt.Compute(numberfiedEquation.Split('=')[1], ""));

            return lefths == righths;
        }

        public string ReplaceLettersWithNumbers(Dictionary<char, int> dict)
        {
            string equationReplacedWithNumbers = equation;
            foreach (var c in dict)
            {
                equationReplacedWithNumbers = equationReplacedWithNumbers.Replace(c.Key.ToString(), c.Value.ToString());
            }

            return equationReplacedWithNumbers;
        }
    }
}
