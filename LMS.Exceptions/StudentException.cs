using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Exceptions
{
    public class StudentException:ApplicationException
    {
        public StudentException()
        {

        }
        public StudentException(string message):base(message)
        {

        }
    }
}
