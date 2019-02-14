using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2 {
    class Student {
        private string name, id;
        private int year;
        public Student(string _name, string _id) {
            name = _name;
            id = _id;
            year = 2018;
        }
        public string GetName() {
            return name;
        }
        public string GetId() {
            return id;
        }
        public int GetYear() {
            return year;
        }
        public void Increment() {
            year++;
        }
    }
    class Program {
        static void Main(string[] args) {
            Student F = new Student("Dio", "18ZX1234567");
            Console.WriteLine(F.GetName() + " " + F.GetId());
            F.Increment();
            Console.WriteLine(F.GetYear());
        }
    }
}
