using ScientiaWebAPI.Models;
using ScientiaWebAPI.Models.View;
using ScientiaWebAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ScientiaTest.Utility
{
    public class BookUtilityTest
    {
        [Fact]
        public void GetViewModel()
        {
            //Arrange
            Book newBook = new Book()
            {
                ID = 7,
                CreatedAt = DateTime.Now,
                BookPictureUrl = "https://avatars.githubusercontent.com/u/38431581?s=60&v=4",
                Title = "Tomorrow is a good day",
                PublishedDate = 2005,
                Type = "Fiction",
                Genre = "Fantasy",
                Location = "UK",
                TotalPages = 500,
                Rating = 10,
                Copies=5
            };

            //Act
            var testBookViewModel = newBook.GetViewModel();

            //Assert
            Assert.IsType<BookViewModel>(testBookViewModel);
            Assert.NotNull(testBookViewModel);
            Assert.NotEmpty(newBook.Title);

        }

        [Fact]
        public void GetViewModels()
        {
            //Arrange
            Book newBook1 = new Book()
            {
                ID = 8,
                CreatedAt = DateTime.Now,
                BookPictureUrl = "https://avatars.githubusercontent.com/u/38431581?s=60&v=4",
                Title = "The Gods Are Not to Blame",
                PublishedDate = 2005,
                Type = "Fiction",
                Genre = "Fantasy",
                Location = "UK",
                TotalPages = 500,
                Rating = 10,
                Copies = 5
            };
            Book newBook2 = new Book()
            {
                ID = 9,
                CreatedAt = DateTime.Now,
                BookPictureUrl = "https://avatars.githubusercontent.com/u/38431581?s=60&v=4",
                Title = "Things Fall Apart",
                PublishedDate = 1958,
                Type = "Fiction",
                Genre = "Fantasy",
                Location = "UK",
                TotalPages = 500,
                Rating = 10,
                Copies = 5
            };
            List<Book> listOfBooks = new List<Book> { newBook1, newBook2 };

            //Act
            var testListBookViewModel = listOfBooks.GetViewModels();

            //Assert
            Assert.IsType<List<BookViewModel>>(testListBookViewModel);
            Assert.NotNull(testListBookViewModel);
            Assert.NotEmpty(listOfBooks);
            Assert.NotEqual(newBook1.ID, newBook2.ID);
        }
    }
}
