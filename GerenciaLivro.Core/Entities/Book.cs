namespace GerenciadorLivro.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string isbn, DateTime yearOfPublication)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            YearOfPublication = yearOfPublication;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Isbn { get; private set; }
        public DateTime YearOfPublication { get; private set; }

        public List<Loan> Loans { get; private set; }

        public void Update(string title, string author, string isbn, DateTime yearOfPublication)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            YearOfPublication = yearOfPublication;
        }
    }
}
