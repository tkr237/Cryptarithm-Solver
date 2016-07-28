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

        public void PermForLetter(Assignment a, char c, List<char> restOfChars, List<int> listOfNumbers)
        {
            a.assignment.Add(c, listOfNumbers[0]);
            listOfNumbers.RemoveAt(0);
            Permutations(a, restOfChars, listOfNumbers);
        }

        public List<Assignment> Permutations(Assignment a, List<char> listOfLetters, List<int> listOfNumbers)
        {
            if (listOfLetters.Count() == 0)
            {
                Assignment assignmentToAdd = Assignment.DeepClone(a);
                assignments.Add(assignmentToAdd);
                //fw.WriteToFile(assignmentToAdd);
            }
            else
            {
                for (int i = 0; i < listOfNumbers.Count(); i++)
                {
                    int currentNumber = listOfNumbers[i];
                    char currentCharacter = listOfLetters[0];
                    List<char> restOfChars = new List<char>(listOfLetters);
                    List<int> swappedNumbers = Swap(listOfNumbers, currentNumber, i);

                    restOfChars.Remove(currentCharacter);
                    PermForLetter(a, currentCharacter, restOfChars, swappedNumbers);
                    a.assignment.Remove(currentCharacter);
                }
            }

            return assignments;
        }

        public List<int> Swap(List<int> list, int number, int index)
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
            bool solutionFound = false;
            string equationToTest = "";
            foreach (Assignment a in assignments)
            {
                equationToTest = equation;
                foreach (KeyValuePair<char, int> kv in a.assignment)
                {
                    equationToTest = equationToTest.Replace(kv.Key.ToString(), kv.Value.ToString());
                }
                if (IsEquivalent(equationToTest))
                {
                    solutionFound = true;
                    printSolution(a, equationToTest);
                    break;
                }
            }
            if (!solutionFound) { Console.WriteLine("No solution found."); }
        }

        public bool IsEquivalent(string numberfiedEquation)
        {
            int operandOne = ConvertStringToInt(numberfiedEquation.Split('=')[0].Split('+')[0].Trim());
            int operandTwo = ConvertStringToInt(numberfiedEquation.Split('=')[0].Split('+')[1].Trim());
            int sum = ConvertStringToInt(numberfiedEquation.Split('=')[1].Trim());

            return operandOne + operandTwo == sum;
        }

        public int ConvertStringToInt(string stringToConvert)
        {
            int sum = 0;
            foreach (char c in stringToConvert)
            {
                sum *= 10;
                sum += c - '0';
            }
            return sum;
        }

        public void PrintSolution(Assignment a, string equationToPrint)
        {
            Console.WriteLine("\nAssignments:");
            foreach(KeyValuePair<char,int> kv in a.assignment)
            {
                Console.WriteLine(kv.Key.ToString() + ": " + kv.Value.ToString());
            }
            Console.WriteLine("\n");
            Console.WriteLine(" {0}", equationToPrint.Split('=')[0].Split('+')[0].Trim());
            Console.WriteLine("+{0}", equationToPrint.Split('=')[0].Split('+')[1].Trim());
            Console.WriteLine("¯¯¯¯¯");
            Console.WriteLine("{0}\n\n", equationToPrint.Split('=')[1].Trim());
        }
        #region Another permutation() method
        //public List<Assignment> Permutations(Assignment a, List<char> listOfLetters, List<int> listOfNumbers)
        //{
        //    if (listOfLetters.Count() == 0)
        //    {
        //        assignments.Add(Assignment.DeepClone(a));
        //    }
        //    else
        //    {
        //        for (int i = 0; i < listOfNumbers.Count(); i++)
        //        {
        //            char current_char = listOfLetters[0];
        //            int current_number = listOfNumbers[i];

        //            a.assignment.Add(current_char, current_number);

        //            List<char> newListLetters = new List<char>(listOfLetters);
        //            List<int> newListNumbers = new List<int>(listOfNumbers);
        //            newListLetters.Remove(current_char);
        //            newListNumbers.Remove(current_number);

        //            Permutations(a, newListLetters, newListNumbers);

        //            a.assignment.Remove(current_char);
        //        }
        //    }

        //    return assignments;
        //}
        #endregion
    }
}
