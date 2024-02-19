using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_final.Data;

namespace Proiect_final.Models
{
    public class FilmCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Proiect_finalContext context,
        Film film)
        {
            var allCategories = context.Category;
            var filmCategories = new HashSet<int>(
            film.FilmCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Nume = cat.CategoryNume,
                    Assigned = filmCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateFilmCategories(Proiect_finalContext context,
        string[] selectedCategories, Film filmToUpdate)
        {
            if (selectedCategories == null)
            {
                filmToUpdate.FilmCategories = new List<FilmCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var filmCategories = new HashSet<int>
            (filmToUpdate.FilmCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!filmCategories.Contains(cat.ID))
                    {
                        filmToUpdate.FilmCategories.Add(
                        new FilmCategory
                        {
                            FilmID = filmToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (filmCategories.Contains(cat.ID))
                    {
                        FilmCategory courseToRemove
                        = filmToUpdate
                        .FilmCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
