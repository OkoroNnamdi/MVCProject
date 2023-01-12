using BullkBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BullkBookWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> Options) : base(Options)
        {

        }
        public DbSet<Category > Categories { get; set; }
    }
}
