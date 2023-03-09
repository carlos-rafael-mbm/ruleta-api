using Microsoft.EntityFrameworkCore;
using ruleta_api.Models;

namespace ruleta_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; }
    }
}
