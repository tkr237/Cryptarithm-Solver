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

        public void Assign(List<int> numbers, List<char> letters)
        {
            Assignment perm = new Assignment();
            for (int i = 0; i < numbers.Count(); i++)
            {
                perm.assignment.Add(letters[i], numbers[i]);
            }
            assignments.Add(perm);
            //fw.WriteToFile(perm);
        }

        public List<Assignment> Permutations(List<int> beginning, List<int> end, List<char> letters)
        {
            if (beginning.Count() == letters.Count())
            {
                Assign(beginning, letters);
            }
            else
            {
                for (int i = 0; i < end.Count(); i++)
                {
                    List<int> newBeginning = new List<int>(beginning);
                    List<int> newEnd = new List<int>(end);
                    newBeginning.Add(end[i]);
                    newEnd.RemoveAt(i);
                    Permutations(newBeginning, newEnd, letters);
                }
            }

            return assignments;
        }

        public void TestPermutation(List<Assignment> assignments)
        {
            string equationToTest = "";
            foreach (Assignment a in assignments)
            {
                equationToTest = equation;
                foreach (KeyValuePair<char,int> kv in a.assignment)
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
