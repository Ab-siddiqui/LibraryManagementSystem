using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Entities;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using LMS.Exceptions;

namespace LMS.DAL
{
    public class LibraryDBDAL 
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;

        public LibraryDBDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
        }





        public bool AddBookDAL(Books books)
        {
            bool status = false;

            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_addBook";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookCode", books.BookCode);
                cmd.Parameters.AddWithValue("@BookName", books.BookName);
                cmd.Parameters.AddWithValue("@CopiesAvailable", books.CopiesAvailable);
                cmd.Parameters.AddWithValue("@Author", books.Author);
                cmd.Parameters.AddWithValue("@CategoryId", books.CategoryId);

                conn.Open();

                int count = cmd.ExecuteNonQuery();

                if(count >0)
                {
                    status = true;
                }

            }
            catch (BooksException ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return status;
        }

        public bool AddCategoryDAL(BookCategories category)
        {
            bool status = false;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_AddBookCategory";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);

                conn.Open();

                int count = cmd.ExecuteNonQuery();

                if(count>0)
                {
                    status = true;
                }
            }
            catch (BookCategoriesException ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return status;
        }

        public bool AddStudentDAL(Students students)
        {
            bool status = false;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_addstudent";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RollNo",students.RollNo);
                cmd.Parameters.AddWithValue("@Name", students.Name);
                cmd.Parameters.AddWithValue("@Std", students.Std);
                cmd.Parameters.AddWithValue("@Div", students.Div);
                cmd.Parameters.AddWithValue("@Address", students.Address);

                conn.Open();

                int count = cmd.ExecuteNonQuery();

                if(count>0)
                {
                    status = true;
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public bool AppUserLogin(AppUsers appUsers)
        {
            bool status = false;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_Login";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", appUsers.AppUserName);
                cmd.Parameters.AddWithValue("@Password", appUsers.password);

                conn.Open();

                 reader = cmd.ExecuteReader();
               
                if(reader.HasRows)
                {
                    status = true;
                }

            }
            catch (AppUserException ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public List<Books> GetBookByCategoryId(int categoryId)
        {
            List<Books> bookList = null;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_GetBookByCategoryId";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                conn.Open();

                reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    bookList = new List<Books>();

                    while(reader.Read())
                    {
                        Books books = new Books
                        {
                            BookCode = reader.GetInt32(0),
                            BookName = reader.GetString(1),
                            CopiesAvailable = reader.GetInt32(2),
                            Author = reader.GetString(3),
                            CategoryId = reader.GetInt32(4),
                            
                            
                        };

                        bookList.Add(books);
                    }

                        
                }
                else
                {
                    Console.WriteLine("No data Found");
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return bookList;
        }

        public List<Students> GetStudentsByStdDiv(string div, int Std)
        {
            List<Students> studList = null;

            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_GetStudentByStdDiv";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Div", div);
                cmd.Parameters.AddWithValue("@Std", Std);

                conn.Open();

                reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    studList = new List<Students>();

                    while (reader.Read())
                    {
                        Students student = new Students
                        {
                            RollNo = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Std = reader.GetInt32(2),
                            Div = reader.GetString(3),
                            Address = reader.GetString(4)
                        };

                        studList.Add(student);
                    }
                }
                else
                {
                    Console.WriteLine("Data not found");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return studList;
        }

       

        public bool UpdateStudentDAL(Students student)
        {
            bool status = false;

            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_UpdateStudent";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Rollno", student.RollNo);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Std", student.Std);
                cmd.Parameters.AddWithValue("@Div", student.Div);
                cmd.Parameters.AddWithValue("@Address", student.Address);

                conn.Open();

                int count = cmd.ExecuteNonQuery();

                if(count>0)
                {
                    status = true;
                }
                

            }
            catch (StudentException ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return status;
        }

        public bool IssueBook(LibraryTransaction libTransaction)
        {
            bool status = false;

            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_IssueBook";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookCode", libTransaction.BookCode);
                cmd.Parameters.AddWithValue("@Rollno", libTransaction.Rollno);
                cmd.Parameters.AddWithValue("@Std", libTransaction.Std);
                cmd.Parameters.AddWithValue("@Div", libTransaction.Div);
                cmd.Parameters.AddWithValue("@IssueDate", libTransaction.BookIssueDate);
                cmd.Parameters.AddWithValue("@ExpectedReturnDate", libTransaction.ExpectedReturnDate);
                
                

                conn.Open();

                int count = cmd.ExecuteNonQuery();

                if(count>0)
                {
                    status = true;
                }
            }
            catch (BooksException ex )
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return status;
        }

        public bool ReturnBook(LibraryTransaction libTransaction)
        {
            bool status = false;

            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_searchStudent";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Rollno", libTransaction.Rollno);
                cmd.Parameters.AddWithValue("@Std", libTransaction.Std);
                cmd.Parameters.AddWithValue("@Div", libTransaction.Div);
                cmd.Parameters.AddWithValue("@BookCode", libTransaction.BookCode);

                conn.Open();

                reader= cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    status = true;
                    
                    LibraryTransaction lib = null;

                    while (reader.Read())               
                    {
                        lib = new LibraryTransaction
                        {
                          Rollno = reader.GetInt32(0),
                          Std=reader.GetInt32(1),
                          Div=reader.GetString(2),
                          BookCode=reader.GetInt32(3),
                          ExpectedReturnDate=reader.GetDateTime(4),
                          Fine=reader.GetDouble(5)
                        };
                    }

                    if(libTransaction.ActualReturnDate > lib.ExpectedReturnDate)
                    {
                           Console.WriteLine("You have to pay Fine !");
                        
                        cmd = conn.CreateCommand();
                        cmd.CommandText = "sp_UpdateReturnBooks";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Rollno", libTransaction.Rollno);
                        cmd.Parameters.AddWithValue("@Std", libTransaction.Std);
                        cmd.Parameters.AddWithValue("@Div", libTransaction.Div);
                        cmd.Parameters.AddWithValue("@ActualReturnDate", libTransaction.ActualReturnDate);
                        cmd.Parameters.AddWithValue("@Fine", libTransaction.Fine);

                        int count =cmd.ExecuteNonQuery();
                        if (count>0)
                        {
                            status = true;
                        }
                      

                    }
                    else
                    {
                        Console.WriteLine("No need to pay Fine!");
                    }




                    
                }
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }
    }
}
