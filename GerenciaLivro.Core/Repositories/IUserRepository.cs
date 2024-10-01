﻿using GerenciadorLivro.Core.Entities;

namespace GerenciaLivro.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetDetailsById(int id);
        Task<int> Add(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
