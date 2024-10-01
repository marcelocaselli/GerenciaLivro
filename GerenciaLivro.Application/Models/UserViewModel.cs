﻿using GerenciadorLivro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaLivro.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; set; }

        public static UserViewModel FromEntity(User entity)
            => new(entity.Name, entity.Email, entity.BirthDate);
    }
}
