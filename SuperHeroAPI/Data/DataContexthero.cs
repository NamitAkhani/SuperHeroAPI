using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Data
{
    public class DataContexthero : DbContext
    {
        public DataContexthero(DbContextOptions<DataContexthero> options) : base(options)
        {
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<User> users { get; set; }

        public DbSet<charactor> charactors { get; set; }
    }
}