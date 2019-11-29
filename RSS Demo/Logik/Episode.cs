namespace RSS_Demo.Logik
{
    public class Episode
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Runtime { get; set; }
        public string EpisodeLink { get; set; }
        public string PubDate { get; set; }

        public Episode(string title, string description, string pubDate)
        {
            this.Title = title;
            this.Description = description;
            this.PubDate = pubDate;
        }

        public Episode()
        { }
    }
}