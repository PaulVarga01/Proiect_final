namespace Proiect_final.Models
{
    public class FilmCategory
    {
        public int ID { get; set; }
        public int FilmID { get; set; }
        public Film Film { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
