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
        List<char> usedCharacters = new List<char>();
        string equation;

        public Solver(string equation)
        {
            this.equation = equation;
        }

        public List<char[]> DeriveAllPermutations(List<char> input)
        {
            int i;
            char c;

            for (i = 0; i < input.Count; i++)
            {
                c = input.Skip(i).Take(1).ToArray()[0];
                input.RemoveAt(i);
                usedCharacters.Add(c);
                if (input.Count == 0)
                {
                    permutations.Add(usedCharacters.ToArray());
                }
                DeriveAllPermutations(input);
                input.Insert(i, c);
                usedCharacters.RemoveAt(usedCharacters.Count - 1);
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
            int lefths = Convert.ToInt32(dt.Compute(SplitEquation(numberfiedEquation)[0], ""));
            int righths = Convert.ToInt32(dt.Compute(SplitEquation(numberfiedEquation)[1], ""));

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

        public string[] SplitEquation(string equation)
        {
            return equation.Split('=');
        }
    }
}
