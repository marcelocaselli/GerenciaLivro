using GerenciadorLivro.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Infrastructure.Persistence
{
    public class GerenciadorLivroDbContext : DbContext
    {
        public GerenciadorLivroDbContext(DbContextOptions<GerenciadorLivroDbContext> options)
            : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>(x =>
                {
                    x.HasKey(x => x.Id);
                });
            builder
                .Entity<Book>(x =>
                {
                    x.HasKey(x => x.Id);
                });
            builder
                .Entity<Loan>(x =>
                {
                    x.HasKey(x => x.Id);

                    x.HasOne(x => x.User)
                        .WithMany(x => x.Loans)
                        .HasForeignKey(x => x.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(x => x.Book)
                        .WithMany(x => x.Loans)
                        .HasForeignKey(x => x.IdBook)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(builder);
        }
    }
}
