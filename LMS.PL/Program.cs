using System;
using System.Collections.Generic;
using LMS.DAL;
using LMS.Entities;
using LMS.BLL;
using LMS.Exceptions;

namespace LMS.PL
{
    class Program
    {
        private static LibraryBLL caller=new LibraryBLL();
                

        static void PrintMenu()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("Employee Information System");
            Console.WriteLine("1.Add Student");
            Console.WriteLine("2. Add Book");
            Console.WriteLine("3. Get Student details by std and div");
            Console.WriteLine("4. GetBook By CategoryId");
            Console.WriteLine("5. Edit Student ");
            Console.WriteLine("6. Add Book Category");
            Console.WriteLine("7. Issue Book ");
            Console.WriteLine("8. Quit");
            
        }

        static void AddStudent()
        {
            try
            {
                Students stud = new Students();

                Console.WriteLine("Enter Roll no: ");
                stud.RollNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Name: ");
                stud.Name = Console.ReadLine();

                Console.WriteLine("Enter Std: ");
                stud.Std = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Division: ");
                stud.Div =Console.ReadLine();

                Console.WriteLine("Enter Address: ");
                stud.Address = Console.ReadLine();

                if(caller.AddStudentBLL(stud))
                {
                    Console.WriteLine("Student added Successfully");
                }
                else
                {
                    Console.WriteLine("Cannot add student , either Rollno or Std or Div is invalid");
                }


            }   
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        static void updateStudent()
        {
            try
            {
                Students student = new Students();

                Console.WriteLine("Enter RollNo: ");
                student.RollNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Std: ");
                student.Std = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Div: ");
                student.Div =Console.ReadLine();

                Console.WriteLine("Enter new Name: ");
                student.Name = Console.ReadLine();

                Console.WriteLine("Enter new Address: ");
                student.Address = Console.ReadLine();

                if(caller.UpdateStudentBLL(student))
                {
                    Console.WriteLine("Record Updated Successfully");
                }
                else
                {
                    Console.WriteLine("Cannot Update the Record");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static void AppUserLogin()
        {
            try
            {
                AppUsers appuser = new AppUsers();

                Console.WriteLine("Enter Your UserName: ");
                appuser.AppUserName = Console.ReadLine();

                Console.WriteLine("Enter Your password: ");
                appuser.password = Console.ReadLine();

                if(caller.AppUserLoginBLL(appuser))
                {
                    Console.WriteLine("Login Successful");
                }
                else
                {
                    Console.WriteLine("Login Failed");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
            
        }

        static void AddBookPL()
        {
            try
            {
                Books book = new Books();

                Console.WriteLine("Enter Book Code: ");
                book.BookCode = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Book Name: ");
                book.BookName = Console.ReadLine();

                Console.WriteLine("Enter CopiesAvailable: ");
                book.CopiesAvailable = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Book Author Name: ");
                book.Author = Console.ReadLine();

                Console.WriteLine("Enter CategoryId: ");
                book.CategoryId = Convert.ToInt32(Console.ReadLine());

                if(caller.AddBookBLL(book))
                {
                    Console.WriteLine("Book Added Successfully");
                }
                else
                {
                    Console.WriteLine("Cannot Add the book");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        static void AddCategory()
        {
            try
            {
                BookCategories bookCategories = new BookCategories();

                Console.WriteLine("Enter Book CategoryId: ");
                bookCategories.CategoryId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Book Category Name: ");
                bookCategories.CategoryName = Console.ReadLine();

                if(caller.AddBookCategoryBLL(bookCategories))
                {
                    Console.WriteLine("Book Category Added Successfully");
                }
                else
                {
                    Console.WriteLine("Cannot Add Category!");
                }
            }
            catch (BookCategoriesException ex)
            {

                throw ex;
            }
        }

        static void GetStudentByStdDivPL()
        {
            try
            {
                Students stud = new Students();

                Console.WriteLine("Enter Division: ");
                stud.Div = Console.ReadLine();

                Console.WriteLine("Enter Std: ");
                stud.Std = Convert.ToInt32(Console.ReadLine());

               List<Students> list= caller.GetStudentsByStdDivBLL(stud.Div, stud.Std);

                foreach (Students s in list)
                {
                    Console.WriteLine("Rollno: "+s.RollNo);
                    Console.WriteLine("Name: "+s.Name);
                    Console.WriteLine("Standard: "+s.Std);
                    Console.WriteLine("Division: "+s.Div);
                    Console.WriteLine("Address: "+s.Address);
                    Console.WriteLine("********************************************");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static void GetBooksByCategoryId()
        {
            try
            {
                Books book = new Books();

                Console.WriteLine("Enter Book CategoryId: ");
                book.CategoryId = Convert.ToInt32(Console.ReadLine());

                List<Books> bookList = caller.GetBooksByCategoryIDBLL(book.CategoryId);

                foreach (Books b in bookList)
                {
                    Console.WriteLine("BookCode: "+b.BookCode);
                    Console.WriteLine("Book Category Id: "+b.CategoryId);
                    Console.WriteLine("Book Name: "+b.BookName);
                    Console.WriteLine("Book Author: "+b.Author);
                    Console.WriteLine("Copies available: "+b.CopiesAvailable);
                    Console.WriteLine("************************************************");

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static void IssueBookPL()
        {
            try
            {
                LibraryTransaction library = new LibraryTransaction();

                Console.WriteLine("Enter BookCode: ");
                library.BookCode = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter RollNo: ");
                library.Rollno = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Std: ");
                library.Std = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Div: ");
                library.Div = Console.ReadLine();

                library.BookIssueDate = DateTime.Today;

                library.ExpectedReturnDate = library.BookIssueDate.AddDays(10);

                if(caller.IssueBookBLL(library))
                {
                    Console.WriteLine("Book issued Successfully");
                }
                else
                {
                    Console.WriteLine("Something went wrong, please try again!");
                }
               
            }
            catch (BooksException ex)
            {

                throw ex;
            }
        }

        static void Main(string[] args)
        {
            AppUserLogin();

            while (true)
            {
                PrintMenu();

                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        AddBookPL();
                        break;
                        

                    case 3:
                        GetStudentByStdDivPL();
                        break;

                    case 4:
                        GetBooksByCategoryId();
                        break;

                    case 5:
                        updateStudent();
                        break;

                    case 6:
                        AddCategory();
                        break;

                    case 7:
                        IssueBookPL();
                        break;

                    case 8:
                        return;

                    default:
                        Console.WriteLine("Sorry! Try Again.");
                        break;
                }
            }

        }
    }
}
