using ScientiaWebAPI.Models;
using System;
using Xunit;
using System.Collections.Generic;
using ScientiaWebAPI.Utility;
using ScientiaWebAPI.Models.View;

namespace ScientiaTest.Utility
{
    public class AuthorUtilityTest
    {
        [Fact]
        public void GetViewModel()
        {
            Author newAuthor = new Author()
            {
                ID = 5,
                Name = "Abubakr Olorunlambe",
                AuthorPicUrl = "https://avatars.githubusercontent.com/u/38431581?s=60&v=4"
            };
            //Act
            var testAuthorViewModel = newAuthor.GetViewModel();

            //Assert
            Assert.IsType<AuthorViewModel>(testAuthorViewModel);
            Assert.NotNull(testAuthorViewModel);
            Assert.NotEmpty(newAuthor.Name);
        }
       
        [Fact]
        public void GetViewModels()
        {
            //Arrange
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
            List<Author>listOfAuthors = new List<Author> { newAuthor1, newAuthor2 };

            //Act
            var testListAuthorViewModel = listOfAuthors.GetViewModels();

            //Assert
            Assert.IsType<List<AuthorViewModel>>(testListAuthorViewModel);
            Assert.NotNull(testListAuthorViewModel);
            Assert.NotEmpty(listOfAuthors);
            Assert.NotEqual(newAuthor1.ID, newAuthor2.ID);
        }




    }
}
