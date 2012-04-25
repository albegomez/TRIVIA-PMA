using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class GameRandom
    {
        public virtual int GetRandomNumber(int maxNumberSize)
        {
            Random random;
            random = new Random();
            return random.Next(maxNumberSize);
        }
    }
}
