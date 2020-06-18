using Game2048;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace _2048Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        Model model; 

        void Start()
        {
            model = new Model(3);
            model.Start();
            while (true)
            {
                Show(model);
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.LeftArrow:model.Left(); break;
                    case ConsoleKey.RightArrow: model.Right();break;
                    case ConsoleKey.UpArrow: model.Up(); break;
                    case ConsoleKey.DownArrow: model.Down(); break;
                    case ConsoleKey.Escape: return;
                }
            }
        }

        void Show(Model model)
        {
            for(int y = 0; y < model.size; y++)
                for(int x= 0; x < model.size; x++)
                {
                    Console.SetCursorPosition(x * 5 + 5, y * 2 + 2);
                    int number = model.GetMap(x, y);
                    Console.Write(number == 0 ? ". " : number.ToString());
                }
            if (model.isGameOver)
                Console.WriteLine("\nGame Over");
            else
                Console.WriteLine("\nStill play");
        }
    }
}
