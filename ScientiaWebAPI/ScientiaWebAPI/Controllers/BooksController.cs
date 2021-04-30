using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientiaWebAPI.Data;
using ScientiaWebAPI.Models;
using ScientiaWebAPI.Models.Binding;
using ScientiaWebAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientiaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public BooksController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        [HttpGet("")]
        public IActionResult GetAllBooks()
        {
            //Get All Books with the names of the authors
            var allBooks = dbContext.Books.Include(b => b.Author).ToList();
            return Ok(allBooks.GetViewModels());

            //var allBooks = dbContext.Books.ToList();
        }

        [HttpGet("{title}")]
        public IActionResult GetBookByTitle(string title)
        {
            
            Console.WriteLine(title);
            var BookByTitle = dbContext.Books.Include(b =>  b.Author).FirstOrDefault(b => b.Title.Equals(title));
            if (BookByTitle == null)
                return NotFound();
            return Ok(BookByTitle.GetViewModel());
        }

        [HttpPost("")]
        public IActionResult CreateBook([FromBody] BookBindingModel bindingModel)
        {
            Author authorExists = dbContext.Authors.FirstOrDefault(a => a.Name == bindingModel.AuthorName);
            
            // Add author if it doesn't already exists
            if (authorExists == null)
            {

                Author newAuthor = new Author
                {
                    Name = bindingModel.AuthorName,
                    AuthorPicUrl = bindingModel.AuthorPicUrl
                    //"https://th.bing.com/th/id/R80677ad4549c7ab35bc3e3cca9f5fa4e?rik=nlG0uuKC%2fVgkDg&pid=ImgRaw"
                };
                var addAuthor = dbContext.Authors.Add(newAuthor).Entity;
                dbContext.SaveChanges();
                authorExists = addAuthor;
            }
            // [Title PublishedDate Type Genre Location TotalPages Rating Copies BookPictureUrl CreatedAt AuthorName  AuthorPicUrl]
            Book BookToCreate = new Book
            {
                Title = bindingModel.Title,
                BookPictureUrl = bindingModel.BookPictureUrl,
                //"https://th.bing.com/th/id/R80677ad4549c7ab35bc3e3cca9f5fa4e?rik=nlG0uuKC%2fVgkDg&pid=ImgRaw",
                PublishedDate = bindingModel.PublishedDate,
                Type = bindingModel.Type,
                Genre = bindingModel.Genre,
                Location = bindingModel.Location,
                TotalPages = bindingModel.TotalPages,
                Copies = bindingModel.Copies,
                Rating = bindingModel.Rating,
                CreatedAt = DateTime.Now,
                Author = authorExists,
            };
            var createdBook = dbContext.Books.Add(BookToCreate).Entity;
            dbContext.SaveChanges();
            return Ok(BookToCreate.GetViewModel());

        }

        [HttpPut("{bookID:int}")]
        public IActionResult UpdateBook([FromBody] UpdateBookBindingModel bindingModel, int bookID)
        {
            var bookById = dbContext.Books.FirstOrDefault(b => b.ID == bookID);
            if (bookById == null)
                return NotFound();
            bookById.Title = bindingModel.Title;
            bookById.PublishedDate = bindingModel.PublishedDate;
            bookById.BookPictureUrl = bindingModel.BookPictureUrl;
            bookById.Type = bindingModel.Type;
            bookById.Genre = bindingModel.Genre;
            bookById.Location = bindingModel.Location;
            bookById.Copies = bindingModel.Copies;
            bookById.Rating = bindingModel.Rating;
            bookById.TotalPages = bindingModel.TotalPages;

            dbContext.SaveChanges();
            return Ok(bookById.GetViewModel());
        }

        [HttpDelete("{title}")]
        public IActionResult DeleteBook(string title)
        {
            var bookToDelete = dbContext.Books.FirstOrDefault(c => c.Title == title);
            if (bookToDelete == null)
                return NotFound();
            dbContext.Books.Remove(bookToDelete);
            dbContext.SaveChanges();
            return NoContent();
        }

    }
}
