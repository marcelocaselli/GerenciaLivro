using GerenciadorLivro.Core.Entities;

namespace GerenciadorLivro.Application.Models
{
    public class LoanViewModel
    {
        public LoanViewModel(int idUser, int idBook, DateTime returnDate)
        {
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = DateTime.Now;
            ReturnDate = returnDate;
        }

        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public static LoanViewModel FromEntity(Loan entity)
            => new(entity.IdBook, entity.IdUser, entity.ReturnDate);
    }
}
