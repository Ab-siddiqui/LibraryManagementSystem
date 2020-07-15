using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities
{
    public class LibraryTransaction
    {
        public int LibTransactionNo { get; set; }

        public DateTime BookIssueDate { get; set; }

        public DateTime ExpectedReturnDate { get; set; }

        public DateTime ActualReturnDate { get; set; }

        public int Std { get; set; }

        public string Div { get; set; }

        public int Rollno { get; set; }

        public int BookCode { get; set; }

        public double Fine { get; set; }
    }
}
