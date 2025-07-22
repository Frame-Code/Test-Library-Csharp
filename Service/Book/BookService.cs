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
    public class BookService(IBookRepository bookRepository) : IBookService
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public async Task Add(BookDTO book)
        {
            await _bookRepository.Add(
                new BookEntity
                {
                    Name = book.nombre,
                    Author = book.author,
                    Description = book.description,
                    Category = book.category
                });
        }

        public async Task<ICollection<BookDTO>> FindAll()
        {
            ICollection<BookEntity> bookList = await _bookRepository.FindAll();
            return bookList
                    .Select(b => new BookDTO(b.Name, b.Author, b.Description, b.Category))
                    .ToList();
        }

        public async Task<BookDTO?> FindById(int id)
        {
            BookEntity? book = await _bookRepository.FindByID(id);
            return book == null ? null : new BookDTO(book.Name, book.Author, book.Description, book.Category);
        }
    }
}
