using GerenciadorLivro.Core.Entities;
using GerenciaLivro.Core.Repositories;
using GerenciaLivro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GerenciadorLivroDbContext _context;
        public UserRepository(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User?> GetDetailsById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
