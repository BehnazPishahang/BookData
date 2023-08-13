using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Book
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public virtual List<Application.Domain.Author.Author>? TheAuthorList { get; set; }
    }
}
