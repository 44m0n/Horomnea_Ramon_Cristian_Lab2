using Horomnea_Ramon_Cristian_Lab2.Data;
using Horomnea_Ramon_Cristian_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Horomnea_Ramon_Cristian_Lab2.Pages.Books;

public class DeleteModel : PageModel
{
    private readonly Horomnea_Ramon_Cristian_Lab2Context _context;

    public DeleteModel(Horomnea_Ramon_Cristian_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty] public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Book == null) return NotFound();

        Book? book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);

        if (book == null)
            return NotFound();
        Book = book;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.Book == null) return NotFound();
        Book? book = await _context.Book.FindAsync(id);

        if (book != null)
        {
            Book = book;
            _context.Book.Remove(Book);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}