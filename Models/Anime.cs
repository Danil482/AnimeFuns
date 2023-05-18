namespace AnimeFuns.Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? JapanTitle { get; set; }
        public string? Description { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }
        public string Date { get; set; }
        public int CommentCount { get; set; }
        public int ViewsCount { get; set; }
        public string Studio { get; set; }
        public string Status { get; set; }
        public int Diration { get; set; }
        public string ImagePath { get; set; }
    }
}
