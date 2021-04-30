﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientiaWebAPI.Models.View
{
    public class BookViewModel
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
        public Author Author { get; set; }
    }
}
