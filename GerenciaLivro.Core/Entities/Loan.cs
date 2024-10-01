namespace GerenciadorLivro.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int idUser, int idBook, DateTime loanDate)
        {
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = DateTime.Now;
        }

        public int IdUser { get; set; }
        public User User { get; set; }
        public int IdBook { get; set; }
        public Book Book { get; set; }
        public DateTime LoanDate { get; set; }
        
        public void Update(int idUser, int idBook)
        {
            IdUser = idUser;
            IdBook = idBook;
        }
    }
}
