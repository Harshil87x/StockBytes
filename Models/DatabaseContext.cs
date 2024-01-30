using Microsoft.EntityFrameworkCore;

namespace StockBytes.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<memberRegModel> memberRegModel { get; set; }
        public virtual DbSet<memberLoginModel> memberLoginModel { get; set; }

    }
}
