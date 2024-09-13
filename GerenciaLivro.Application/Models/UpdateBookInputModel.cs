namespace GerenciadorLivro.Application.Models
{
    public class UpdateBookInputModel
    {
        public int IdBook { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime YearOfPublication { get; set; }
    }
} 
