using GerenciadorLivro.Core.Entities;

namespace GerenciaLivro.Application.Models
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string author, string isbn, DateTime yearOfPublication)
        {
            Id = id;
            Title = title;
            Author = author;
            Isbn = isbn;
            YearOfPublication = yearOfPublication;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Isbn { get; private set; }
        public DateTime YearOfPublication { get; private set; }

        public static BookViewModel FromEntity(Book entity)
            => new(entity.Id, entity.Title, entity.Author, entity.Isbn, entity.YearOfPublication);
    }
}
