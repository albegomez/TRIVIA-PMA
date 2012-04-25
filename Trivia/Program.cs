using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyTrivia;

namespace Trivia
{
    using Trivia.db;

    class Program
    {
        static void Main(string[] args)
        {
            GameRandom gameRandom = new GameRandom();
            GameRunner gameRunner = new GameRunner(gameRandom);
            ConsoleMessage consoleMessage = new ConsoleMessage();
            CategoryTriviaView categoryTriviaView = new CategorySQLTriviaView();
            QuestionsTriviaView questionsTriviaView = new QuestionsSQLTriviaView();
            Game game = new Game(consoleMessage,categoryTriviaView,questionsTriviaView);
            game.add("Pat");
            game.add("Jhon");
            game.add("Sue");
            gameRunner.Run(game);
            Console.ReadLine();


                  
        }
    }
}
