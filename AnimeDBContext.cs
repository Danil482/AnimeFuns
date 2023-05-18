using AnimeFuns.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityUser = Microsoft.AspNetCore.Identity.IdentityUser;

namespace AnimeFuns
{
    public class AnimeDBContext: IdentityDbContext<IdentityUser>
    {
        public AnimeDBContext() { }
        
        public AnimeDBContext(DbContextOptions<AnimeDBContext> options) : base(options) { }
        public virtual DbSet<Anime> Animes { get; set; }
        public virtual DbSet<Follows> Follows { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=Anime; UserId=postgres; Password=588228");
    }
}
