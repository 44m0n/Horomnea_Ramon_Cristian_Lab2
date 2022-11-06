using Horomnea_Ramon_Cristian_Lab2.Data;
using Horomnea_Ramon_Cristian_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Horomnea_Ramon_Cristian_Lab2.Pages.Books;

public class EditModel : PageModel
{
    private readonly Horomnea_Ramon_Cristian_Lab2Context _context;

    public EditModel(Horomnea_Ramon_Cristian_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty] public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Book == null) return NotFound();

        Book? book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
        if (book == null) return NotFound();
        Book = book;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Book).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BookExists(Book.ID))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool BookExists(int id)
    {
        return (_context.Book?.Any(e => e.ID == id)).GetValueOrDefault();
    }
}