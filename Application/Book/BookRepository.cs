using Application.Common;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Book

{
    public class BookRepository : GenericRepository<Domain.Book.Book>, Application.Book.IBookRepository
    {
        public DataContext _Context { get; }

        public BookRepository(DataContext context) : base(context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Domain.Book.Book>> GetByTitle(string Name)
        {
            return await _context.Set<Domain.Book.Book>().Where((a => a.Title == Name))
                .Include(b => b.TheAuthorList)
                .ToListAsync();
        }



    }
}
