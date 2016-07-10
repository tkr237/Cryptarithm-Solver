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
            string query = "send + more = money";
            Solver s = new Solver(query);
            List<char[]> permutations = s.DeriveAllPermutations(new List<char>(), new List<char> { 's', 'e', 'n', 'd', 'm', 'o', 'r', 'x', 'y', 'z' });
            #endregion
            #region logic + logic = prolog
            //string query = "logic + logic = prolog";
            //SendMoreMoney s = new SendMoreMoney(query);
            //List<char[]> permutations = s.DeriveAllPermutations(new List<char> { 'l', 'o', 'g', 'i','c','p','r','a','b','d' });
            #endregion
            #region kyoto + osaka = tokyo
            //string query = "kyoto + osaka = tokyo";
            //Solver s = new Solver(query);
            //List<char[]> permutations = s.DeriveAllPermutations(new List<char> { 'k', 'y', 'o', 't', 's', 'a', 'g', 'h', 'i', 'j' });
            #endregion

            //string query = "ab + ba = cc";
            //Solver s = new Solver(query);
            //List<char[]> permutations = s.DeriveAllPermutations(new List<char>(), new List<char>() { 'a', 'b', 'c','d' });

            s.TestPermutation(permutations);
            Console.ReadKey();
        }
    }
}


