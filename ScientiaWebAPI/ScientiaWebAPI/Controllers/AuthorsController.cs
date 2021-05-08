using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientiaWebAPI.Data;
using ScientiaWebAPI.Interfaces;
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
    public class AuthorsController : ControllerBase
    {
        private IRepositoryWrapper repository;

        //private readonly ApplicationDbContext dbContext;
        public AuthorsController(IRepositoryWrapper repositoryWrapper)
        {
            //dbContext = applicationDbContext;
            repository = repositoryWrapper;
        }

        [HttpGet("")]
        public IActionResult GetAllAuthors()
        {
            var allAuthors = repository.Authors.FindAll(b =>  b.Books);
            //var allAuthors = dbContext.Authors.Include(b => b.Books).ToList();
            return Ok(allAuthors.GetViewModels());
        }

        [HttpGet("{name}")]
        public IActionResult GetAuthorByName(string name)
        {
            var AuthorByName = repository.Authors.FindByCondition(b => b.Books, b => b.Name == name).FirstOrDefault();
            //var AuthorByName = dbContext.Authors.Include(b => b.Books).FirstOrDefault(b => b.Name == name);
            if (AuthorByName == null)
                return NotFound();
            return Ok(AuthorByName.GetViewModel());
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteAuthor(string name)
        {
            var AuthorToDelete = repository.Authors.FindByCondition(b => b.Books, c => c.Name == name).FirstOrDefault();
            //var AuthorToDelete = dbContext.Authors.Include(b => b.Books).FirstOrDefault(c => c.Name == name);
            if (AuthorToDelete == null)
                return NotFound("Not Found");

            var numberOfBooks = AuthorToDelete.Books.Count;
            if (numberOfBooks > 0)
            {
                return Conflict("Author cannot be deleted as it is still connected to a book");
            }

            repository.Authors.Delete(AuthorToDelete);
            //dbContext.Authors.Remove(AuthorToDelete);

            repository.Save();
            //dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("{authorID:int}")]
        public IActionResult UpdateAuthor([FromBody] AuthorBindingModel bindingModel, int authorID)
        {
            var authorById = repository.Authors.Where(b => b.ID == authorID).FirstOrDefault();
            //var authorById = dbContext.Authors.FirstOrDefault(b => b.ID == authorID);
            if (authorById == null)
                return NotFound();
            authorById.Name = bindingModel.Name;
            authorById.AuthorPicUrl = bindingModel.AuthorPicUrl;
            Console.WriteLine(authorById.Name);

            repository.Save();
            //dbContext.SaveChanges();
            return Ok(authorById.GetViewModel());
        }
    }
}
