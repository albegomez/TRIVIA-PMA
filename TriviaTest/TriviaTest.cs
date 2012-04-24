using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UglyTrivia;

namespace TriviaTest
{
    using Trivia;

    [TestClass]
    public class TriviaTest
    {

        // private GameRandom random;

        private OutputMessages messages;

        private Game game;

        private GameRunner gameRunner;
        [TestInitialize]
        public void init()
        {
            //   random = new GameRandom();
            messages = new ConsoleMessage();
            game = new Game(messages);
            //gameRunner = new GameRunner(random);
        }


        [TestMethod]
        public void MessagesTest()
        {
            Boolean retorno = game.add("J1");
            Assert.AreEqual(true, retorno);
            Assert.AreEqual("J1 was added", game.Messages.MessageQueue[0]);
            Assert.AreEqual("They are player number 1", game.Messages.MessageQueue[1]);
        }


        //[TestMethod]
        //public void MeaddNewPlayerTest()
        //{
        //    //GameRandom random = new GameRandom();
        //    //GameRunner gameRunner = new GameRunner(random);
        //    Boolean retorno = game.add("J1");

        //    //  gameRunner.Main(game); 
        //    Assert.AreEqual(true, retorno);
        //    Assert.AreEqual(1, game.howManyPlayers());
        //    Assert.AreEqual("J1", game.players[0]);
        //    Assert.AreEqual("J1 was added", game.Messages.MessageQueue[0]);
        //    Assert.AreEqual("They are player number 1", game.Messages.MessageQueue[1]);

        //}
        //[TestMethod]
        //public void CorrectTestWinTest()
        //{
        //    var mock = new Mock<Trivia.GameRandom>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        mock.Setup(rnd => rnd.GetRandomValue(i)).Returns(1);gfdsg
        //    }
        //    random = mock.Object;
        //    gameRunner = new GameRunner(random);

        //    game.add("Primero");
        //    game.add("Segundo");
        //    game.add("Tercero");
        //    gameRunner.Main(game);
        //    Assert.AreEqual("Primero now has 6 Gold Coins.", game.Messages.MessageQueue[game.Messages.MessageQueue.Count - 1]);

        //}

    }
}
