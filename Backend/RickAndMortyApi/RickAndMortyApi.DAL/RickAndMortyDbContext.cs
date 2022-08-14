using Microsoft.EntityFrameworkCore;
using RickAndMortyApi.DAL.Models;

namespace RickAndMortyApi.DAL
{
    public class RickAndMortyDbContext : DbContext
    {
        public RickAndMortyDbContext(DbContextOptions<RickAndMortyDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Character> Characters { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
