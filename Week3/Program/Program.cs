using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFM {
    class Program {
        static void Main(string[] args) {
            bool quit = false;
            Far current = new Far(@"C:\");
            while (!quit) {
                current.Draw();
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key) {
                    case ConsoleKey.Escape:
                        quit = true;
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.Backspace:
                    case ConsoleKey.Enter:
                    case ConsoleKey.Insert:
                    case ConsoleKey.Delete:
                        current.Process(pressedKey);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
