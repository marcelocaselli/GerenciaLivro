﻿using GerenciadorLivro.Core.Entities;

namespace GerenciaLivro.Application.Models
{
    public class UpdateLoanInputModel
    {
        public int IdLoan { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}

