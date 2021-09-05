using System;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Application.ViewModels.Books
{
    public class BookCreateModel
    {
        [Required, StringLength(150, MinimumLength = 2)]
        public string Name { get; set; }
        [Required, StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }
        public string Authors { get; set; }
    }

    public class BookEditModel : BookCreateModel
    {
        public Guid Id { get; set; }
    }

    public class BookViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Authors { get; set; }
        public string Photo { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
