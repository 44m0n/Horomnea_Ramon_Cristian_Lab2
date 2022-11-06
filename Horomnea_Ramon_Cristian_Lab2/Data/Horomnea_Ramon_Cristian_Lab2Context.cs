using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Horomnea_Ramon_Cristian_Lab2.Models;

namespace Horomnea_Ramon_Cristian_Lab2.Data
{
    public class Horomnea_Ramon_Cristian_Lab2Context : DbContext
    {
        public Horomnea_Ramon_Cristian_Lab2Context (DbContextOptions<Horomnea_Ramon_Cristian_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Horomnea_Ramon_Cristian_Lab2.Models.Book> Book { get; set; } = default!;
    }
}
