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
}
