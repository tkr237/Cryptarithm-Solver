using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMoreMoney
{
    public class SendMoreMoney
    {
        public static void Main(String[] args)
        {
            #region send + more = money
            //string query = "send + more = money";
            //Solver s = new Solver(query);
            //List<Assignment> permutations = s.Permutations(new Assignment(), new List<char>() { 's', 'e', 'n', 'd', 'm', 'o', 'r', 'y' }, new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });
            #endregion
            #region logic + logic = prolog
            //string query = "logic + logic = prolog";
            //Solver s = new Solver(query);
            //List<Assignment> permutations = s.Permutations(new Assignment(), new List<char> { 'l', 'o', 'g', 'i', 'c', 'p', 'r', }, new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });
            #endregion
            #region kyoto + osaka = tokyo
            //string query = "kyoto + osaka = tokyo";
            //Solver s = new Solver(query);
            //List<Assignment> permutations = s.Permutations(new Assignment(), new List<char> { 'k', 'y', 'o', 't', 's', 'a', }, new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });
            #endregion

            //string query = "ab + ba = cc";
            //Solver s = new Solver(query);
            //List<Assignment> permutations = s.Permutations(new Assignment(), new List<char>() { 'a', 'b', 'c', 'd' }, new List<int>() { 1, 2, 3, 4, 5 });

            //s.TestPermutation(permutations);
            //Console.ReadKey();

            while (true)
            {
                Console.WriteLine("Enter puzzle: ");
                string query = Console.ReadLine();
                Solver s = new Solver(query);
                List<Assignment> permutations = s.Permutations(new Assignment(), new List<char>(query.Where(u => Char.IsLetter(u)).Distinct().ToList()), new List<int>() { 9,8,7,6,5,4,3,2,1,0 });
                s.TestPermutation(permutations);
            }
        }
    }
}
