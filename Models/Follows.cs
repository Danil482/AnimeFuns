using Microsoft.AspNetCore.Identity;

namespace AnimeFuns.Models
{
    public class Follows
    {
        public int Id { get; set; }
        public IdentityUser? User { get; set; }
        public int AnimeId { get; set; }
        public Anime? Anime { get; set; }
    }
}
