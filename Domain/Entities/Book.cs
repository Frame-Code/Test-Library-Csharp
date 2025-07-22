using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class BookEntity
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

    }
}
