using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ManyToMany.Models
{
    public class Author
    {
        public Author()
        {

        }
        [Required]
        public int AuthorId { get; set; }

        [Display(Name = "Author Name")]
        [MaxLength(100, ErrorMessage = "Author Name must be 100 characters or less"), MinLength(5)]
        public string AuthorName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }

    }
}