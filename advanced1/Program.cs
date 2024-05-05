using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chinh
{
    public class Program{
        public static void Main(string[] args)
        {
            Hashtable hash = new Hashtable();
            hash.Add("le dinh", 5);
            foreach(DictionaryEntry entry in hash)
            {
                Console.WriteLine(entry.Key + "=" + entry.Value);
            }
        }
    }
}