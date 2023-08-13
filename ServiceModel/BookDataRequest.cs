using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel
{
    public class BookDataRequest
    {
        [Required(ErrorMessage = "Request is null.")]
        public BookDataContract theBookDataContract { get; set; }
    }
}
