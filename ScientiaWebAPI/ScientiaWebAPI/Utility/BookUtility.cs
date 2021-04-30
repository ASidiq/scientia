using ScientiaWebAPI.Models;
using ScientiaWebAPI.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientiaWebAPI.Utility
{
    public static class BookUtility
    {
        public static BookViewModel GetViewModel(this Book book)
        {
            BookViewModel bookVM = new BookViewModel()
            {
                ID = book.ID,
                Title = book.Title,
                PublishedDate = book.PublishedDate,
                Type = book.Type,
                Genre = book.Genre,
                Location = book.Location,
                TotalPages = book.TotalPages,
                Rating = book.Rating,
                Copies = book.Copies,
                BookPictureUrl = book.BookPictureUrl,
                Author = book.Author
            };
            return bookVM;
        }

        public static List<BookViewModel> GetViewModels(this List<Book> books)
        {
            List<BookViewModel> allbookVM = new List<BookViewModel>();
            foreach (Book book in books)
            {
                allbookVM.Add(new BookViewModel()
                {
                    ID = book.ID,
                    Title = book.Title,
                    PublishedDate = book.PublishedDate,
                    Type = book.Type,
                    Genre = book.Genre,
                    Location = book.Location,
                    TotalPages = book.TotalPages,
                    Rating = book.Rating,
                    Copies = book.Copies,
                    BookPictureUrl = book.BookPictureUrl,
                    Author = book.Author
                });
            }
            return allbookVM;
        }
    }
}
