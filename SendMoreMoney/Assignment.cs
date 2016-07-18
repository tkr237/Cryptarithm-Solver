using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SendMoreMoney
{
    [Serializable]
    public class Assignment
    {
        public Dictionary<char, int> assignment;

        public Assignment()
        {
            assignment = new Dictionary<char, int>();
        }

        public override string ToString()
        {
            string s = "{{ ";
            foreach(KeyValuePair<char, int> k in assignment)
            {
                s += "[" + k.Key.ToString() + " " + k.Value + "], ";
            }
            s += "}}";
            return s;
        }

        public static Assignment DeepClone(Assignment obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (Assignment)formatter.Deserialize(ms);
            }
        }
    }
}
