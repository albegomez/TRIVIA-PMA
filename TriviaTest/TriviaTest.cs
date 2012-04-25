    using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UglyTrivia;

namespace TriviaTest
{
    using Trivia;
    using Moq;

    using Trivia.db;

    [TestClass]
    public class TriviaTest
    {

       private GameRandom random;

        private OutputMessages messages;

        private Game game;

        private GameRunner gameRunner;
        [TestInitialize]
        public void init()
        {
            random = new GameRandom();
            messages = new ConsoleMessage();
            game = new Game(messages);
            gameRunner = new GameRunner(random);
        }


        [TestMethod]
        public void MessagesTest()
        {
            Boolean retorno = game.add("J1");
            Assert.AreEqual(true, retorno);
            Assert.AreEqual("J1 was added", game.Messages.MessageQueue[0]);
            Assert.AreEqual("They are player number 1", game.Messages.MessageQueue[1]);
        }

        [TestMethod]
        public void RandomTest()
        {
           GameRandom gameRandom = new GameRandom();
            int numeroAleatorio = gameRandom.GetRandomNumber(1);
            Assert.AreEqual(0, numeroAleatorio);
        }

        [TestMethod]
        public void AddNewPlayerTest()
        {
            Boolean retorno = game.add("J1");

            gameRunner.Run(game);
 
            Assert.AreEqual(true, retorno);
            Assert.AreEqual(1, game.howManyPlayers());
            Assert.AreEqual("J1", game.players[0]);
            Assert.AreEqual("J1 was added", game.Messages.MessageQueue[0]);
            Assert.AreEqual("They are player number 1", game.Messages.MessageQueue[1]);

        }
        [TestMethod]
        public void CorrectTestWinTest()
        {
         
            var mock = new Mock<Trivia.GameRandom>();
            for (int i = 0; i < 10; i++)
            {
                mock.Setup(rnd => rnd.GetRandomNumber(i)).Returns(1);
            }
            random = mock.Object;
            gameRunner = new GameRunner(random);

            game.add("Primero");
            game.add("Segundo");
            game.add("Tercero");
            gameRunner.Run(game);
            Assert.AreEqual("Primero now has 6 Gold Coins.", game.Messages.MessageQueue[game.Messages.MessageQueue.Count - 1]);

        }

      
        public void InicializarPreguntas()
        {
            QuestionsTriviaView preguntasTriviaView = new QuestionsTriviaView();
            List<Category> categories = new CategoryTriviaView().SelectAllCategories();
            QuestionsTriviaView questionsTriviaView = new QuestionsTriviaView();
            Question question = null;
            GameRandom gameRandom = new GameRandom();
            questionsTriviaView.DeleteAllQuestions();
            foreach (Category category in categories)
            {
                for (int i = 1; i < 51; i++)
                {
                    question = new Question();
                    question.NameQuestion = "Question" + category.NameCategory + i;
                    question.Answer = gameRandom.GetRandomNumber(3);
                    question.IdCategory = category.IdCategory;
                    questionsTriviaView.InsertarPreguntas(question);
                }

            }     

        }

        public void BorrarTodasLasPreguntas()
        {
             QuestionsTriviaView questionsTriviaView = new QuestionsTriviaView();
             questionsTriviaView.DeleteAllQuestions();
        }

        [TestMethod]
        public void InsertarPreguntas()
        {

            this.BorrarTodasLasPreguntas();
            QuestionsTriviaView questionsTriviaView = new QuestionsTriviaView();
            Question question = new Question();
            question.IdCategory = 1;
            question.NameQuestion = "Test";
            question.Answer = 1;
            questionsTriviaView.InsertarPreguntas(question);
            List<Question> questions = questionsTriviaView.GetAllQuestions();
            Assert.AreEqual(1,questions.Count );
            Assert.AreEqual(1, questions[0].IdCategory);
            Assert.AreEqual("Test", questions[0].NameQuestion);
            Assert.AreEqual(1, questions[0].Answer);
            this.BorrarTodasLasPreguntas();
        }

        [TestMethod]
        public void ObtenerTodasLasCategorias()
        {
           CategoryTriviaView categoryTriviaView = new CategoryTriviaView();
           List<Category> categories =  categoryTriviaView.SelectAllCategories();
           Assert.IsNotNull(categories);

        }

        [TestMethod]
        public void ObtenerCategoriasById()
        {
            CategoryTriviaView categoryTriviaView = new CategoryTriviaView();
            Category  categoria = categoryTriviaView.GetCategoryById(1);
            Assert.IsNotNull(categoria);
            Assert.AreEqual("Pop",categoria.NameCategory);

        }


    }
}
