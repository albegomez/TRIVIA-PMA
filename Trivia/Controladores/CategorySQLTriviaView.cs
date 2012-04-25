using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    using Trivia.db;

    public class CategorySQLTriviaView : CategoryTriviaView
    {
        public Category GetCategoryById(int id)
        {
            using (PreguntasTriviaDBDataContext dc = new PreguntasTriviaDBDataContext())
            {
                var category = from c in dc.Categories where c.IdCategory == id select c;
                return category.SingleOrDefault();
            }
        }

        public List<Category> SelectAllCategories()
        {
            using (PreguntasTriviaDBDataContext dc = new PreguntasTriviaDBDataContext())
            {
                return dc.Categories.ToList();
            }
        }

    }
}
