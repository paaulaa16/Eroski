using Microsoft.EntityFrameworkCore;

namespace ApiEroski.Models
{
    public class EroskiContext : DbContext
    {
        public EroskiContext(DbContextOptions<EroskiContext> options)
            : base(options)
        {
        }

        public DbSet<Eroski> Eroski { get; set; }
    }
}