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

        public GameRunner(GameRandom gameRandom)
        {
            this.gameRandom = gameRandom;
        }

        public void Run()
        {
            OutputMessages messages = new ConsoleMessage();
            Game aGame = new Game(messages);
            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");
            do
            {

                aGame.roll(gameRandom.GetRandomNumber(5)  +1);

                if (gameRandom.GetRandomNumber(9) == 7)
                {
                    notAWinner = aGame.wrongAnswer();
                }
                else
                {
                    notAWinner = aGame.wasCorrectlyAnswered();
                }



            } while (notAWinner);
            aGame.Messages.PrintMessages();

        }

        


    }

}

