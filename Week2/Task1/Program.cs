using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2 {
    class Program {

        static bool palindrome(string x) {
            for (int i = 0; i < x.Length; ++i) {
                if (x[i] != x[x.Length - i - 1]) {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args) {
            FileStream fs = new FileStream(@"C:\Users\0\source\repos\Week2\Task1\input.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadLine();
            if (palindrome(s)) {
                Console.WriteLine("YES");
            } else {
                Console.WriteLine("NO");
            }
            fs.Close();
            sr.Close();
        }
    }
}
