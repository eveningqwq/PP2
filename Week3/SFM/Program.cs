using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFM {
    class Layer {
        public DirectoryInfo dirInfo;
        public string path;
        public int index;
        public List<FileSystemInfo> items;

        public Layer(string path, int index) {
            this.path = path;
            this.index = index;
            this.dirInfo = new DirectoryInfo(path);

            items = new List<FileSystemInfo>;
            items.AddRange(dirInfo.GetDirectories());
            items.AddRange(dirInfo.GetFiles());
        }

        public void Process(int v) {
            this.index += v;
            if (this.index < 0) {
                this.index = items.Count - 1;
            }
            if (this.index >= items.Count) {
                this.index = 0;
            }
        }

        public string GetSelectedItemInfo() {
            return this.items[index].FullName;
        }
    }
    public class Far {
        public enum Mode {
            Explorer,
            FileReader
        }

        Stack<Layer> layerHistory = new Stack<Layer>;
        Layer activeLayer;
        Mode mode = Mode.Explorer;

        public Far (string path) {
            activeLayer = new Layer(path, 0);
        }

        public void Draw() {
            switch (mode) {
                case Mode.Explorer:
                    DrawExplorer();
                    break;
                case Mode.FileReader:
                    DrawFileReader();
                    break;
                default:
                    break;
            }
        }
        
        private void DrawStatusBar() {
            Console.SetCursorPosition(4, 38);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(mode);
        }

        private void DrawFileReader() {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            FileStream fs = null;
            StreamReader sr = null;
            try {
                fs = new FileStream(activeLayer.GetSelectedItemInfo(), FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                Console.WriteLine(sr.ReadToEnd());

            } catch (Exception e) {
                Console.WriteLine("Cannot open file!");

            } finally {
                if (sr != null) {
                    sr.Close();
                }

                if (fs != null) {
                    fs.Close();
                }
            }
        }
        private void DrawExplorer()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            for (int i = 0; i < activeLayer.items.Count; ++i)
            {
                if (i == activeLayer.index)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }

                if (activeLayer.items[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.WriteLine(activeLayer.items[i].Name);
            }
        }

        public void Process(ConsoleKeyInfo pressedKey)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    activeLayer.Process(-1);
                    break;
                case ConsoleKey.DownArrow:
                    activeLayer.Process(1);
                    break;
                case ConsoleKey.Enter:
                    try
                    {
                        if (activeLayer.items[activeLayer.index].GetType() == typeof(DirectoryInfo))
                        {
                            mode = Mode.Explorer;
                            layerHistory.Push(activeLayer);
                            activeLayer = new Layer(activeLayer.GetSelectedItemInfo(), 0);
                        }else if (activeLayer.items[activeLayer.index].GetType() == typeof(FileInfo))
                        {
                            mode = Mode.FileReader;

                          
                        }
                    }
                    catch (Exception e) 
                    {
                        activeLayer = layerHistory.Pop();
                    }
                    break;
                case ConsoleKey.Backspace:
                    if (mode == Mode.Explorer)
                    {
                        activeLayer = layerHistory.Pop();
                    }
                    else if (mode == Mode.FileReader)
                    {
                        mode = Mode.Explorer;
                    }

                    break;
                default:
                    break;
            }

        }
    }
    }
}
