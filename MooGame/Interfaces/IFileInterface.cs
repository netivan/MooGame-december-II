using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame
{
    public interface IFileInterface
    {

        public void save(string s, string fileName = "results.txt");
        public StreamReader ReadFile(string fileName = "results.txt");

    }

    
   


    


    
}
