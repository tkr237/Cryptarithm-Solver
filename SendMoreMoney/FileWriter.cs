using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMoreMoney
{
    class FileWriter
    {
        public string path;
        public FileWriter(string path)
        {
            this.path = path;
        }

        public void DeleteFileIfExists()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void WriteToFile(Assignment permutationToWrite)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(permutationToWrite);
            }
        }
    }
}
