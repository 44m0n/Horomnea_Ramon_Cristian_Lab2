using Horomnea_Ramon_Cristian_Lab2.Data;
using Horomnea_Ramon_Cristian_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Horomnea_Ramon_Cristian_Lab2.Pages.Books;

public class CreateModel : BookCategoriesPageModel
{
    private readonly Horomnea_Ramon_Cristian_Lab2Context _context;

    public CreateModel(Horomnea_Ramon_Cristian_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty] public Book Book { get; set; } = default!;

    public IActionResult OnGet()
    {
        ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
        Book book = new()
        {
            BookCategories = new List<BookCategory>()
        };

        PopulateAssignedCategoryData(_context, book);
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
    {
        //Commented the line below because model state is always invalid
        //We need to modify the code to work with Categories
        //An alternative is to make Categories nullable
        //if (!ModelState.IsValid || _context.Book == null || Book == null) return Page();

        Book newBook = new();
        if (selectedCategories != null)
        {
            newBook.BookCategories = new List<BookCategory>();
            foreach (string cat in selectedCategories)
            {
                BookCategory catToAdd = new()
                {
                    CategoryID = int.Parse(cat)
                };
                newBook.BookCategories.Add(catToAdd);
            }
        }

        newBook.Title = Book.Title;
        newBook.Price = Book.Price;
        newBook.PublisherID = Book.PublisherID;
        newBook.PublishingDate = Book.PublishingDate;
        newBook.Author = Book.Author;


        //removed the tryupdate check because it is always false
        //if (await TryUpdateModelAsync<Book>(
        //we didn't mapped all the properties from Book to newBook
        _context.Book.Add(newBook);
        await _context.SaveChangesAsync();
        PopulateAssignedCategoryData(_context, newBook);
        return RedirectToPage("./Index");
    }
}