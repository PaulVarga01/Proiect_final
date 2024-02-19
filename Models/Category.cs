namespace Proiect_final.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryNume { get; set; }
        public ICollection<FilmCategory>? FilmCategories { get; set; }
    }
}
