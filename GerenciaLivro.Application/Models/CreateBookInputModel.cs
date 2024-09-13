using GerenciadorLivro.Core.Entities;

namespace GerenciadorLivro.Application.Models
{
    public class CreateBookInputModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime YearOfPublication { get; set; }

        public Book ToEntity()
            => new(Title, Author, Isbn, YearOfPublication);
    }
}