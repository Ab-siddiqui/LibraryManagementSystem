using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Exceptions
{
    public class AppUserException: ApplicationException
    {
        public AppUserException()
        {

        }
        public AppUserException(string message):base(message)
        {
            
        }

    }
    
}
