using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ManyToMany.Models
{
    public class ViewModel
    {
        public ViewModel()
        {
            Authors = new List<Author>();
        }
        public int BookId { get; set; }

        public string BookName { get; set; }

        public int Pages { get; set; }

        public Genre Genre { get; set; }

        public string Publisher { get; set; }
        //public string AuthorName { get; set; }
        [UIHint("AuthorsEditor")]
        public List<Author> Authors { get; set; }
        //public IQueryable<string> AuthorNames { get; set; }
    }
}