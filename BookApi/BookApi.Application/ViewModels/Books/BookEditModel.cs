using System;

namespace BookApi.Application.ViewModels.Books
{
    public class BookEditModel : BookCreateModel
    {
        public Guid Id { get; set; }
    }
}
