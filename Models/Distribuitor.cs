namespace Proiect_final.Models
{
    public class Distribuitor
    {
        public int ID { get; set; }
        public string NumeDistribuitor { get; set; }
        public ICollection<Film>? Films { get; set; } //navigation property

    }
}
