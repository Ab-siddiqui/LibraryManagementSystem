using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Exceptions
{
    public class BooksException:ApplicationException
    {
        public BooksException()
        {

        }
        public BooksException(string message):base(message)
        {

        }
    }
}
