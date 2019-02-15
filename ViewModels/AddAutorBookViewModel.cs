using BookWiki.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookWiki.ViewModels
{
    public class AddAutorBookViewModel
    {
        public Autor Autor {get;set;}
        public List<SelectListItem> Books {get;set;}

        public int AutorId {get;set;}
        public int BookId {get;set;}

        public AddAutorBookViewModel() { }
        public AddAutorBookViewModel(Autor autor, IEnumerable<Book> books)
        {
            Books = new List<SelectListItem>();
            foreach(var book in books)
            {
                Books.Add(new SelectListItem
                {
                    Value = book.Id.ToString(),
                    Text = book.Title
                });
            }
            Autor = autor;
        }
    }
}