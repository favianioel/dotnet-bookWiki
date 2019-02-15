using BookWiki.Models;
using System.Collections.Generic;

namespace BookWiki.ViewModels
{
    public class ViewAutorViewModel
    {
        public IList<BookAutor> Books {get;set;}

        public Autor Autor {get;set;}
    }
}