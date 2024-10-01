using GerenciadorLivro.Core.Entities;

namespace GerenciaLivro.Application.Models
{
    public class LoanViewModel
    {
        public LoanViewModel(int idUser, int idBook)
        {
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = DateTime.Now;
            
        }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime LoanDate { get; set; }
        
        public static LoanViewModel FromEntity(Loan entity)
            => new(entity.IdBook, entity.IdUser);
    }
}
