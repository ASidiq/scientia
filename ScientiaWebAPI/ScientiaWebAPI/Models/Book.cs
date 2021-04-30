using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientiaWebAPI.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int PublishedDate { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }
        public string Location { get; set; }
        public int TotalPages { get; set; }
        public int Rating { get; set; }
        public int Copies { get; set; }
        public string BookPictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }


        public virtual Author Author { get; set; }
    }
}
