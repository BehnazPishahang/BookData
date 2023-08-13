using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<author> TheauthorList { get; set; }
    }
}
