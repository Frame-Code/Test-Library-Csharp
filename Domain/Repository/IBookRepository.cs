using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repository
{
    public interface IBookRepository
    {
        Task Add(BookEntity book);
        Task<BookEntity>? findByID(int id);
        Task<ICollection<BookEntity>> findAll();

    }
}
