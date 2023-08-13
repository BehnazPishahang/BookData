using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book
{
    public interface IBookRepository : IGenericRepository<Domain.Book.Book>
    {
        Task<IEnumerable<Domain.Book.Book>> GetByTitle(string CityName);

        
        
    }
}