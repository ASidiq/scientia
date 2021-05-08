namespace ScientiaWebAPI.Interfaces 
{
    public interface IBookBindingModel
    {
        public string Title { get; set; }
        public int PublishedDate { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }
        public string Location { get; set; }
        public int TotalPages { get; set; }
        public int Rating { get; set; }
        public int Copies { get; set; }
        public string BookPictureUrl { get; set; }
        public string AuthorName { get; set; }
        public string AuthorPicUrl { get; set; }


    }
}
