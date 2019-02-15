using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookWiki.Models;
using BookWiki.ViewModels;
using Microsoft.Extensions.Localization;

namespace BookWiki.Controllers
{
    public class AutorsController : Controller
    {
        private readonly IStringLocalizer<AutorsController> _localizer;
        private readonly BookContext _context;

        public AutorsController(IStringLocalizer<AutorsController> localizer, BookContext context)
        {
            _localizer = localizer;
            _context = context;
        }

        // GET: Autors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autor.ToListAsync());
        }

        // GET: Autors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<BookAutor> books = _context
            .BookAutor
            .Include(b => b.Book)
            .Where(ba => ba.AutorId == id).ToList();

            var autor =  await _context
            .Autor
            .FirstOrDefaultAsync(m => m.Id == id);

            if (autor == null)
            {
                return NotFound();
            }      

            ViewAutorViewModel viewAutor = new ViewAutorViewModel {
                Books = books,
                Autor = autor
            };    
            
            return View(viewAutor);
        }

        // GET: Autors/Create
        public IActionResult Create()
        {
            CreateAutorViewModel createAutorViewModel = new CreateAutorViewModel();
            return View(createAutorViewModel);
        }

        // POST: Autors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(CreateAutorViewModel createAutorViewModel)
        {
            if (ModelState.IsValid)
            {
                Autor newAutor  = new Autor
                {
                    Name = createAutorViewModel.Name
                };

                _context.Autor.Add(newAutor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(createAutorViewModel);
        }

        // GET: Autors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: Autors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Autor autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        public IActionResult AddBook(int Id)
        {
            Autor autor = _context.Autor.Single(a => a.Id == Id);
            List<Book> books = _context.Book.ToList();
            return View(new AddAutorBookViewModel(autor, books));
        }
        [HttpPost]
        public IActionResult AddBook(AddAutorBookViewModel addAutorBookViewModel)
        {
            if (ModelState.IsValid)
            {
                var BookId = addAutorBookViewModel.BookId;
                var AutorId = addAutorBookViewModel.AutorId;

                IList<BookAutor> existingItems = _context.BookAutor
                .Where(ba => ba.BookId == BookId)
                .Where(ba => ba.AutorId == AutorId)
                .ToList();

                if (existingItems.Count == 0)
                {
                    BookAutor autorBooks = new BookAutor
                    {
                        Book = _context.Book.Single(b => b.Id == BookId),
                        Autor = _context.Autor.Single(a => a.Id == AutorId)
                    };

                    _context.BookAutor.Add(autorBooks);
                    _context.SaveChanges();
                }
                return RedirectToAction("Details", "Autors", new { id = AutorId});
            }
            return View(addAutorBookViewModel);
        }

        // GET: Autors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autor = await _context.Autor.FindAsync(id);
            _context.Autor.Remove(autor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(int id)
        {
            return _context.Autor.Any(e => e.Id == id);
        }
    }
}
