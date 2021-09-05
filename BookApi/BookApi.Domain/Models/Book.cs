using System;
using System.ComponentModel.DataAnnotations;
namespace BookApi.Domain.Models
{
    public class Book : BaseModel<Guid>
    {
        [Required, StringLength(150, MinimumLength = 2)]
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Authors { get; set; }
        public string Photo { get; set; }
    }
}