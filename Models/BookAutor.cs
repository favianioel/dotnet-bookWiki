using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWiki.Models
{
    public class BookAutor
    {
        public int AutorId {get; set;}
        public Autor Autor {get; set;}


        public int BookId {get; set;}
        public Book Book {set; get;}
        
    }
}