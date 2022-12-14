using Horomnea_Ramon_Cristian_Lab2.Data;
using Horomnea_Ramon_Cristian_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Horomnea_Ramon_Cristian_Lab2.Pages.Books;

public class DetailsModel : PageModel
{
    private readonly Horomnea_Ramon_Cristian_Lab2Context _context;

    public DetailsModel(Horomnea_Ramon_Cristian_Lab2Context context)
    {
        _context = context;
    }

    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Book == null) return NotFound();

        Book? book = await _context.Book.Include(b => b.Publisher).FirstOrDefaultAsync(m => m.ID == id);
        if (book == null)
            return NotFound();
        Book = book;
        return Page();
    }
}