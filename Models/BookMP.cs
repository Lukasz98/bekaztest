using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WymianaKsiazek.Api.Database.Entities;

namespace WymianaKsiazek.Api.Models
{
    public class BookMP
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
        public string Isbn { get; set; }
        public virtual CategoryMP Category { get; set; }
    }
}
