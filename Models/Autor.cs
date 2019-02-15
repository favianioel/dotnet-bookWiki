using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BookWiki.Models
{
    public class Autor
    {
        public int Id {get; set;}
        public string Name {get; set;}

        public IList<BookAutor> BookAutor {get; set;} =  new List<BookAutor>();

    }
}