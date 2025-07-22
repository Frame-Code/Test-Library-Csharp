using Library.Domain.Data;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task Add(BookEntity book)
        {
            _context.BooksEntity.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<BookEntity>> FindAll() => await _context.BooksEntity.ToListAsync();

        public async Task<BookEntity?> FindByID(int id) => await _context.BooksEntity.FindAsync(id);
        
    }
}
