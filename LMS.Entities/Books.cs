using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities
{
    public class Books
    {
        public int BookCode { get; set; }
        public string BookName { get; set; }
        public int CopiesAvailable
        {
            get;
            set;
        }
        public string Author { get; set; }
        public int CategoryId { get; set; }
    }
}
