using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UglyTrivia;

namespace Trivia
{
    public class GameRunner
    {
        private GameRandom gameRandom;
        private static bool notAWinner;

        public Game Game { get; set; }
        public GameRunner(GameRandom gameRandom)
        {
            this.gameRandom = gameRandom;
        }

        public void Run(Game game)
        {
            OutputMessages messages = new ConsoleMessage();
            this.Game = game;
        
            do
            {

                game.roll(gameRandom.GetRandomNumber(5)  +1);

                if (gameRandom.GetRandomNumber(9) == 7)
                {
                    notAWinner = game.wrongAnswer();
                }
                else
                {
                    notAWinner = game.wasCorrectlyAnswered();
                }



            } while (notAWinner);
            game.Messages.PrintMessages();

        }

        


    }

}

