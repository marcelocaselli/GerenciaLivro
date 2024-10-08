﻿namespace GerenciadorLivro.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, DateTime birthDate)
            : base()
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        public List<Loan> Loans { get; set; }

        public void Update(string name, string email, DateTime birthdate)
        {
            Name = name;
            Email = email;
            BirthDate = birthdate;
        }
    }
}
