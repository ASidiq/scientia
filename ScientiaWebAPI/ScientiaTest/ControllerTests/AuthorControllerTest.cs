using Moq;
using ScientiaWebAPI.Controllers;
using ScientiaWebAPI.Interfaces;
using ScientiaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using ScientiaWebAPI.Models.Binding;
using ScientiaWebAPI.Models.View;

namespace ScientiaTest.ControllerTests
{
    public class AuthorControllerTest
    {
        private Mock<IRepositoryWrapper> mockRepo;
        private AuthorsController authorsController;
        private AuthorBindingModel updateAuthor;
        private Author author;

        private List<Author> authors;
        private Mock<IAuthor> authorMock;
        private List<IAuthor> authorsMock;
        private Mock<IAuthorBindingModel> updateAuthorMock;
        private Mock<IAuthorViewModel> authorViewModelMock;
        private List<IAuthorViewModel> authorsViewModelMock;

        public AuthorControllerTest()
        {
            // mock setup
            authorMock = new Mock<IAuthor>();
            authorsMock = new List<IAuthor> { authorMock.Object };
            updateAuthorMock = new Mock<IAuthorBindingModel>();
            author = new Author();
            authors = new List<Author>();

            //view models mock setup
            authorViewModelMock = new Mock<IAuthorViewModel>();
            authorsViewModelMock = new List<IAuthorViewModel>();

            //sample model
            updateAuthor = new AuthorBindingModel
            {
                Name = "Bob Marley",
                AuthorPicUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTiCIK11DC2SV42gTLh9-ZNzQC3Z2Rr4OIPWQ&usqp=CAU"
            };

            var bookMock = new Mock<IBook>();
            var BooksMock = new List<IBook>() { bookMock.Object };
            var AuthorResultsMock = new Mock<IActionResult>();

            mockRepo = new Mock<IRepositoryWrapper>();
            var allBooks = GetAuthors();
            authorsController = new AuthorsController(mockRepo.Object);
        }

        [Fact]
        public void GetAllAuthorsTest()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Authors.FindAll(b => b.Books)).Returns(GetAuthors());

            //Act
            var controllerActionResult = authorsController.GetAllAuthors();

            //Assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void GetAuthorTest()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Authors.FindByCondition(b => b.Books, b => b.Name.Equals(It.IsAny<string>()))).Returns(GetAuthors());


            //Act
            var controllerActionResult = authorsController.GetAuthorByName(It.IsAny<string>());

            //Assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void UpdateAuthorTest()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Authors.Where(b => b.ID == 20)).Returns(GetAuthors());

            //Act
            var controllerActionResult = (AuthorViewModel)((OkObjectResult)authorsController.UpdateAuthor(updateAuthor, 20)).Value;

            //Assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<AuthorViewModel>(controllerActionResult);
        }

        [Fact]
        public void DeleteAuthorTest()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Authors.FindByCondition(b => b.Books, c => c.Name == It.IsAny<string>())).Returns(GetAuthors());
            mockRepo.Setup(repo => repo.Authors.Delete(GetAuthor()));

            //var bookToDelete = repository.Books.Where(c => c.Title == ).FirstOrDefault();
            //repository.Books.Delete(bookToDelete);

            //Act
            var controllerActionResult = authorsController.DeleteAuthor("Keneil");

            //Assert
            Assert.NotNull(controllerActionResult);
        }

        public IEnumerable<Author> GetAuthors()
        {
            Author newAuthor1 = new Author()
            {
                ID = 7,
                Name = "Victor",
                AuthorPicUrl = "https://avatars.githubusercontent.com/u/38431581?s=60&v=4"
            };
            Author newAuthor2 = new Author()
            {
                ID = 8,
                Name = "Keneil",
                AuthorPicUrl = "https://avatars.githubusercontent.com/u/38431581?s=60&v=4"
            };
            return new List<Author> { newAuthor1, newAuthor2 };
        }

        public Author GetAuthor()
        {
            return GetAuthors().ToList()[0];
        }
    }
}
