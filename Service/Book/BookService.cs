using Library.Domain.Repository;
using Library.shared.BookDTO;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library.Service.Book
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Add(BookDTO book)
        {
            await _bookRepository.Add(
                new BookEntity
                {
                    Name = "Clean Code",
                    Author = "Robert C. Martin",
                    Description = "A book to learn code",
                    Category = "Study"
                });
        }

        public Task<ICollection<BookDTO>> FindAll()
        {
            return await _bookRepository.findAll()
                    .Select(b => new BookDTO(b.Name, b.Author, b.Description, b.Category))
                    .ToList();
        }

        public async Task<BookDTO?> FindById(int id)
        {
            BookEntity? book = await _bookRepository.findByID(id);
            if(book != null)
            {
                return new BookDTO(book.Name, book.Author, book.Description, book.Category);
            }
            return null;

        }
    }
}
