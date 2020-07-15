using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Entities;
using LMS.DAL;
using LMS.Exceptions;

namespace LMS.BLL
{
    public class LibraryBLL
    {
        private static LibraryDBDAL obj=new LibraryDBDAL();

        
        public bool AppUserLoginBLL(AppUsers appUsers)
        {
            bool status = false;
            try
            {
                status = obj.AppUserLogin(appUsers);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;
        }


        public bool AddStudentBLL(Students students)
        {
            bool status = false;

            try
            {
                if(ValidateStudent(students))
                {
                    status = obj.AddStudentDAL(students);
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;
        }

        public bool ValidateStudent(Students student)
        {
            bool status = true;

            StringBuilder stringBuilder = new StringBuilder();

            if(student.Std<1 || student.Std>10)
            {
                status = false;
                stringBuilder.Append("\n Std must be in between 1 to 10");
            }
            

            if(student.RollNo > 50 || student.RollNo <1)
            {
                status = false;
                stringBuilder.Append("\n Rollno must be in between 1 to 50");
            }
            
            if(!(student.Div=="A") && !(student.Div=="B") && !(student.Div=="C"))
            {
                status = false;
                stringBuilder.Append("\n Div must be either A or B or C");
            }

            if(status==false)
            {
                throw new StudentException(stringBuilder.ToString());
            }
                return status;

        }

        public bool UpdateStudentBLL(Students student)
        {
            bool status = false;

            try
            {
                status = obj.UpdateStudentDAL(student);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return status;
        }

        public bool AddBookBLL(Books book)
        {
            bool status = false;

            try
            {
                if(ValidateBook(book))
                {
                    status = obj.AddBookDAL(book);
                }
                else
                {
                    Console.WriteLine("Copies available should be greater than 3");
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;
        }

        public bool ValidateBook(Books books)
        {
            bool status = false;

            if(books.CopiesAvailable>3)
            {
                
                status = true;
            }
            return status;

        }

        public bool AddBookCategoryBLL(BookCategories bookCat)
        {
            bool status = false;
            try
            {
                status = obj.AddCategoryDAL(bookCat);
            }
            catch (BooksException ex)
            {

                throw ex;
            }

            return status;

        }
       

        public List<Students> GetStudentsByStdDivBLL(string Div ,int Std)
        {
            List<Students> list = new List<Students>();

            list = obj.GetStudentsByStdDiv(Div, Std);

            return list;
            
        }

        public List<Books> GetBooksByCategoryIDBLL(int category)
        {
            List<Books> list = new List<Books>();

            list = obj.GetBookByCategoryId(category);

            return list;
        }

        public bool IssueBookBLL(LibraryTransaction library)
        {
            bool status = false;

            try
            {
                status = obj.IssueBook(library);
            }
            catch (BooksException ex)
            {

                throw ex;
            }

            return status;
        }
    }
    
}
