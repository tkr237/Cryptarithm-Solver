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
            //List<Assignment> permutations = s.Permutations(new List<int>(), new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, new List<char>() { 's', 'e', 'n', 'd', 'm', 'o', 'r', 'y' });
            #endregion
            #region logic + logic = prolog
            //string query = "logic + logic = prolog";
            //Solver s = new Solver(query);
            //List<Assignment> permutations = s.Permutations(new List<int>(), new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, new List<char> { 'l', 'o', 'g', 'i', 'c', 'p', 'r', });
            #endregion
            #region kyoto + osaka = tokyo
            string query = "kyoto + osaka = tokyo";
            Solver s = new Solver(query);
            List<Assignment> permutations = s.Permutations(new List<int>(), new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, new List<char> { 'k', 'y', 'o', 't', 's', 'a', });
            #endregion

            s.TestPermutation(permutations);
            Console.ReadKey();
        }
    }
}