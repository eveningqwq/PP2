using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task4 {
    class Program {
        static void Main(string[] args) {
            string path = @"C:\Users\0\source\repos\Week2\test.txt";
            var f = File.Create(path); // create new file
            f.Close(); // close 
            string to = @"C:\Users\0\source\repos\Week2\..\test.txt";
            File.Copy(path, to); // Copy
            File.Delete(path); // delete original
        }
    }
}
