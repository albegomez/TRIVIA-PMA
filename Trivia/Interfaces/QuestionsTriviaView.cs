namespace Trivia
{
    using System.Collections.Generic;

    using Trivia.db;

    public interface QuestionsTriviaView
    {
        void InsertarPreguntas(Question pregunta);

        List<Question> GetAllQuestions();

        void DeleteAllQuestions();

         List<Question> GetQuestionsByCategoryId(int id);
    }
}