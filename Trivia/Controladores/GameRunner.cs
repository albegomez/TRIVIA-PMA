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
                //Se modifica el acceso
                game.roll(gameRandom.GetRandomNumber(5) + 1);
                int numeroaleatorio = gameRandom.GetRandomNumber(3) ;
                if ( numeroaleatorio != game.currentQuestion.Answer)
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

