using Horomnea_Ramon_Cristian_Lab2.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Horomnea_Ramon_Cristian_Lab2.Models;

public class BookCategoriesPageModel : PageModel
{
    public List<AssignedCategoryData> AssignedCategoryDataList;

    public void PopulateAssignedCategoryData(Horomnea_Ramon_Cristian_Lab2Context context,
        Book book)
    {
        DbSet<Category>? allCategories = context.Category;
        HashSet<int> bookCategories = new(
            book.BookCategories.Select(c => c.CategoryID)); //
        AssignedCategoryDataList = new List<AssignedCategoryData>();
        foreach (Category cat in allCategories!)
            AssignedCategoryDataList.Add(new AssignedCategoryData
            {
                CategoryID = cat.ID,
                Name = cat.CategoryName,
                Assigned = bookCategories.Contains(cat.ID)
            });
    }

    public void UpdateBookCategories(Horomnea_Ramon_Cristian_Lab2Context context,
        string[] selectedCategories, Book bookToUpdate)
    {
        if (selectedCategories == null)
        {
            bookToUpdate.BookCategories = new List<BookCategory>();
            return;
        }

        HashSet<string> selectedCategoriesHS = new(selectedCategories);
        HashSet<int> bookCategories = new(bookToUpdate.BookCategories.Select(c => c.Category.ID));
        foreach (Category cat in context.Category)
            if (selectedCategoriesHS.Contains(cat.ID.ToString()))
            {
                if (!bookCategories.Contains(cat.ID))
                    bookToUpdate.BookCategories.Add(
                        new BookCategory
                        {
                            BookID = bookToUpdate.ID,
                            CategoryID = cat.ID
                        });
            }
            else
            {
                if (bookCategories.Contains(cat.ID)) continue;
                BookCategory courseToRemove
                    = bookToUpdate
                        .BookCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                context.Remove(courseToRemove);
            }
    }
}