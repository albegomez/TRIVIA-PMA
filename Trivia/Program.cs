using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class Program
    {
        static void Main(string[] args)
        {
            GameRandom gameRandom = new GameRandom();
            GameRunner gameRunner = new GameRunner(gameRandom);
            gameRunner.Run();
            Console.ReadLine();
        }
    }
}
