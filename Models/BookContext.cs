using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookWiki.Models
{
    public class BookContext : DbContext
    {

        public DbSet<BookWiki.Models.Book> Book {get; set;}
        public DbSet<BookWiki.Models.Autor> Autor {get; set;}
        public DbSet<BookWiki.Models.BookAutor> BookAutor {get; set;}

        public BookContext(DbContextOptions<BookContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAutor>()
                .HasKey(c => new {c.BookId, c.AutorId});
        }
        
    }
}