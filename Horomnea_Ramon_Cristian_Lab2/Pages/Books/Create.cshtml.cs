using Horomnea_Ramon_Cristian_Lab2.Data;
using Horomnea_Ramon_Cristian_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Horomnea_Ramon_Cristian_Lab2.Pages.Books;

public class CreateModel : PageModel
{
    private readonly Horomnea_Ramon_Cristian_Lab2Context _context;

    public CreateModel(Horomnea_Ramon_Cristian_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty] public Book Book { get; set; } = default!;

    public IActionResult OnGet() => Page();


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || _context.Book == null || Book == null) return Page();

        _context.Book.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}