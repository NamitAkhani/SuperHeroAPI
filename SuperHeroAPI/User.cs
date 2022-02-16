namespace SuperHeroAPI
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        //
        //public List<SuperHero> superHeroes { get; set; }
    }
}