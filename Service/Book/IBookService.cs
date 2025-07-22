using Library.shared.BookDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Book
{
    public interface IBookService
    {
        Task Add(BookDTO book);
        Task<BookDTO?> FindById(int id);
        Task<ICollection<BookDTO>> FindAll();
    }
}
