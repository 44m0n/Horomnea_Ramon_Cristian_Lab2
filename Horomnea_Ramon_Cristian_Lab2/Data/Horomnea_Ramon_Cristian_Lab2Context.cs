using Horomnea_Ramon_Cristian_Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Horomnea_Ramon_Cristian_Lab2.Data;

public class Horomnea_Ramon_Cristian_Lab2Context : DbContext
{
    public Horomnea_Ramon_Cristian_Lab2Context(DbContextOptions<Horomnea_Ramon_Cristian_Lab2Context> options)
        : base(options)
    {
    }

    public DbSet<Book> Book { get; set; } = default!;

    public DbSet<Horomnea_Ramon_Cristian_Lab2.Models.Publisher>? Publisher { get; set; }

    public DbSet<Horomnea_Ramon_Cristian_Lab2.Models.Category>? Category { get; set; }
}