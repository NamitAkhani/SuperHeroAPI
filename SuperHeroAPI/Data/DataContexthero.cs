using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Data
{
    public class DataContexthero : DbContext
    {
        public DataContexthero(DbContextOptions<DataContexthero> options) : base(options)
        {
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}