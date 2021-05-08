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

    public class BookControllerTest
    {
        private Mock<IRepositoryWrapper> mockRepo;
        private BooksController booksController;
        private BookBindingModel addbook;
        private UpdateBookBindingModel updateBook;
        private Book book;
        private List<Book> books;
        private Mock<IBook> bookMock;
        private List<IBook> booksMock;
        private Mock<IBookBindingModel> addBookMock;
        private Mock<IUpdateBookBindingModel> updateBookMock;
        private Mock<IBookViewModel> bookViewModelMock;
        private List<IBookViewModel> booksViewModelMock;

        public BookControllerTest()
        {
            // mock setup
            bookMock = new Mock<IBook>();
            booksMock = new List<IBook> { bookMock.Object };
            addBookMock = new Mock<IBookBindingModel>();
            updateBookMock = new Mock<IUpdateBookBindingModel>();
            book = new Book();
            books = new List<Book>();

            //view models mock setup
            bookViewModelMock = new Mock<IBookViewModel>();
            booksViewModelMock = new List<IBookViewModel>();

            //sample models
            addbook = new BookBindingModel
            {
                BookPictureUrl = "Picture4",
                Title = "Tomorrow is a good day",
                PublishedDate = 2005,
                Type = "Fiction",
                Genre = "Fantasy",
                Location = "UK",
                TotalPages = 500,
                Rating = 10,
                Copies = 5,
                AuthorName = "Ali",
                AuthorPicUrl = "Picture4"
            };

            //sample model
            updateBook = new UpdateBookBindingModel
            {
 
                Title = "The Gods Are Not to Blame",
                PublishedDate = 2005,
                Type = "Fiction",
                Genre = "Fantasy",
                Location = "UK",
                TotalPages = 500,
                Rating = 10,
                Copies = 5,
                BookPictureUrl = "Picture5"
            };

            var authorMock = new Mock<IAuthor>();
            var AuthorsMock = new List<IAuthor>() { authorMock.Object };
            var bookResultsMock = new Mock<IActionResult>();

            mockRepo = new Mock<IRepositoryWrapper>();
            var allBooks = GetBooks();
            booksController = new BooksController(mockRepo.Object);
        }
        
        [Fact]
        public void GetAllBooksTest()
        {
            
            //Arrange
            mockRepo.Setup(repo => repo.Books.FindAll(b => b.Author)).Returns(GetBooks());

            //Act
            var controllerActionResult = booksController.GetAllBooks();

            //Assert
            Assert.NotNull(controllerActionResult);
           
        }

        [Fact]
        public void GetBookTest()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Books.FindByCondition(b => b.Author, b => b.Title.Equals(It.IsAny<string>()))).Returns(GetBooks());
            

            //Act
            var controllerActionResult = booksController.GetBookByTitle(It.IsAny<string>());

            //Assert
            Assert.NotNull(controllerActionResult);
           
        }

        [Fact]
        public void AddBookTest()
        {
            //Arrange
            //var authorExists = repository.Authors.Where(a => a.Name == bindingModel.AuthorName).FirstOrDefault();
            mockRepo.Setup(repo => repo.Authors.Where(a => a.Name == addbook.AuthorName)).Returns(GetAuthors());
            mockRepo.Setup(repo => repo.Authors.Create(It.IsAny<Author>())).Returns(GetAuthor());
            mockRepo.Setup(repo => repo.Books.Create(It.IsAny<Book>())).Returns(GetBook());

            //var addAuthor = repository.Authors.Create(newAuthor);

            //var createdBook = repository.Books.Create(BookToCreate);

            //Act
            var controllerActionResult = (BookViewModel) ((OkObjectResult) booksController.CreateBook(addbook)).Value;

            //Assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<BookViewModel>(controllerActionResult);
        }

        [Fact]
        public void UpdateBookTest()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Books.Where(b => b.ID == 1)).Returns(GetBooks());

            //Act
            var controllerActionResult = (BookViewModel)((OkObjectResult) booksController.UpdateBook(updateBook, 1)).Value;

            //Assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<BookViewModel>(controllerActionResult);
        }

        [Fact]
        public void DeleteBookTest()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Books.Where(c => c.Title == It.IsAny<string>())).Returns(GetBooks());
            mockRepo.Setup(repo => repo.Books.Delete(GetBook()));

            //var bookToDelete = repository.Books.Where(c => c.Title == ).FirstOrDefault();
            //repository.Books.Delete(bookToDelete);

            //Act
            var controllerActionResult = booksController.DeleteBook("Things Fall Apart");

            //Assert
            Assert.NotNull(controllerActionResult);
        }

        private IEnumerable<Book> GetBooks()
        {
            Book book1 = new Book
            {
                ID = 1,
                BookPictureUrl = "Picture1",
                Title = "Things Fall Apart",
                PublishedDate = 1958,
                Type = "Fiction",
                Genre = "Fantasy",
                Location = "UK",
                TotalPages = 500,
                Rating = 10,
                Copies = 5
            };

            Book book2 = new Book
            {
                ID = 2,
                BookPictureUrl = "Picture2",
                Title = "Purple Hibiscus",
                PublishedDate =2003,
                Type = "Fiction",
                Genre = "Novel",
                Location = "Nigeria",
                TotalPages = 500,
                Rating = 10,
                Copies = 3
            };

            var books = new List<Book>
            {
                book1, book2
            };
            return books;
        }

        private Book GetBook()
        {
            return GetBooks().ToList()[0];
        }

        private IEnumerable<Author> GetAuthors()
        {
            Author newAuthor1 = new Author()
            {
                ID = 7,
                Name = "Ali",
                AuthorPicUrl = "Picture7"
            };
            Author newAuthor2 = new Author()
            {
                ID = 8,
                Name = "Keneil",
                AuthorPicUrl = "Picture8"
            };

            return new List<Author> { newAuthor1, newAuthor2 };

        }

        private Author GetAuthor()
        {
            return GetAuthors().ToList()[0];
        }
    }
}
