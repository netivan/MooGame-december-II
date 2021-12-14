using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MooGame.Interfaces
{
    public class FileIO : IFileInterface
    {

        public void save(string s, string fileName = "results.txt")
        {
            StreamWriter output = new StreamWriter(fileName, append: true);
            output.WriteLine(s);
            output.Close();
        }


        public StreamReader ReadFile(string fileName = "results.txt")
        {

            StreamReader input = new StreamReader(fileName);


            return input;
        }


    }
}
