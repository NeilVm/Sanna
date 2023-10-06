using Microsoft.EntityFrameworkCore;
using registrosanna.Models;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace registrosanna.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Registro> Registros { get; set; }
    }
}
