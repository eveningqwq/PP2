using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task3 {
    class Program {
        static void Print(FileSystemInfo dir, int depth) {
            if(dir == null) {
                return;
            }
            string s = new string('\t', depth) + dir.Name; // print depth tabs and name

            Console.WriteLine(s);
            if(dir.GetType() == typeof(DirectoryInfo)) { // If this is folder
                foreach(var i in (dir as DirectoryInfo).GetFileSystemInfos()) {
                    Print(i, depth + 1);
                }
            }
        }
        static void Main(string[] args) {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\0\source\repos\Week2");
            Print(dir, 0);

        }
    }
}
