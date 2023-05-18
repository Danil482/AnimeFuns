using Microsoft.AspNetCore.Identity;

namespace AnimeFuns.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public IdentityUser? User { get; set; }
        public int AnimeId { get; set; }
        public Anime? Anime { get; set; }
        public int Score { get; set; }
        public int rating { get; set; }
    }
}
