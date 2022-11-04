using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksDAL;
using BooksDAL.Models;


namespace BooksServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : Controller
    {
        BookRepository repository;
        public BookController()
        {
            repository = new BookRepository();
        }

        [HttpGet]
        public JsonResult GetAllBooks()
        {
            List<Books> products = new List<Books>();
            try
            {
                products = repository.GetAllBooks();
            }
            catch (Exception ex)
            {
                products = null;
            }
            return Json(products);
        }

        [HttpGet]
        public JsonResult GetBookById(byte bookId)
        {
            Books product = null;
            try
            {
                product = repository.GetBookById(bookId);
            }
            catch (Exception ex)
            {
                product = null;
            }
            return Json(product);
        }

        [HttpPost]
        public JsonResult AddBook(string bookName, string authorname)
        {
            bool status = false;
           
            string message;
            try
            {
                status = repository.AddBook(bookName, authorname);
                if (status)
                {
                    message = "Successfully added a Book!";
                }
                else
                {
                    message = "Unsuccessful operation!";
                }
            }
            catch (Exception ex)
            {
                message = "Some error occured, please try again!";
            }
            return Json(message);
        }



    }
}
