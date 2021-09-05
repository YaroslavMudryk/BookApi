using System;

namespace BookApi.Application.ViewModels.Books
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Authors { get; set; }
        public string Photo { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
