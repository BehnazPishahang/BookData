using Microsoft.EntityFrameworkCore;
using ServiceModel;

namespace Persistance
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }
       

        // DbSet properties representing your database tables
        public DbSet<Book> Books { get; set; }
        public DbSet<author> Authors { get; set; }

    }
}