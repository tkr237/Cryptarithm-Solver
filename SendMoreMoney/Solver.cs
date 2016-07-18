using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SendMoreMoney
{
    class Solver
    {
        List<Assignment> assignments = new List<Assignment>();
        public FileWriter fw = new FileWriter(Directory.GetCurrentDirectory() + "\\PermutationList.txt");
        string equation;

        public Solver(string equation)
        {
            this.equation = equation;
            fw.DeleteFileIfExists();
        }

        public void permForLetter(Assignment a, char c, List<char> restOfChars, List<int> listOfNumbers)
        {
            a.assignment.Add(c, listOfNumbers[0]);
            listOfNumbers.RemoveAt(0);
            Permutations(a, restOfChars, listOfNumbers);
        }

        public List<Assignment> Permutations(Assignment a, List<char> listOfLetters, List<int> listOfNumbers)
        {
            if (listOfLetters.Count() == 0)
            {
                assignments.Add(Assignment.DeepClone(a));
                //fw.WriteToFile(d);
            }
            else
            {
                for (int i = 0; i < listOfNumbers.Count(); i++)
                {
                    int currentNumber = listOfNumbers[i];
                    char currentCharacter = listOfLetters[0];
                    List<char> restOfChars = new List<char>(listOfLetters);
                    List<int> swappedNumbers = swap(listOfNumbers, currentNumber, i);

                    restOfChars.Remove(currentCharacter);
                    permForLetter(a, currentCharacter, restOfChars, swappedNumbers);
                    a.assignment.Remove(currentCharacter);
                }
            }

            return assignments;
        }

        public List<int> swap(List<int> list, int number, int index)
        {
            List<int> swappedList = new List<int>();
            swappedList.Add(number);
            list.Remove(number);
            swappedList = swappedList.Concat(list).ToList();
            list.Insert(index, number);
            return swappedList;
        }

        public void TestPermutation(List<Assignment> assignments)
        {
            string equationToTest = "";
            foreach (Assignment a in assignments)
            {
                equationToTest = equation;
                foreach (KeyValuePair<char, int> kv in a.assignment)
                {
                    equationToTest = equationToTest.Replace(kv.Key.ToString(), kv.Value.ToString());
                }
                if (isEquivalent(equationToTest)) break;
            }

            Console.WriteLine(equationToTest);
        }

        public bool isEquivalent(string numberfiedEquation)
        {
            DataTable dt = new DataTable();
            int lefths = Convert.ToInt32(dt.Compute(numberfiedEquation.Split('=')[0], ""));
            int righths = Convert.ToInt32(dt.Compute(numberfiedEquation.Split('=')[1], ""));

            return lefths == righths;
        }
    }
}
