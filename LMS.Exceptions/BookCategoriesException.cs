using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Exceptions
{
   public  class BookCategoriesException:ApplicationException
    {
        public BookCategoriesException()
        {

        }
        public BookCategoriesException(string message):base(message)
        {

        }
    }
}
