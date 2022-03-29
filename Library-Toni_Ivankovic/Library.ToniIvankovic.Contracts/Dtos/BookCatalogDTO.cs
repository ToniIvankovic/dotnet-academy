using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Entities;

namespace Library.ToniIvankovic.Contracts.Dtos
{
    public class BookCatalogDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public Genre Genre { get; set; }
        public int Quantity { get; set; }
    }
}
