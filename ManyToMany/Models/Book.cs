using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManyToMany.Models
{
    public class Book
    {
        public Book()
        {

        }
        [ScaffoldColumn(false)]
        public int BookId { get; set; }

        [Display(Name = "Book Name")]
        [MaxLength(100, ErrorMessage = "Book Name must be 100 characters or less"), MinLength(5)]
        public string BookName { get; set; }
        public int Pages { get; set; }

        public string Publisher { get; set; }

        public Genre Genre { get; set; }
        [JsonIgnore]
        public virtual ICollection<Author> Authors { get; set; }



    }
}