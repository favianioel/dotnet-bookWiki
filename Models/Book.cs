using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWiki.Models
{
    public class Book
    {
        public int Id {get; set;}
        public string Title {get; set;}

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate {get; set;}
        public string Genre {get; set;}
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price {get; set;}
        public decimal Rating {get; set;}

        public List<BookAutor> BookAutor {get;set;}
    }
}