using BookSttore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
namespace BookSttore.DataAccess;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base (options)
    {

    }
    public DbSet<BookEntity> Books { get; set; }


}

