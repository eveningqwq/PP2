using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2 {
    class Program {
        static bool Prime(int x) {
            if(x < 2) {
                return false;
            }
            for(int i = 2; i * i <= x; ++i) {
                if(x % i == 0) {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args) {
            FileStream inf = new FileStream(@"C:\Users\0\source\repos\Week2\Task2\input.txt", FileMode.Open, FileAccess.Read);
            FileStream outf = new FileStream(@"C:\Users\0\source\repos\Week2\Task2\output.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader rf = new StreamReader(inf);
            var nums = rf.ReadLine().Split(' ');
            List<int> elems = new List<int>();
            for (int i = 0; i < nums.Length; ++i) {
                int val = Int32.Parse(nums[i]);
                if (Prime(val) == true) {
                    elems.Add(val);
                }
            }
            StreamWriter wf = new StreamWriter(outf);
            for(int i = 0; i < elems.Count; ++i) {
                wf.Write(elems[i] + " ");
            }
            rf.Close();
            wf.Close();
            inf.Close();
            outf.Close();
        }
    }
}
