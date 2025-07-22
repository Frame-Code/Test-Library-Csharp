using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.shared.BookDTO
{
    public record BookDTO(
        string nombre,
        string author,
        string description,
        string category
        )
    {
    }
}
