using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_final.Models
{
    public class Film
    {
        public int ID { get; set; }
        [Display(Name = "Titlul Filmului")]
        public string Titlu { get; set; }
        public string Regizor { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int? DistribuitorID { get; set; }
        public Distribuitor? Distribuitor { get; set; }
        public ICollection<FilmCategory>? FilmCategories { get; set; }
    }
}
