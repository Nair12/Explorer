using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
    static internal class Parse
    {

        static public string TryParsePath(string input) {

            var first = input.IndexOf('"');

            var last = input.LastIndexOf('"');
            
            if (first != -1 && last !=-1)
            {
                return input.Substring(first + 1, last - first - 1);
            }
            else
            {
                return ".";
            }
        
        }
       
        
        static public string TryParseCommand(string input)
        {
            var command = input.Split(' ');
             
            return command[0];
            


        }


    }
}
