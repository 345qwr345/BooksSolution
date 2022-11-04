using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;
using BooksDAL.Models;

namespace BooksDAL
{
    public class BookRepository
    {
        private BookEntityDBContext context;
        public BookEntityDBContext Context { get { return context; } }
        public BookRepository(BookEntityDBContext dbContext)
        {
            context = dbContext;
        }
        public BookRepository()
        {
            context = new BookEntityDBContext();
        }

        public List<Books> GetAllBooks()
        {
            List<Books> lstProducts = null;
            try
            {
                lstProducts = (from p in context.Books
                               orderby p.BookId
                               select p).ToList();
            }
            catch (Exception e)
            {
                lstProducts = null;
            }
            return lstProducts;
        }

        public Books GetBookById(byte bookId)
        {
            Books lstProducts = null;
            try
            {
                lstProducts = (from c in context.Books
                               where c.BookId.Equals(bookId)
                               select c).FirstOrDefault();
            }
            catch (Exception ex)
            {
                lstProducts = null;
            }
            return lstProducts;
        }

        public bool AddBook(string bookName, string authorname)
        {
            bool status = false;
           
            try
            {
                Books prodObj = new Books();
                prodObj.BookName = bookName;
                prodObj.AuthorName = authorname;
               
                context.Books.Add(prodObj);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {                
                status = false;
            }
            return status;
        }


    }
}
