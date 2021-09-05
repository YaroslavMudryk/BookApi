using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookApi.Domain.Models
{
    public class BaseCreatedModel
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedFromIP { get; set; }
        public string CreatedBy { get; set; }
    }

    public class BaseEditedModel : BaseCreatedModel
    {
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedFromIP { get; set; }
        public string LastUpdatedBy { get; set; }
    }

    public class BaseModel : BaseEditedModel
    {

    }

    public class BaseModel<T> : BaseModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
    }
}