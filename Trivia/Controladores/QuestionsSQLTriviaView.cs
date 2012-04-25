using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    using Trivia.db;

    public class QuestionsSQLTriviaView : QuestionsTriviaView
    {
        public void InsertarPreguntas(Question pregunta)
        {
            using (PreguntasTriviaDBDataContext dc = new PreguntasTriviaDBDataContext())
            {
                dc.Questions.InsertOnSubmit(pregunta);
                dc.SubmitChanges();
            }

        }
        public List<Question> GetAllQuestions()
        {
            using (PreguntasTriviaDBDataContext dc = new PreguntasTriviaDBDataContext())
            {
                return dc.Questions.ToList();
                
            }
        }

        public void DeleteAllQuestions()
        {
            using (PreguntasTriviaDBDataContext dc = new PreguntasTriviaDBDataContext())
            {
                dc.Questions.DeleteAllOnSubmit(dc.Questions.ToList());
                dc.SubmitChanges();
            }
        }

        public List<Question> GetQuestionsByCategoryId(int id)
        {
            using (PreguntasTriviaDBDataContext dc = new PreguntasTriviaDBDataContext())
            {
                var category = from c in dc.Questions where c.IdCategory == id select c;
                return category.ToList();
            }
        }

       

    }
}
