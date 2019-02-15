using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookWiki.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BookContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any() && context.Autor.Any() && context.BookAutor.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Id = 1,
                        Title = "How To Assemble A Desktop PC",
                        ReleaseDate = DateTime.Parse("2002-2-12"),
                        Genre = "Computing",
                        Price = 15.00M,
                        Rating = 2.50M
                    },

                    new Book
                    {
                        Id = 2,
                        Title = "Art and Psychoanalysis",
                        ReleaseDate = DateTime.Parse("2013-3-13"),
                        Genre = "Psihology",
                        Price = 40.50M,
                        Rating = 5.00M
                    },

                    new Book
                    {
                        Id = 3,
                        Title = "Bluestem: The Cookbook",
                        ReleaseDate = DateTime.Parse("2011-2-11"),
                        Genre = "Food",
                        Price = 9.99M,
                        Rating = 4.50M
                    },

                    new Book
                    {
                        Id = 4,
                        Title = "Sixguns and Society",
                        ReleaseDate = DateTime.Parse("1977-4-15"),
                        Genre = "Western",
                        Price = 20.99M,
                        Rating = 4.75M
                    }
                );
                context.SaveChanges();

                context.Autor.AddRange(
                    new Autor
                    {
                        Name = "Jame Kokovile",
                        Id = 1
                    },
                    new Autor
                    {
                        Name = "Jessica Louis",
                        Id = 2
                    }
                );
                context.SaveChanges();

                context.BookAutor.AddRange(
                    new BookAutor
                    {
                        AutorId=1,
                        BookId=1
                    },
                    new BookAutor
                    {
                        AutorId=1,
                        BookId=3
                    },
                    new BookAutor
                    {
                        AutorId=1,
                        BookId=4
                    },
                    new BookAutor
                    {
                        AutorId=2,
                        BookId=2
                    }
                );
                context.SaveChanges();
            }
            
        }
    }
}