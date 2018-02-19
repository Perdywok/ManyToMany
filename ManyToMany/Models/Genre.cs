using System.ComponentModel.DataAnnotations;

namespace ManyToMany.Models
{
    public enum Genre
    {
        [Display(Name = "Comedy")]
        Comedy,
        [Display(Name = "Drama")]
        Drama,
        [Display(Name = "Horror")]
        Horror,
        [Display(Name = "Realism")]
        Realism,
        [Display(Name = "Romance")]
        Romance,
        [Display(Name = "Satire")]
        Satire,
        [Display(Name = "Tragedy")]
        Tragedy,
        [Display(Name = "Tragicomedy")]
        Tragicomedy,
        [Display(Name = "Fantasy")]
        Fantasy,
        [Display(Name = "Mythology")]
        Mythology,
        [Display(Name = "Adventure")]
        Adventure,
    }
}