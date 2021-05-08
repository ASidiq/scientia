using ScientiaWebAPI.Models;
using ScientiaWebAPI.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientiaWebAPI.Utility
{
    public static class AuthorUtility
    {
        public static AuthorViewModel GetViewModel(this Author author)
        {
            AuthorViewModel authorVM = new AuthorViewModel()
            {
                ID = author.ID,
                Name = author.Name,
                Books = author.Books,
                AuthorPicUrl = author.AuthorPicUrl
            };
            return authorVM;
        }

        public static List<AuthorViewModel> GetViewModels(this IEnumerable<Author> authors)
        {
            List<AuthorViewModel> allauthorVM = new List<AuthorViewModel>();
            foreach (Author author in authors)
            {
                allauthorVM.Add(new AuthorViewModel()
                {
                    ID = author.ID,
                    Name = author.Name,
                    Books = author.Books,
                    AuthorPicUrl = author.AuthorPicUrl
                });
            }
            return allauthorVM;
        }
    }
}
