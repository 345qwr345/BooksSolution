using System;
using System.Collections.Generic;

namespace BooksDAL.Models
{
    public partial class Books
    {

        public byte BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
    }
}
