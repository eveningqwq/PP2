using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1 {
    class Program {
        static bool Prime(int x) {
            if(x < 2) {
                return false; // It's obvious if x < 2 answer is zero
            }
            for(int i = 2; i < x; ++i) { // Check if there is divisor in range [2, x - 1]
                if(x % i == 0) {
                    return false; // Not prime because i divides x
                }
            }
            return true; // Prime
        }
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine()); // Read number of integers
            string[] a = Console.ReadLine().Split(' '); // Read string and seperate it into n strings using split
            List<int> Answer = new List<int>(); // Create list where we store our answer
            for(int i = 0; i < n; ++i) {
                int num = int.Parse(a[i]); // Convert string into number
                if(Prime(num) == true) { 
                    Answer.Add(num); // If this number is prime add it to our answer
                }
            }
            Console.WriteLine(Answer.Count); // Print count of prime numbers
            foreach(int i in Answer) {
                Console.Write(i + " "); // Print the numbers
            }
        }
    }
}
