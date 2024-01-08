using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;

namespace WebApplication1.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public virtual DbSet<Tbl_Demo> Tbl_Demo { get; set; }
        //Country
    }
}
