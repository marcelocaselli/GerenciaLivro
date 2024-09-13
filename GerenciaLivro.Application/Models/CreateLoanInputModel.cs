using GerenciadorLivro.Core.Entities;

namespace GerenciadorLivro.Application.Models
{
    public class CreateLoanInputModel
    {
        public int IdBook { get; set; }
        public int IdUser { get; set; }
        public DateTime LoanDate { get; set; }
        
        public Loan ToEntity()
            => new(IdBook, IdUser, LoanDate);
    }
}
