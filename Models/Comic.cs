namespace API_COMIC.Models
{
    public class Comic
    {
        public int id { get; set; }
        public string comic_name { get; set; }
        public string avatar { get; set; }
        public int id_genre { get; set; }
        public string author { get; set; }
        public string describe { get; set; }
        public int status { get; set; }
    }
}