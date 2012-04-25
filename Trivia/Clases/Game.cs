using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UglyTrivia
{
    using Trivia;
    using Trivia.db;

    public class Game
    {
      
        public List<string> players = new List<string>();

        int[] places = new int[6];
        int[] purses = new int[6];

        bool[] inPenaltyBox = new bool[6];

        List<Question> questions = new List<Question>();

        public Question currentQuestion = null;
        
        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;

        public OutputMessages Messages { get; set; }
    
        private CategoryTriviaView categoryTriviaView;

        private QuestionsTriviaView questionsTriviaView;


        public Game(OutputMessages messages,CategoryTriviaView categoriTriviaView,QuestionsTriviaView questionsTriviaView)
        {
            this.Messages = messages;
            this.categoryTriviaView = categoriTriviaView;
            this.questionsTriviaView = questionsTriviaView;
            InicializarPreguntas();
        }
        public void InicializarPreguntas()
        {

            List<Category> categories = categoryTriviaView.SelectAllCategories();
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
                    questions.Add(question);
                }


            }
            



        }

        public String createRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool isPlayable()
        {
            return (howManyPlayers() >= 2);
        }

        public bool add(String playerName)
        {


            players.Add(playerName);
            places[howManyPlayers()] = 0;
            purses[howManyPlayers()] = 0;
            inPenaltyBox[howManyPlayers()] = false;

            Messages.Add(playerName + " was added");
            Messages.Add("They are player number " + players.Count);
            return true;
        }

        public int howManyPlayers()
        {
            return players.Count;
        }

        private Category currentCategory;

        public void roll(int roll)
        {
            Messages.Add(players[currentPlayer] + " is the current player");
            Messages.Add("They have rolled a " + roll);

            if (inPenaltyBox[currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Messages.Add(players[currentPlayer] + " is getting out of the penalty box");
                    places[currentPlayer] = places[currentPlayer] + roll;
                    if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;


                    this.currentCategory = this.GetCurrentCategory(places[currentPlayer]);
                    Messages.Add(players[currentPlayer]
                            + "'s new location is "
                            + places[currentPlayer]);
                    Messages.Add("The category is " + this.currentCategory );
                    
                    askQuestion();
                }
                else
                {
                    Messages.Add(players[currentPlayer] + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {

                places[currentPlayer] = places[currentPlayer] + roll;
                if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                Messages.Add(players[currentPlayer]
                        + "'s new location is "
                        + places[currentPlayer]);
                 this.currentCategory = this.GetCurrentCategory(places[currentPlayer]);
                Messages.Add("The category is " + this.currentCategory);
                askQuestion();
            }

        }

        private void askQuestion()
        {
            int obtenterPregunta = 0;
            GameRandom rnd = new GameRandom();
            List<Question> selectQuestions = selectQuestions = questions.Where(q => q.IdCategory == this.currentCategory.IdCategory).ToList();
            obtenterPregunta = rnd.GetRandomNumber(selectQuestions.Count);
            currentQuestion = selectQuestions[obtenterPregunta];
            Messages.Add(currentQuestion.NameQuestion);
        }


        public Category GetCurrentCategory(int categoryId)
        {

            Category category = categoryTriviaView.GetCategoryById(categoryId);
            if (category == null)
                return categoryTriviaView.GetCategoryById(4);
            else 
                return category;

        }
    

        public bool wasCorrectlyAnswered()
        {
            if (inPenaltyBox[currentPlayer])
            {
                if (isGettingOutOfPenaltyBox)
                {
                    Messages.Add("Answer was correct!!!!");
                    purses[currentPlayer]++;
                    Messages.Add(players[currentPlayer]
                            + " now has "
                            + purses[currentPlayer]
                            + " Gold Coins.");

                    bool winner = didPlayerWin();
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;

                    return winner;
                }
                else
                {
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;
                    return true;
                }



            }
            else
            {

                Messages.Add("Answer was corrent!!!!");
                purses[currentPlayer]++;
                Messages.Add(players[currentPlayer]
                        + " now has "
                        + purses[currentPlayer]
                        + " Gold Coins.");

                bool winner = didPlayerWin();
                currentPlayer++;
                if (currentPlayer == players.Count) currentPlayer = 0;

                return winner;
            }
        }

        public bool wrongAnswer()
        {
            Messages.Add("Question was incorrectly answered");
            Messages.Add(players[currentPlayer] + " was sent to the penalty box");
            inPenaltyBox[currentPlayer] = true;

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;
        }


        private bool didPlayerWin()
        {
            return !(purses[currentPlayer] == 6);
        }
    }

}
