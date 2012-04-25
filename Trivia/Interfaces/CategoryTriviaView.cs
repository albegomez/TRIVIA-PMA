namespace Trivia
{
    using System.Collections.Generic;

    using Trivia.db;

    public interface CategoryTriviaView
    {
        Category GetCategoryById(int id);

        List<Category> SelectAllCategories();
    }
}