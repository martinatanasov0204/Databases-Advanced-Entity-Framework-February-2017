namespace _06_albums
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public bool Private { get; set; }
        public Photographers Photographer { get; set; }
        public Picture Picture { get; set; }
    }
}
