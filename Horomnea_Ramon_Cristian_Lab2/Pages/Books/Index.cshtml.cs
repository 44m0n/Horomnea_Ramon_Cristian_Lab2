using Horomnea_Ramon_Cristian_Lab2.Data;
using Horomnea_Ramon_Cristian_Lab2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Horomnea_Ramon_Cristian_Lab2.Pages.Books;

public class IndexModel : PageModel
{
    private readonly Horomnea_Ramon_Cristian_Lab2Context _context;

    public IndexModel(Horomnea_Ramon_Cristian_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Book != null) Book = await _context.Book.Include(b => b.Publisher).ToListAsync();
    }
}